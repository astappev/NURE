// Не включать ничего лишнего в библиотеках Windows.h.
// В частности, не включать Winsock, так как мы будем использовать Winsock2, а Winsock и Winsock2 конфликтуют друг с другом.
#define WIN32_LEAN_AND_MEAN
#define _USE_MATH_DEFINES
// Объявим макросы WINVER и _WIN32_WINNT, указывающие, на какую версию Windows
// рассчитана наша программа. 0x0501 означает, что программа будет работать под Windows XP и выше.
#define WINVER 0x0501
#define _WIN32_WINNT 0x0501

// Заголовки большинства функций WinAPI.
#include <Windows.h>
#include <WindowsX.h>
#include <ShellAPI.h>
// Заголовки библиотеки WinSock2.
#include <WinSock2.h>
#include <WS2tcpip.h>
// tchar.h содержит макрос _T() и тип данных TCHAR.
#include <tchar.h>
// Заголовки GDI+.
#include <ObjIdl.h>
#include <GdiPlus.h>
#include <algorithm>
#include <vector>
using std::vector;

// WinSock2 и GDI+.
#pragma comment(lib, "Ws2_32.lib")
#pragma comment(lib, "Gdiplus.lib")

// Для того, чтобы не конфликтовать с уже существующими типами Windows-сообщений,
// пользовательские типы сообщений должны объявляться как WM_USER + x, где x - целое неотрицательное число.
#define WM_ERROR        WM_USER
#define WM_CONNECTED    WM_USER + 1
#define WM_FINISHED     WM_USER + 2
#define WM_SOCKET_READY WM_USER + 3

DWORD WINAPI NetworkThread(LPVOID);
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
int recv_all(SOCKET s, char* buf, int len);

// Сохраняет количество значений в реестре.
void InitRegistry();
bool SaveCountInRegistry();
// Заливает контекст устройства hdc белым цветом, а затем рисует заданный текст
// посередине. hdc должен иметь ширину w и высоту h.
// Перед вызовом функции должен быть проинициализирован GDI+.
void DrawCentered(HDC hdc, HFONT font, int w, int h, const WCHAR* text);

const TCHAR* title = _T("Лабораторная работа 29: сервер");
const TCHAR* strings[] = {
	_T("Инициализация сокета..."),
	_T("Ожидание подключения к серверу..."),
	_T("Клиент подключён, идёт передача данных..."),
	NULL,
	_T("Произошла ошибка!")};
enum State
{
	INIT,
	WAITING,
	CONNECTED,
	DRAWING,
	ERR
};

vector<double> data1, data2;
HFONT font = (HFONT)GetStockObject(DEFAULT_GUI_FONT);
HANDLE network_thread = 0;
HWND window = 0;
const int width = 500;
const int height = 300;
int currentCounts = 0, f1_counts = 0, f2_counts = 0;
int preventCounts = 0, preventF1Counts = 0, preventF2Counts = 0;
bool isDraw = false;
ULONG_PTR gdi_token;

