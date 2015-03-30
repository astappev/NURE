/*
Необходимо разработать приложение, в котором при нажатии на комбинацию клавиш Ctrl+A запускается первый поток,
Ctrl+B – второй поток. При этом в первом потоке начинают вычисляться значения функции y=sin(x),
а во втором потоке – значения функции y=cos(x).

Генерируемые данные передаются по локальной сети по протоколу TCP/IP в другое приложение,
которое принимает данные и отображает их на одном графике линиями разного цвета и текстуры.

При нажатии комбинации клавиш Ctrl+N должна останавливаться передача данных в первых двух потоках
и второе приложение должно вывести количество данных, поступившее для каждого графика.

Эти данные должны быть сохранены в реестр и должна быть возможность просмотра этих данных до тех пор, пока не будут
запущены снова два потока, которые сгенерируют новые последовательности данных.
*/

// Не включать ничего лишнего в Windows.h.
// В частности, не включать Winsock, так как мы будем использовать Winsock2, а Winsock и Winsock2 конфликтуют друг с другом.
#define WIN32_LEAN_AND_MEAN

#include <cstdlib>
#include <ctime>

// Заголовки большинства функций WinAPI.
#include <Windows.h>
#include <ShellAPI.h>
// tchar.h содержит макрос _T() и тип данных TCHAR.
#include <tchar.h>
// Заголовки библиотеки WinSock2.
#include <WinSock2.h>
#include <WS2tcpip.h>
// Заголовки GDI+.
#include <ObjIdl.h>
#include <GdiPlus.h>
#include "resource.h"

// Сама библиотека WinSock2.
#pragma comment(lib, "Ws2_32.lib")
// Библиотека GDI+.
#pragma comment(lib, "Gdiplus.lib")

// Для того, чтобы не конфликтовать с уже существующими типами Windows-сообщений,
// пользовательские типы сообщений должны объявляться как WM_USER + x, где x - целое неотрицательное число.
#define WM_ERROR				WM_USER
#define WM_CONNECTED			WM_USER + 1
#define WM_FINISHED				WM_USER + 2
#define WM_TRAY					WM_USER + 3

# define PI           3.14159265358979323846  /* pi */

DWORD WINAPI NetworkThread(LPVOID);
DWORD WINAPI CalculationThread(LPVOID thread_data);
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
BOOL CALLBACK ConnectDlgProc(HWND, UINT, WPARAM, LPARAM);
BOOL CALLBACK CountDlgProc(HWND, UINT, WPARAM, LPARAM);
LRESULT CALLBACK Hook(int code, WPARAM wParam, LPARAM lParam);

void MenuError();
// Помещает иконку в трей.
void InitTrayIcon();
// Удаляет иконку из трея.
void DestroyTrayIcon();
// Устанавливает или снимает (в зависимости от checked) галочку у пункта меню item.
void ChangeCheckbox(UINT item, bool checked);
// Ошибка
void SendError();
// Устанавливает хуки для комбинаций клавиш Ctrl+B и Ctrl+S.
void InitHooks();
// Заливает контекст устройства hdc белым цветом, а затем рисует заданный текст
// посередине. hdc должен иметь ширину w и высоту h.
// Перед вызовом функции должен быть проинициализирован GDI+.
void DrawCentered(HDC hdc, HFONT font, int w, int h, const WCHAR* text);

// Указатель на функции, интегралы которых вычисляются, которые будут импортированы из DLL. Инициализируются при запуске программы.
double(_cdecl *f1)(double x);
double(_cdecl *f2)(double x);

// Вспомогательные структуры, указатели на которые передаются в вычисляющие потоки.
struct ThreadData
{
	bool isRunning = false;
	int numThread;
	double current_value = 0;
	double(*function)(double);
} thread_data_1, thread_data_2;

const TCHAR* title = _T("Лабораторная работа 29: клиент");
const TCHAR* strings[] = {
	_T("Подключитесь к серверу, затем начните вычисления!"),
	_T("Подключение к серверу установлено"),
	_T("Соединение прервано"),
	_T("Данные отправлены!"),
	NULL
};

enum State
{
	INIT,
	CONNECTING,
	CONNECTING_CLOSE,
	SENDING,
	FINISHED,
};

enum MenuItem
{
	START_SESSION,
	STOP_SESSION,
	EXIT,
	START_COS,
	STOP_COS,
	START_SIN,
	STOP_SIN
};