// Точка входа оконного приложения.
// Windows передаст в эту функцию четыре параметра, большинство из которых нам не нужны,
// поэтому мы пропустим имена ненужных параметров.
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE, LPSTR, int)
{
	// Инициализируем GDI+.
	Gdiplus::GdiplusStartupInput gdi_input;
	if (GdiplusStartup(&gdi_token, &gdi_input, NULL) != Gdiplus::Ok)
	{
		MessageBox(NULL, _T("Ошибка инициализации GDI+."), title, MB_ICONERROR | MB_OK);
		return 1;
	}

	InitRegistry();

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
	// уникален для каждого запущенного экземпляра приложения, что позволяет идентифицировать их.
	// Даже разные экземпляры одного приложения, запущенные одновременно, будут иметь разные дескрипторы.
	// Windows передаёт этот дескриптор как первый параметр функции WinMain;
	// у нас он назван hInstance (так же, как и поле).
	wcex.hInstance = hInstance;
	// hCursor: дескриптор на картинку указателя мыши, которая будет использована тогда,
	// когда указатель будет находиться над окном.
	// Лучше не сбивать пользователя с толку и выставить стандартный курсор-стрелку.
	// Чтобы получить дескриптор стрелки, воспользуемся LoadCursor.
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	// hbrBackground: дескриптор кисти фона окна. Этой кистью будет закрашено окно при
	// перерисовке. Кисть определяет цвет и узор закрашивания.
	wcex.hbrBackground = (HBRUSH)COLOR_WINDOWFRAME;
	// lpszClassName: имя класса, которое после регистрирования класса будет использовано
	// для обращения к этому классу.
	wcex.lpszClassName = _T("Server_Graph");
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
		_T("Server_Graph"),
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
		// декскриптор меню окна (у этого окна не будет меню)
		NULL,
		// декскриптор текущего экземпляра приложения
		hInstance,
		// значение, которое будет передано окну после создания (нам это не нужно)
		NULL
	);
	if (!window)
	{
		DWORD err = GetLastError();
		MessageBox(NULL, _T("Ошибка при создании окна!"), title, MB_ICONERROR | MB_OK);
		return err;
	}

	// После создания окна его нужно перерисовать.
	UpdateWindow(window);

	// Запустим сетевой поток.
	network_thread = CreateThread(NULL, 0, NetworkThread, NULL, 0, NULL);
	if (!network_thread)
	{
		MessageBox(NULL, _T("Ошибка при запуске сетевого потока!"), title, MB_ICONERROR | MB_OK);
		return 1;
	}

	// Итак, окно создано и готово принимать сообщения.
	// Каждое сообщение хранится в структуре типа MSG.
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
	return 0;

}

void InitRegistry()
{
	HKEY key;
	DWORD dword_type = RRF_RT_REG_DWORD;
	DWORD binary_type = RRF_RT_REG_BINARY;
	DWORD dword_size = sizeof(DWORD);
	DWORD greal_size = sizeof(Gdiplus::REAL);
	LONG result = RegOpenKeyEx(HKEY_CURRENT_USER, _T("Software\\NURE_LABS_OS\\V29a"), 0, KEY_ALL_ACCESS, &key);
	if (result == ERROR_SUCCESS)
	{
		DWORD value;
		result = RegQueryValueEx(key, _T("count"), NULL, &dword_type, (LPBYTE)&value, &dword_size);
		if (result == ERROR_FILE_NOT_FOUND)
		{
			SaveCountInRegistry();
		}
		else if (result == ERROR_SUCCESS)
		{
			if (value <= 10000)
			{
				preventCounts = value;
			}
		}
		else
		{
			MessageBox(NULL, _T("Ошибка при работе с реестром."), title, MB_ICONERROR | MB_OK);
			return;
		}

		DWORD f1_count;
		result = RegQueryValueEx(key, _T("f1_count"), NULL, &dword_type, (LPBYTE)&f1_count, &dword_size);
		if (result == ERROR_FILE_NOT_FOUND)
		{
			SaveCountInRegistry();
		}
		else if (result == ERROR_SUCCESS)
		{
			if (f1_count <= 10000)
			{
				preventF1Counts = f1_count;
			}
		}
		else
		{
			MessageBox(NULL, _T("Ошибка при работе с реестром."), title, MB_ICONERROR | MB_OK);
			return;
		}

		DWORD f2_count;
		result = RegQueryValueEx(key, _T("f2_count"), NULL, &dword_type, (LPBYTE)&f2_count, &dword_size);
		if (result == ERROR_FILE_NOT_FOUND)
		{
			SaveCountInRegistry();
		}
		else if (result == ERROR_SUCCESS)
		{
			if (f2_count <= 10000)
			{
				preventF2Counts = f2_count;
			}
		}
		else
		{
			MessageBox(NULL, _T("Ошибка при работе с реестром."), title, MB_ICONERROR | MB_OK);
			return;
		}
	}
	else if (result == ERROR_FILE_NOT_FOUND)
	{
		// Ключ не существует. Создадим и заполним его.
		MessageBox(NULL, _T("Параметры в реестре не найдены, они будут установлены."), title, MB_ICONWARNING | MB_OK);

		result = RegCreateKeyEx(HKEY_CURRENT_USER, _T("Software\\NURE_LABS_OS\\V29a"), 0, NULL, REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, NULL, &key, NULL);
		if (result != ERROR_SUCCESS)
		{
			// Неудача при работе с реестром не будет препятствием для работы приложения, так как все значения инициализируются по умолчанию в самом начале его работы.
			MessageBox(NULL, _T("Ошибка при создании ключа реестра."), title, MB_ICONERROR | MB_OK);
			return;
		}

		if (!SaveCountInRegistry()) return;
	}
	else {
		MessageBox(NULL, _T("Ошибка при обращении к ключу реестра."), title, MB_ICONERROR | MB_OK);
	}
}