SOCKET client_socket;
HHOOK hook;
HFONT font = (HFONT)GetStockObject(DEFAULT_GUI_FONT);
HANDLE network_thread = 0, calc_thread_1 = 0, calc_thread_2 = 0;
char server_ip[80];
char new_count[80];
HWND window = 0;
HMENU hMenu = 0;
double calculate_from = 0, current_cos = 0, current_sin = 0;
const double calculate_step = 0.1;
const int width = 500;
const int height = 300;
int dataSend = 0;
bool isSession = false;
ULONG_PTR gdi_token;
CRITICAL_SECTION critsect;

// Точка входа оконного приложения.
// Windows передаст в эту функцию четыре параметра, большинство из которых нам не нужны, поэтому мы пропустим имена ненужных параметров.
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE, LPSTR, int)
{
	// Инициализируем GDI+.
	Gdiplus::GdiplusStartupInput gdi_input;
	if (GdiplusStartup(&gdi_token, &gdi_input, NULL) != Gdiplus::Ok)
	{
		MessageBox(NULL, _T("Ошибка инициализации GDI+."), title, MB_ICONERROR | MB_OK);
		return 1;
	}

	// Загружаем бибилотеку.
	// Макрос _T() используется в WinAPI для представления строк, подстраивающихся под настройки компилятора.
	// Если в настройках было указано, что для WinAPI будут использоваться однобайтовые строки,
	// макрос _T() представит эту строку однобайтовой, если же используются двухбайтовые строки - двухбайтовой.
	// Поэтому желательно использовать макрос _T() для всех строк, которые будут передаваться в функции WinAPI.
	HMODULE dll = LoadLibrary(_T("CalcDLL.dll"));
	if (FAILED(dll))
	{
		MessageBox(NULL, _T("Невозможно загрузить библиотеку."), title, MB_ICONERROR | MB_OK);
		// Обычно при аварийном завершении программы функция main() должна вернуть ненулевое значение.
		return TRUE;
	}
	// Находим адрес функции CalculateIntegral.
	// GetProcAddress может возвращать адреса не только функций, но и переменных динамической библиотеки.
	// Для этого переменные (так же, как и функции) должны быть объявлены с __declspec(dllexport).
	f1 = (double(*)(double))GetProcAddress(dll, "f1");
	if (f1 == NULL)
	{
		FreeLibrary(dll);
		MessageBox(NULL, _T("В библиотеке не найдена функция f1."), title, MB_ICONERROR | MB_OK);
		return 1;
	}
	f2 = (double(*)(double))GetProcAddress(dll, "f2");
	if (f2 == NULL)
	{
		FreeLibrary(dll);
		MessageBox(NULL, _T("В библиотеке не найдена функция f2."), title, MB_ICONERROR | MB_OK);
		return 1;
	}

	// Создадим меню.
	// Для этого необходимо вызвать функцию CreateMenu(), которая возвратит дескриптор
	// свежесозданного меню. После этого можно заполнять его с помощью InsertMenuItem(), AppendMenu() и InsertMenu().
	hMenu = CreateMenu();
	if (!hMenu)
	{
		// Не удалось создать меню. Возможно, не хватило памяти или дескрипторов.
		MessageBox(NULL, _T("Ошибка при создании меню!"), title, NULL);
		// Обычно при аварийном завершении программы функция main() должна вернуть ненулевое значение.
		return GetLastError();
	}

	// Новое меню пока не выводится ни на одном окне; привязать его к окну можно будет потом при создании окна.

	// Меню будет иметь такую структуру:
	// (амперсанд при указании названия пункта меню обозначает, что следующая за ним буква будет подчёркнута, и этот пункт меню можно будет вызвать
	// не только мышкой, но и комбинацией клавиш Alt+подчёркнутая буква; в квадратных скобках указан соответствующий пункт перечисления MenuItem)

	// Пункты меню, которые должны содержать в себе подменю, должны быть предварительно созданы с помощью CreatePopupMenu().

	HMENU file = CreatePopupMenu(), funcCos = CreatePopupMenu(), funcSin = CreatePopupMenu();

	// Для пунктов, содержащих в себе подменю, при вызове AppendMenu должен быть установлен флаг MF_POPUP,
	// а третьим параметром должен быть передан дескриптор этого пункта, полученный из CreatePopupMenu().
	if (!AppendMenu(hMenu, MF_ENABLED | MF_POPUP, (UINT_PTR)file, _T("&Файл")))
		// Если при заполнении меню возникнет ошибка, вызовем функцию MenuError(), которая покажет пользователю окно с текстом об ошибке и завершит программу.
		MenuError();
	// А те пункты, которые не содержат в себе подменю, должны создаваться без флага MF_POPUP, и третьим параметром должен передаваться идентификатор пункта меню.
	// Мы будем подставлять идентификаторы, используя перечисление MenuItem.
	if (!AppendMenu(file, MF_ENABLED, START_SESSION, _T("&Подключиться...")))
		MenuError();
	if (!AppendMenu(file, MF_ENABLED, STOP_SESSION, _T("&Разорвать соединение...")))
		MenuError();
	if (!AppendMenu(file, MF_ENABLED, EXIT, _T("&Выход\tAlt+F4")))
		MenuError();
	if (!AppendMenu(hMenu, MF_GRAYED | MF_POPUP, (UINT_PTR)funcCos, _T("&Функция cos()")))
		MenuError();
	if (!AppendMenu(funcCos, MF_ENABLED, START_COS, _T("&Старт")))
		MenuError();
	if (!AppendMenu(funcCos, MF_ENABLED, STOP_COS, _T("&Стоп")))
		MenuError();
	if (!AppendMenu(hMenu, MF_GRAYED | MF_POPUP, (UINT_PTR)funcSin, _T("&Функция sin()")))
		MenuError();
	if (!AppendMenu(funcSin, MF_ENABLED, START_SIN, _T("&Старт")))
		MenuError();
	if (!AppendMenu(funcSin, MF_ENABLED, STOP_SIN, _T("&Стоп")))
		MenuError();

	// Создадим окно.
	// Создание окна в WinAPI происходит в два этапа.
	// Сначала необходимо зарегистрировать класс окна с помощью функции RegisterClassEx, затем собственно создать окно с помощью CreateWindowEx.

	// Класс окна описывается с помощью структуры типа WNDCLASSEX.
	// Понятие "класс окна" в WinAPI не имеет ничего общего с "классом" в C++.
	WNDCLASSEX wcex;

	// Заполним поля структуры.
	// Сначала обнулим все её поля.
	ZeroMemory(&wcex, sizeof(wcex));
	// Затем заполним необходимые нам поля.

	// lpfnWndProc: указатель на функцию, обрабатывающую сообщения окон этого класса.
	// У нас это WndProc.
	wcex.lpfnWndProc = WndProc;
	// hInstance: дескриптор текущего экземпляра приложения. Этот дескриптор всегда
	// уникален для каждого запущенного экземпляра приложения, что позволяет
	// идентифицировать их. Даже разные экземпляры одного приложения, запущенные
	// одновременно, будут иметь разные дескрипторы.
	// Windows передаёт этот дескриптор как первый параметр функции WinMain;
	// у нас он назван hInstance (так же, как и поле).
	wcex.hInstance = hInstance;
	// hIcon: иконка приложения. Будет отображаться в левом верхнем углу окна,
	// а также на панели задач. Если оставить в этом поле значение NULL, то Windows
	// покажет иконку по умолчанию. Иконка представляется в виде дексриптора иконки,
	// который может быть получен с помощью функции LoadImage.
	wcex.hIcon = NULL;
	// hCursor: дескриптор на картинку указателя мыши, которая будет использована тогда, когда указатель будет находиться над окном.
	// Лучше не сбивать пользователя с толку и выставить стандартный курсор-стрелку.
	// Чтобы получить дескриптор стрелки, воспользуемся LoadCursor.
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	// hbrBackground: дескриптор кисти фона окна. Этой кистью будет закрашено окно при
	// перерисовке. Кисть определяет цвет и узор закрашивания.
	wcex.hbrBackground = (HBRUSH)COLOR_WINDOWFRAME;
	// lpszClassName: имя класса, которое после регистрирования класса будет использовано
	// для обращения к этому классу.
	wcex.lpszClassName = _T("Client_Graph");
	// cbSize: специальное поле, которое должно быть равно размеру структуры WNDCLASSEX.
	wcex.cbSize = sizeof(WNDCLASSEX);
	// После заполнения структуры класса зарегистрируем его с помощью RegisterClassEx.
	// Только после регистрации можно будет создавать окна этого класса.
	// Функция RegisterClassEx возвращает ненулевое значение при успешной регистрации.
	if (!RegisterClassEx(&wcex))
	{
		MessageBox(NULL, _T("Ошибка при регистрации класса!"), title, NULL);
		return 1;
	}

	// Создадим окно с помощью CreateWindow.
	// Функция CreateWindow возвращает дескриптор созданного окна.
	window = CreateWindow(
		// имя только что зарегистрированного класса
		_T("Client_Graph"),
		// текст в заголовке окна
		title,
		// тип создаваемого окна
		WS_OVERLAPPEDWINDOW | WS_VISIBLE,
		// положение окна по X (считается в пикселях, слева направо, CW_USEDEFAULT - положение по умолчанию)
		CW_USEDEFAULT,
		// положение окна по Y (считается в пикселях, сверху вниз, CW_USEDEFAULT - положение по умолчанию)
		CW_USEDEFAULT,
		// ширина окна в пикселях
		width,
		// высота окна в пикселях
		height,
		// дескриптор родительского окна (у этого окна не будет родителя)
		NULL,
		// декскриптор меню окна
		hMenu,
		// декскриптор текущего экзмепляра приложения
		hInstance,
		// значение, которое будет передано окну после создания (нам это не нужно)
		NULL
	);
	if (FAILED(window))
	{
		MessageBox(NULL, _T("Ошибка при создании окна!"), title, MB_ICONERROR | MB_OK);
		return 1;
	}

	// Поместим иконку в трей.
	InitTrayIcon();

	// После создания окна его нужно перерисовать.
	UpdateWindow(window);

	// Итак, окно создано и готово принимать сообщения. Каждое сообщение хранится в структуре типа MSG.
	MSG msg;
	// В каждой итерации цикла обработки сообщений:
	// вызывается функция GetMessage, заполняющая структуру msg и возвращающая положительное значение, если пришло сообщение, которое нужно обработать;
	while (GetMessage(&msg, NULL, 0, 0) > 0)
	{
		// далее, вызывается функция TranslateMessage, переводящяя сообщения виртуальных клавиш в сообщения символов клавиатуры;
		TranslateMessage(&msg);
		// и затем сообщение отправляется на обработку функции WndProc.
		DispatchMessage(&msg);
	}

	// Когда пользователь закроет окно, цикл прервётся, и мы будем находиться здесь.
	// Удалим все использованные ресурсы и завершим программу.
	DeleteObject(font);
	WSACleanup();
	FreeLibrary(dll);
	DestroyTrayIcon();
	return 0;

}

// Обработчик сообщений окна. Вызывается для каждого сообщения.
// Вся информация о сообщении занесена в аргументах функции:
// hWnd - дескриптор окна, которое получило это сообщение;
// msg - тип сообщения;
// wParam и lParam - числа с дополнительной информацией о сообщении;
// их смысл различен для каждого типа сообщения.
// Эта функция не обязательно должна называться WndProc (в отличие от WinMain),
// это просто наиблоее часто встречающееся название в примерах по WinAPI.
// Таких функций в приложении может быть несколько.
LRESULT CALLBACK WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static bool ready1 = false;
	static bool ready2 = false;
	static State state = INIT;
	switch (msg)
	{
	case WM_TRAY:
		if (lParam == WM_RBUTTONDOWN)
		{
			//HMENU hMenu2 = hMenu;
			HMENU hPopup = GetSubMenu(hMenu, 0);
			SetForegroundWindow(hWnd);
			POINT pt;
			GetCursorPos(&pt);
			TrackPopupMenu(hPopup, 0, pt.x, pt.y, 0, hWnd, NULL);
			//DestroyMenu(hMenu2);
		}
		break;
	// Пользователь закрывает окно:
	case WM_DESTROY:
		// Остановим все потоки, если они запущены.
		// Процесс приложения не завершится, пока не завершатся все его потоки.
		if (calc_thread_1 != 0)
			TerminateThread(calc_thread_1, 0);
		if (calc_thread_2 != 0)
			TerminateThread(calc_thread_2, 0);
		if (network_thread != 0)
			TerminateThread(network_thread, 0);
		// Посылаем себе сообщение WM_QUIT. Это означает, что мы готовы закрыть окно.
		PostQuitMessage(0);
		return 0;
		// Закончено вычисление первого интеграла:
	// Сетевой поток прислал сообщение об ошибке:
	case WM_ERROR:
		// Все равно перейдём к сорировке.
		isSession = false;
		TerminateThread(network_thread, 0);
		state = CONNECTING_CLOSE;
		InvalidateRect(hWnd, NULL, FALSE);
		UpdateWindow(hWnd);
		return 0;
	// Подключение к серверу прошло нормально, идёт передача данных:
	case WM_CONNECTED:
		state = CONNECTING;
		InvalidateRect(hWnd, NULL, FALSE);
		UpdateWindow(hWnd);

		// Сделаем доступными все пункты меню.
		MENUITEMINFO mii;
		ZeroMemory(&mii, sizeof(MENUITEMINFO));
		mii.cbSize = sizeof(MENUITEMINFO);
		mii.fMask = MIIM_STATE;
		mii.fState = MFS_ENABLED;
		SetMenuItemInfo(hMenu, 1, TRUE, &mii);
		SetMenuItemInfo(hMenu, 2, TRUE, &mii);
		// Чтобы пользователь увидел, что пункты меню доступны, перерисуем меню.
		DrawMenuBar(hWnd);

		// Поставим галочку в меню напротив "Функция 1".
		ChangeCheckbox(STOP_COS, true);
		ChangeCheckbox(STOP_SIN, true);

		InitHooks();

		return 0;
	// Данные отосланы серверу:
	case WM_FINISHED:
		state = FINISHED;
		dataSend++;
		InvalidateRect(hWnd, NULL, FALSE);
		UpdateWindow(hWnd);
		return 0;
	case WM_COMMAND:
		{
			switch (LOWORD(wParam))
			{
			// Пункт "Подключиться...":
			case START_SESSION:
				// Функция DialogBox создаёт модальное диалоговое окно и возвращается,
				// когда пользователь его закроет. Значение, возвращаемое DialogBox - это
				// то, что возвращает диалог в своём обработчике сообщений.
				// В DlgProc указано, что диалог вернёт 1, если пользователь нажал OK.
				if (DialogBox(NULL, MAKEINTRESOURCE(IDD_IPSELECT), hWnd, ConnectDlgProc) == 1)
				{
					isSession = true;
					network_thread = CreateThread(NULL, 0, NetworkThread, NULL, 0, NULL);
					if (network_thread == 0)
					{
						MessageBox(NULL, _T("Ошибка при создании сетевого потока!"), title, MB_ICONERROR | MB_OK);
						return 0;
					}

					InitializeCriticalSection(&critsect);
				}
				state = CONNECTING;
				InvalidateRect(hWnd, NULL, FALSE);
				UpdateWindow(hWnd);

				break;
			// Пункт "Разорвать соединение":
			case STOP_SESSION:
				thread_data_1.isRunning = false;
				thread_data_2.isRunning = false;
				isSession = false;
				state = CONNECTING_CLOSE;
				InvalidateRect(hWnd, NULL, FALSE);
				UpdateWindow(hWnd);

				break;
			// Пункт "Выход": 
			case EXIT:
				thread_data_1.isRunning = false;
				thread_data_2.isRunning = false;
				isSession = false;
				PostQuitMessage(0);
				break;
			case START_COS:
				ChangeCheckbox(START_COS,true);
				ChangeCheckbox(STOP_COS, false);

				thread_data_1.isRunning = true;
				thread_data_1.numThread = 1;
				thread_data_1.function = f1;

				// Запускаем потоки. Не забываем о проверках на ошибки.
				calc_thread_1 = CreateThread(NULL, 0, CalculationThread, &thread_data_1, 0, NULL);
				if (calc_thread_1 == 0)
				{
					MessageBox(NULL, _T("Ошибка при создании первого потока!"), title, MB_ICONERROR | MB_OK);
					return 0;
				}

				break;
			case STOP_COS:
				ChangeCheckbox(START_COS, false);
				ChangeCheckbox(STOP_COS, true);
				thread_data_1.isRunning = false;
				break;
			case START_SIN:
				ChangeCheckbox(START_SIN, true);
				ChangeCheckbox(STOP_SIN, false);

				thread_data_2.isRunning = true;
				thread_data_2.numThread = 2;
				thread_data_2.function = f2;
				if (thread_data_2.current_value == 0) {
					thread_data_2.current_value = (3 * PI) / 2;
				}

				calc_thread_2 = CreateThread(NULL, 0, CalculationThread, &thread_data_2, 0, NULL);
				if (calc_thread_2 == 0)
				{
					MessageBox(NULL, _T("Ошибка при создании второго потока!"), title, MB_ICONERROR | MB_OK);
					return 0;
				}

				break;
			case STOP_SIN:
				ChangeCheckbox(START_SIN, false);
				ChangeCheckbox(STOP_SIN, true);
				thread_data_2.isRunning = false;
				break;
			}
		}
		return 0;
	// Нужно перерисовать окно:
	case WM_PAINT:
		{
			// Получим размеры клиентской области (области окна, не принадлежащей рамке или меню).
			RECT s;
			GetClientRect(hWnd, &s);
			// Начнём рисование.
			PAINTSTRUCT ps;
			HDC hdc = BeginPaint(hWnd, &ps);
			// Зальём фон белым цветом.
			SelectObject(hdc, GetStockObject(WHITE_BRUSH));
			Rectangle(hdc, 0, 0, s.right, s.bottom);
			if (state != FINISHED)
			{
				// Нарисуем текст с помощью вынесенной функции DrawCentered, реализация которой приведена в проекте Common.
				DrawCentered(hdc, font, s.right, s.bottom, strings[state]);
			}
			else
			{
				WORD textSize;
				TCHAR textBuffer[32];
				textSize = wsprintf(textBuffer, TEXT("Данные отправлены: %d раз(а)"), dataSend);
				TextOut(hdc, 5, s.bottom - 20, textBuffer, textSize);

				DrawCentered(hdc, font, s.right, s.bottom, textBuffer);
			}
			EndPaint(hWnd, &ps);
		}
		return 0;
	// Изменился размер окна:
	case WM_SIZE:
		InvalidateRect(window, NULL, FALSE);
		UpdateWindow(hWnd);
		return 0;
	case WM_ERASEBKGND:
		return TRUE;
	}
	return DefWindowProc(hWnd, msg, wParam, lParam);
}