bool SaveCountInRegistry()
{
	DWORD count = currentCounts;
	DWORD f1_count = f1_counts;
	DWORD f2_count = f2_counts;
	HKEY key;
	if (RegOpenKeyEx(HKEY_CURRENT_USER, _T("Software\\NURE_LABS_OS\\V29a"), 0, KEY_ALL_ACCESS, &key) != ERROR_SUCCESS)
	{
		MessageBox(NULL, _T("Ошибка при открытии ключа."), title, MB_ICONERROR | MB_OK);
		RegCloseKey(key);
		return false;
	}
	if (RegSetValueEx(key, _T("count"), 0, RRF_RT_REG_DWORD, (BYTE*)&count, sizeof(DWORD)) != ERROR_SUCCESS)
	{
		MessageBox(NULL, _T("Ошибка при записи значения count."), title, MB_ICONERROR | MB_OK);
		RegCloseKey(key);
		return false;
	}
	if (RegSetValueEx(key, _T("f1_count"), 0, RRF_RT_REG_DWORD, (BYTE*)&f1_count, sizeof(DWORD)) != ERROR_SUCCESS)
	{
		MessageBox(NULL, _T("Ошибка при записи значения f1_count."), title, MB_ICONERROR | MB_OK);
		RegCloseKey(key);
		return false;
	}
	if (RegSetValueEx(key, _T("f2_count"), 0, RRF_RT_REG_DWORD, (BYTE*)&f2_count, sizeof(DWORD)) != ERROR_SUCCESS)
	{
		MessageBox(NULL, _T("Ошибка при записи значения f2_count."), title, MB_ICONERROR | MB_OK);
		RegCloseKey(key);
		return false;
	}
	RegCloseKey(key);
	return true;
}