// Код вычисляющего потока.
DWORD WINAPI CalculationThread(LPVOID thread_data)
{
	ThreadData* data = (ThreadData*)thread_data;
	// Вычисляем значения функции.
	//for (double x = calculate_from; x < calculate_to; x += calculate_step)
	while (data->isRunning)
	{
		double d = data->function(data->current_value);
		unsigned int numth = data->numThread;

		EnterCriticalSection(&critsect);
		if (send(client_socket, (char*)&numth, sizeof(int), 0) == SOCKET_ERROR)
		{
			MessageBox(NULL, _T("Ошибка передачи потока."), title, MB_ICONERROR | MB_OK);
			closesocket(client_socket);
			WSACleanup();
			SendError();
			return 1;
		}
		if (send(client_socket, (char*)&d, sizeof(double), 0) == SOCKET_ERROR)
		{
			MessageBox(NULL, _T("Ошибка передачи данных."), title, MB_ICONERROR | MB_OK);
			closesocket(client_socket);
			WSACleanup();
			SendError();
			return 1;
		}
		Sleep(100);
		LeaveCriticalSection(&critsect);

		data->current_value  += calculate_step;
	}

	return 0;
}

void MenuError()
{
	int error_code = GetLastError();
	MessageBox(NULL, _T("Ошибка при заполнении меню!"), title, 0);
	// Завершить программу с кодом error_code:
	ExitProcess(error_code);
}

// Обработчик сообщений диалогового окна, которое даёт пользователю возможность указать
// IP-адрес сервера.
BOOL CALLBACK ConnectDlgProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	// Пользователь закрывает диалог или нажимает кнопку OK:
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDC_OK:
			// Запомним IP-адрес в глобальной переменной server_ip с помощью
			// GetDlgItemText(). Так как server_ip объявлена как однобайтовая строка
			// (только такие строки подходят для WinSock), будем явно вызывать однобайтовую версию этого метода - GetDlgItemTextA().
			// Вообще, все методы WinAPI, работающие со строками, существуют в двух
			// версиях - однобайтовой и двухбайтовой (заканчивающиеся на A и W,
			// соответственно). Например, есть MessageBoxA, а есть MessageBoxW.
			// MessageBox (без A/W приставки) - это на самом деле не функция, а макрос
			// (define), определённый как MessageBoxA или MessageBoxW, в зависимости от настроек компиляции.
			// IDC_IP - идентификатор поля ввода, указанный в ресурсах.
			if (!GetDlgItemTextA(hWnd, IDC_IP, server_ip, sizeof(server_ip)))
			{
				MessageBox(NULL, _T("Пожалуйста, введите IP-адрес."), title, MB_ICONERROR | MB_OK);
				return TRUE;
			}
			// Если же всё прошло нормально, закроем диалог с кодом возврата 1.
			// Код возврата диалога будет передан в главное окно, и таким образом
			// обработчик событий главного окна сможет понять, чем закончилось выполнение диалога.
			// У нас 1 будет означать, что пользователь ввёл IP-адрес и нажал OK, 0 - что он просто закрыл диалог.

			if (strcmp(server_ip, "localhost") == 0) {
				strcpy(server_ip, "127.0.0.10\0");
			}

			EndDialog(hWnd, 1);
			return TRUE;
		case IDCANCEL:
			EndDialog(hWnd, 0);
			return TRUE;
		}
	}
	return FALSE;
}