// Обработчик сообщений главного окна. Вызывается для каждого сообщения.
// Вся информация о сообщении занесена в аргументах функции:
// hWnd - дескриптор окна, которое получило это сообщение;
// msg - тип сообщения;
// wParam и lParam - числа с дополнительной информацией о сообщении;
// их смысл различен для каждого типа сообщения.
// Эта функция не обязательно должна называться WndProc (в отличие от WinMain),
// это просто наиблоее часто встречающееся название в примерах по WinAPI.
LRESULT CALLBACK WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static State state = INIT;
	static int view_x = 0, view_y = 0;
	static double view_zoom = 5;
	static int mouse_x = 0, mouse_y = 0;
	static bool mouse_pressed = false;
	switch (msg)
	{
	// Пользователь закрывает окно:
	case WM_DESTROY:
		// Остановим все потоки, если они запущены.
		// Процесс приложения не завершится, пока не завершатся все его потоки.
		if (network_thread != 0)
			TerminateThread(network_thread, 0);
		// Посылаем себе сообщение WM_QUIT. Это означает, что мы готовы закрыть окно.
		PostQuitMessage(0);
		return 0;
	// Сетевой поток прислал сообщение об ошибке:
	case WM_ERROR:
		state = ERR;
		InvalidateRect(hWnd, NULL, FALSE);
		UpdateWindow(hWnd);
		return 0;
	// Сокет проинициализирован и ждёт подключения клиента:
	case WM_SOCKET_READY:
		state = WAITING;
		InvalidateRect(hWnd, NULL, FALSE);
		UpdateWindow(hWnd);
		return 0;
	// К серверу успешно подключился клиент, идёт передача данных:
	case WM_CONNECTED:
		isDraw = false;
		state = CONNECTED;
		InvalidateRect(hWnd, NULL, FALSE);
		UpdateWindow(hWnd);
		return 0;
	// Передача данных завершена:
	case WM_FINISHED:
		state = DRAWING;
		// Перерисуем окно, чтобы на нём появился график значений.
		InvalidateRect(hWnd, NULL, FALSE);
		UpdateWindow(hWnd);
		return 0;
	// Нужно перерисовать окно:
	case WM_PAINT:
		{
			RECT s;
			GetClientRect(hWnd, &s);
			PAINTSTRUCT ps;
			HDC hdc = BeginPaint(hWnd, &ps);
			WORD textSize;
			TCHAR textBuffer[32];

			// Если нужно нарисовать график:
			if (state == DRAWING || (!data1.empty() || !data2.empty()))
			{
				isDraw = true;

				SelectObject(hdc, GetStockObject(WHITE_BRUSH));
				Rectangle(hdc, 0, 0, s.right, s.bottom);

				// Выводим график.
				Gdiplus::Graphics g(hdc);

				Gdiplus::SolidBrush br1(Gdiplus::Color::Red);
				Gdiplus::Pen p1(&br1, 1.5);
				Gdiplus::REAL dashVals[4] = { 5.0f, 2.0f, 15.0f, 4.0f };
				p1.SetDashPattern(dashVals, 4);
				Gdiplus::SolidBrush br2(Gdiplus::Color::Blue);
				Gdiplus::Pen p2(&br2, 1.5);
				Gdiplus::SolidBrush br3(Gdiplus::Color::Black);
				Gdiplus::Pen p3(&br3, 2.0);

				g.DrawLine(&p3, (Gdiplus::REAL)0, (Gdiplus::REAL)s.bottom / 2, (Gdiplus::REAL)s.right, (Gdiplus::REAL)s.bottom / 2);

				int size1 = data1.size();
				int size2 = data2.size();

				Gdiplus::REAL step = s.right / (Gdiplus::REAL)(size1 > size2 ? size1 : size2), start = s.bottom / 2, finish = 20;

				int max1 = 0, max2 = 0;
				if(size1 > 0) max1 = *std::max_element(data1.begin(), data1.end());
				if(size2 > 0) max2 = *std::max_element(data2.begin(), data2.end());
				int max = max1 > max2 ? max1 : max2;

				int size1mas = size1 - 1;
				for (int i = 0; i < size1mas; i++)
				{
					Gdiplus::PointF pos1 = Gdiplus::PointF(step * (i + 0.5), start - (start - finish) / max * data1[i]);
					Gdiplus::PointF pos2 = Gdiplus::PointF(step * (i + 1.5), start - (start - finish) / max * data1[i + 1]);
					g.DrawLine(&p1, pos1, pos2);
				}
				
				int size2mas = size2 - 1;
				for (int i = 0; i < size2mas; i++)
				{
					Gdiplus::PointF pos1 = Gdiplus::PointF(step * (i + 0.5), start - (start - finish) / max * data2[i]);
					Gdiplus::PointF pos2 = Gdiplus::PointF(step * (i + 1.5), start - (start - finish) / max * data2[i + 1]);
					g.DrawLine(&p2, pos1, pos2);
				}

				if (currentCounts == 0) {
					textSize = wsprintf(textBuffer, TEXT("Идет передача"));
				}
				else {
					textSize = wsprintf(textBuffer, TEXT("Текущая сессия: %d (%d, %d)"), currentCounts, f1_counts, f2_counts);
				}
				
				TextOut(hdc, 5, 5, textBuffer, textSize);
				textSize = wsprintf(textBuffer, TEXT("Прошлая сессия: %d (%d, %d)"), preventCounts, preventF1Counts, preventF2Counts);
				TextOut(hdc, 5, s.bottom - 20, textBuffer, textSize);

				/*textSize = wsprintf(textBuffer, TEXT("%d"), data2->GetValues()[0]);
				TextOut(hdc, 3, s.bottom / 2 + 2, textBuffer, textSize);
				textSize = wsprintf(textBuffer, TEXT("%d"), data2->GetValues()[data2->GetValues().size() - 1]);
				TextOut(hdc, s.right - 20, s.bottom / 2 + 2, textBuffer, textSize);*/
			} else if (!isDraw) {
				SelectObject(hdc, GetStockObject(WHITE_BRUSH));
				Rectangle(hdc, 0, 0, s.right, s.bottom);
				// Нарисуем текст с помощью вынесенной функции PaintCenetered, реализация которой приведена в проекте Common.
				DrawCentered(hdc, font, s.right, s.bottom, strings[state]);
				textSize = wsprintf(textBuffer, TEXT("Прошлая сессия: %d (%d, %d)"), preventCounts, preventF1Counts, preventF2Counts);
				TextOut(hdc, 5, s.bottom - 20, textBuffer, textSize);
			}

			EndPaint(hWnd, &ps);
		}
		return 0;
	// Изменился размер окна:
	case WM_SIZE:
		InvalidateRect(hWnd, NULL, FALSE);
		return 0;
	case WM_ERASEBKGND:
		return TRUE;
	}
	return DefWindowProc(hWnd, msg, wParam, lParam);
}