void InitTrayIcon()
{
	NOTIFYICONDATA nid = {};
	nid.cbSize = sizeof(NOTIFYICONDATA);
	nid.hWnd = window;
	nid.uID = 1;
	nid.uFlags = NIF_MESSAGE | NIF_TIP | NIF_ICON;
	nid.uCallbackMessage = WM_TRAY;
	_tcscpy(nid.szTip, title);
	nid.hIcon = LoadIcon((HINSTANCE)GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_FICON));
	if (!Shell_NotifyIcon(NIM_ADD, &nid))
	{
		MessageBox(NULL, _T("Ошибка при создании иконки в панели уведомлений."), title, MB_ICONERROR);
		ExitProcess(GetLastError());
	}
}

void DestroyTrayIcon()
{
	NOTIFYICONDATA nid = {};
	nid.cbSize = sizeof(NOTIFYICONDATA);
	nid.hWnd = window;
	nid.uID = 1;
	if (!Shell_NotifyIcon(NIM_DELETE, &nid))
	{
		MessageBox(NULL, _T("Ошибка при удалении иконки."), title, MB_ICONERROR);
	}
}

void InitHooks()
{
	hook = SetWindowsHookEx(WH_KEYBOARD_LL, Hook, GetModuleHandle(NULL), 0);
	if (!hook)
	{
		MessageBox(NULL, _T("Ошибка при создании хука клавиатуры."), title, NULL);
	}
}

LRESULT CALLBACK Hook(int code, WPARAM wParam, LPARAM lParam)
{
	// В wParam содержится тип сообщения (WM_KEYUP или WM_KEYDOWN),
	// в lParam - указатель на структуру KBDLLHOOKSTRUCT, содержащую остальную информацию о произошедшем событии.
	LPKBDLLHOOKSTRUCT l = (LPKBDLLHOOKSTRUCT)lParam;
	if (wParam == WM_KEYDOWN)
	{
		if (l->vkCode == 'A' && GetAsyncKeyState(VK_CONTROL) & 0x8000)
		{
			if (thread_data_1.isRunning) {
				SendMessage(window, WM_COMMAND, MAKEWPARAM(STOP_COS, 0), 0);
			} else {
				SendMessage(window, WM_COMMAND, MAKEWPARAM(START_COS, 0), 0);
			}
		}
		if (l->vkCode == 'B' && GetKeyState(VK_CONTROL) & 0x8000)
		{
			//ShowWindow(window, SW_MINIMIZE);
			//ShowWindow(window, SW_RESTORE);
			if (thread_data_2.isRunning) {
				SendMessage(window, WM_COMMAND, MAKEWPARAM(STOP_SIN, 0), 0);
			} else {
				SendMessage(window, WM_COMMAND, MAKEWPARAM(START_SIN, 0), 0);
			}
		}
		if (l->vkCode == 'N' && GetKeyState(VK_CONTROL) & 0x8000)
		{
			SendMessage(window, WM_COMMAND, 1, 0);
			HWND server_window = FindWindow(_T("Server_Graph"), NULL);
			ShowWindow(server_window, SW_MINIMIZE);
			ShowWindow(server_window, SW_RESTORE);
		}
	}

	// Передадим перехваченное сообщение дальше.
	return CallNextHookEx(NULL, code, wParam, lParam);
}

void SendError()
{
	SendMessage(window, WM_ERROR, 0, 0);
}

void ChangeCheckbox(UINT item, bool checked)
{
	MENUITEMINFO mii;
	ZeroMemory(&mii, sizeof(MENUITEMINFO));
	mii.cbSize = sizeof(MENUITEMINFO);
	mii.fMask = MIIM_STATE;
	mii.fState = checked ? MFS_CHECKED : MFS_UNCHECKED;
	if (!SetMenuItemInfo(hMenu, item, FALSE, &mii))
	{
		MessageBox(NULL, title, title, NULL);
	}
}