Gdiplus::PointF PlotToWindow(double x_, double y_, double x, double y, double w,
	double h, double u)
{
	return Gdiplus::PointF((x_ - x) * u + w / 2, (y - y_) * u + h / 2);
}

void SendError()
{
	SendMessage(window, WM_ERROR, 0, 0);
}

// Код сетевого потока.
DWORD WINAPI NetworkThread(LPVOID)
{
	// Инициализируем WinSock.
	WSADATA wsaData;
	int result = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (result != 0)
	{
		MessageBox(NULL, _T("Ошибка инициализации WinSock."), title, MB_ICONERROR | MB_OK);
		SendError();
		return 1;
	}

	// Откроем серверный сокет.
	struct addrinfo *res = NULL, *ptr = NULL, hints;
	// Заполним структуру hints, содержащую параметры серверного сокета.
	ZeroMemory(&hints, sizeof(hints));
	// Адресная семья (AF_INET для IPv4, AF_INET6 для IPv6).
	hints.ai_family = AF_INET;
	// Тип сокета.
	hints.ai_socktype = SOCK_STREAM;
	// Протокол сокета (IPPROTO_TCP для TCP, IPPROTO_UDP для UDP, IPPROTO_PGM для PGM).
	hints.ai_protocol = IPPROTO_TCP;
	// Флаги. AI_PASSIVE обозначает серверный сокет.
	hints.ai_flags = AI_PASSIVE;

	// Преобразуем строковое название порта в структуру res.
	// Обратите внимание, что вне зависимости от настроек компиляции номер порта (9999) и адрес сервера (здесь NULL) передаются однобайтовой строкой.
	result = getaddrinfo(NULL, "9999", &hints, &res);
	if (result != 0)
	{
		MessageBox(NULL, _T("Ошибка преобразования порта."), title, MB_ICONERROR | MB_OK);
		WSACleanup();
		SendError();
		return 1;
	}
	// Создаём сокет.
	SOCKET listen_socket = socket(res->ai_family, res->ai_socktype, res->ai_protocol);
	if (listen_socket == INVALID_SOCKET)
	{
		MessageBox(NULL, _T("Ошибка создания сокета."), title, MB_ICONERROR | MB_OK);
		freeaddrinfo(res);
		WSACleanup();
		SendError();
		return 1;
	}

	// После создания серверный сокет необходимо привязать (bind), чтобы он мог принимать входящие подключения.
	result = bind(listen_socket, res->ai_addr, (int)res->ai_addrlen);
	if (result == SOCKET_ERROR)
	{
		MessageBox(NULL, _T("Ошибка привязки сокета. Возможно, на этом компьютере уже запущен другой экземпляр сервера."), title, MB_ICONERROR | MB_OK);
		freeaddrinfo(res);
		closesocket(listen_socket);
		WSACleanup();
		SendError();
		return 1;
	}
	// После вызова bind() переменная res нам больше не нужна.
	freeaddrinfo(res);
	res = NULL;

	// Ловим входящие подключения.
	// Второй параметр функции listen - это максимальная длина очереди подключающихся необработанных клиентов.
	// Нам не нужна эта очередь, поэтому мы укажем здесь 0.
	// Это означает, что клиент не сможет подключиться к серверу в то время, когда сервер соединён с другим клиентом.
	result = listen(listen_socket, 0);
	if (result == SOCKET_ERROR)
	{
		MessageBox(NULL, _T("Ошибка привязки сокета. Возможно, на этом компьютере уже запущен другой экземпляр сервера."), title, MB_ICONERROR | MB_OK);
		closesocket(listen_socket);
		WSACleanup();
		SendError();
		return 1;
	}

	// Для каждого входящего подключения:
	while (true)
	{
		// Уведомляем окно о том, что сокет готов.
		SendMessage(window, WM_SOCKET_READY, 0, 0);

		// Принимаем входящее подключение.
		// При новом входящем подключении на сервере создаётся клиентский сокет, через который осуществляется передача данных.
		// Функция accept будет ждать, пока не подсоединится клиент.
		SOCKET client_socket = accept(listen_socket, NULL, NULL);
		if (client_socket == INVALID_SOCKET)
		{
			MessageBox(NULL, _T("Ошибка приёма подключения."), title, MB_ICONERROR | MB_OK);
			closesocket(listen_socket);
			WSACleanup();
			SendError();
			return 1;
		}

		// Посылаем окну сообщение о подключении клиента.
		SendMessage(window, WM_CONNECTED, 0, 0);

		data1.clear();
		data2.clear();
		
		while (true)
		{
			unsigned int numThread;
			double d;
			//recv_all(client_socket, (char*)&size1, sizeof(int)) != 0
			if (recv_all(client_socket, (char*)&numThread, sizeof(int)) != 0)
			{
				if (data1.size() > 0 || data2.size() > 0) {
					MessageBox(NULL, _T("Данные переданы."), title, MB_ICONINFORMATION | MB_OK);					
				} else {
					MessageBox(NULL, _T("Ошибка приёма данных."), title, MB_ICONERROR | MB_OK);
				}
				break;
			}
			if (recv_all(client_socket, (char*)&d, sizeof(double)) != 0)
			{
				if (data1.size() > 0 || data2.size() > 0) {
					MessageBox(NULL, _T("Данные переданы."), title, MB_ICONINFORMATION | MB_OK);
				}
				else {
					MessageBox(NULL, _T("Ошибка приёма данных."), title, MB_ICONERROR | MB_OK);
				}
				break;
			}
			if (numThread == 1)
			{
				data1.push_back(d);
			}
			else if (numThread == 2)
			{
				data2.push_back(d);
			}
			SendMessage(window, WM_FINISHED, 0, 0);
		}
		// Отключаемся от клиента. Для этого следует выключить (shutdown) и закрыть (close_socket) клиентский сокет.

		// Выключаем клиентский сокет. Это необходимо сделать перед закрытием сокета,
		// чтобы дождаться от клиента сообщения об успешном приёме данных и быть уверенным в том, что клиент полностью принял наши данные.
		result = shutdown(client_socket, SD_SEND);
		if (result == SOCKET_ERROR)
		{
			MessageBox(NULL, _T("Ошибка выключения клиентского сокета."), title, MB_ICONERROR | MB_OK);
			closesocket(listen_socket);
			WSACleanup();
			SendError();
			return 1;
		}
		// Отключаемся от клиента.
		result = closesocket(client_socket);
		if (result == SOCKET_ERROR)
		{
			MessageBox(NULL, _T("Ошибка закрытия клиентского сокета."), title, MB_ICONERROR | MB_OK);
			closesocket(listen_socket);
			WSACleanup();
			SendError();
			return 1;
		}

		if (currentCounts > 0 && currentCounts != preventCounts) preventCounts = currentCounts;
		if (f1_counts > 0 && f1_counts != preventF1Counts) preventF1Counts = f1_counts;
		if (f2_counts > 0 && f2_counts != preventF2Counts) preventF2Counts = f2_counts;
		currentCounts = data1.size() + data2.size();
		f1_counts = data1.size();
		f2_counts = data2.size();
		SaveCountInRegistry();

		// Посылаем окну сообщение о том, что можно начинать рисование графиков.
		//SendMessage(window, WM_FINISHED, 0, 0);
	}
	
	return 0;
}

int recv_all(SOCKET s, char* buf, int len)
{
	do
	{
		int read = recv(s, buf, len, 0);
		if (read == SOCKET_ERROR || read == 0)
			return SOCKET_ERROR;
		len -= read;
		buf += read;
	} while (len > 0);
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