// Код сетевого потока.
DWORD WINAPI NetworkThread(LPVOID)
{
	// Инициализируем WinSock.
	WSADATA wsaData;
	int result;
	if (WSAStartup(MAKEWORD(2, 2), &wsaData))
	{
		MessageBox(NULL, _T("Ошибка инициализации WinSock."), title, MB_ICONERROR | MB_OK);
		SendError();
		return 1;
	}

	// Откроем клиентский сокет.
	struct addrinfo *res = NULL, *ptr = NULL, hints;
	// Заполним структуру hints, содержащую параметры клиентского сокета.
	ZeroMemory(&hints, sizeof(hints));
	// Адресная семья (для клиентского сокета можно не указывать).
	hints.ai_family = AF_INET;
	// Тип сокета.
	hints.ai_socktype = SOCK_STREAM;
	// Протокол сокета (IPPROTO_TCP для TCP, IPPROTO_UDP для UDP, IPPROTO_PGM для PGM).
	hints.ai_protocol = IPPROTO_TCP;

	// Преобразуем строковое название порта в структуру res.
	// Обратите внимание, что вне зависимости от настроек компиляции номер порта (9999)
	// и адрес сервера передаются однобайтовой строкой.
	result = getaddrinfo(server_ip, "9999", &hints, &res);
	if (result != 0)
	{
		MessageBox(NULL, _T("Ошибка преобразования порта."), title, MB_ICONERROR | MB_OK);
		WSACleanup();
		SendError();
		return 1;
	}
	// Создаём сокет.
	client_socket = socket(res->ai_family, res->ai_socktype, res->ai_protocol);
	if (client_socket == INVALID_SOCKET)
	{
		MessageBox(NULL, _T("Ошибка создания сокета."), title, MB_ICONERROR | MB_OK);
		freeaddrinfo(res);
		WSACleanup();
		SendError();
		return 1;
	}

	// После создания клиентский сокет необходимо подключить (connect) к серверу.
	result = connect(client_socket, res->ai_addr, (int)res->ai_addrlen);
	if (result == SOCKET_ERROR || client_socket == INVALID_SOCKET)
	{
		MessageBox(NULL, _T("Невозможно подключиться к серверу."), title, MB_ICONERROR | MB_OK);
		freeaddrinfo(res);
		WSACleanup();
		SendError();
		return 1;
	}

	// После вызова connect() переменная res нам больше не нужна.
	freeaddrinfo(res);
	res = NULL;

	// Уведомляем окно о том, что подключение к серверу завершено.ё
	SendMessage(window, WM_CONNECTED, 0, 0);

	// Теперь мы можем передавать и принимать данные, используя клиентский сокет.
	while (isSession)
	{
		///
	}

	// Отключаемся.
	result = shutdown(client_socket, SD_RECEIVE);
	if (result == SOCKET_ERROR)
	{
		MessageBox(NULL, _T("Ошибка выключения клиентского сокета."), title, MB_ICONERROR | MB_OK);
		closesocket(client_socket);
		WSACleanup();
		SendError();
		return 1;
	}
	result = closesocket(client_socket);
	if (result == SOCKET_ERROR)
	{
		MessageBox(NULL, _T("Ошибка закрытия клиентского сокета."), title, MB_ICONERROR | MB_OK);
		WSACleanup();
		SendError();
		return 1;
	}

	WSACleanup();

	SendMessage(window, WM_FINISHED, 0, 0);

	return 0;
}

// Заливает контекст устройства hdc белым цветом, а затем рисует заданный текст посередине. hdc должен иметь ширину w и высоту h.
void DrawCentered(HDC hdc, HFONT font, int w, int h, const WCHAR* text)
{
	// Текст будет выводиться с помощью GDI+. Зальём фон нужным цветом с помощью GDI+.
	// Главный класс для рисования в GDI+ - это Graphics.
	// Этот класс позволяет выводить на контекст устройства линии, кривые, геометрические фигуры, изображения и текст. Всё, что для этого нужно - связать объект класса
	// Graphics с нужным контекстом устройства, и при вызове методов Graphics результат их выполнения будет выводиться на этот контекст.
	Gdiplus::Graphics g(hdc);

	// Кисти (brush) в GDI+ определяют цвет и заливку рисуемых объектов. Эта кисть будет использоваться для закраски hdc сплошным белым цветом.
	Gdiplus::SolidBrush background_brush(Gdiplus::Color::White);
	g.FillRectangle(&background_brush, 0, 0, w, h);

	// А эта - для вывода текста сплошным чёрным цветом.
	Gdiplus::SolidBrush text_brush(Gdiplus::Color::Black);
	// Определим прямоугольник расположения текста (layout rectangle).
	// Он будет занимать весь предоставленный размер, сам же текст будет выводиться посередине этого прямоугольника.
	Gdiplus::RectF rect(0, 0, w, h);
	// Шрифт для вывода текста.
	Gdiplus::Font f(hdc, font);
	// Объект класса StringFormat определяет, как именно будет выведен текст относительно прямоугольника расположения.
	Gdiplus::StringFormat format;
	// В нашем случае, текст будет выводиться по центру - как по горизонтали, так и по
	// вертикали.
	format.SetAlignment(Gdiplus::StringAlignmentCenter);
	format.SetLineAlignment(Gdiplus::StringAlignmentCenter);
	// Если же строка окажется шире прямоугольника расположения, будем делать перенос по словам.
	format.SetTrimming(Gdiplus::StringTrimmingWord);
	// Рисуем строку.
	g.DrawString(text, -1, &f, rect, &format, &text_brush);
}