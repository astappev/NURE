// WinAPI_1.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "WinAPI_1.h"

#define MAX_LOADSTRING 100
#define IDM_MYMENURESOURCE 5

// Глобальные переменные:
HINSTANCE hInst;								// Указатель приложения
TCHAR szTitle[] = _T("Лабораторная WIN API");	// The title bar text
TCHAR szWindowClass[] = _T("Oleg");			// the main window class name

// Предварительное описание функций:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

// Основная программа 
int APIENTRY _tWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPTSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_MENU, szWindowClass, MAX_LOADSTRING);
	// Регистрация класса окна 
	MyRegisterClass(hInstance);

	// Создание окна приложения:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MENU));

	// Цикл обработки сообщений:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}

//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Регистрирует класс окна.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW; 	// стиль окна
	wcex.lpfnWndProc	= WndProc; // оконная процедура
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance; // указатель приложения
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW); // определение курсора
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1); // установка фона
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_MENU); // определение меню
	wcex.lpszClassName	= szWindowClass; // имя класса
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_APPLICATION)); // определение иконки в панели windows
	wcex.hIconSm		= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_APPLICATION)); // определение иконки окна

	return RegisterClassEx(&wcex); // регистрация класса окна
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        Создает окно приложения и сохраняет указатель приложения в переменной hInst
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // сохраняет указатель приложения в переменной hInst

   hWnd = CreateWindow(szWindowClass, szTitle, WS_BORDER|WS_OVERLAPPEDWINDOW, // имя класса окна, имя приложения, стиль окна
	   CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, // положение по Х, положение по Y, размер по Х, размер по Y
	  NULL, NULL, hInstance, NULL); // описатель родительского окна, описатель меню окна, указатель приложения, параметры создания

   if (!hWnd) // Если окно не создалось, функция возвращает FALSE
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow); // Показать окно
   UpdateWindow(hWnd); // Обновить окно

   return TRUE; //Успешное завершение функции
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Оконная процедура. Принимает и обрабатывает все сообщения, приходящие в приложение
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HANDLE hIco;
	HDC hdc;
	TCHAR text[] = _T("Астаппев Олег");
	TCHAR text2[] = _T("ИНФ-12-1");

	switch (message)
	{
	/*
	1 Написать программу, которая следит за перемещением указателя мыши и выводит его координаты в окне приложения.
	Если при выходе за окно правая кнопка мыши нажата, программа продолжает следить за перемещением мыши и выводить ее координаты.
	*/
	case WM_RBUTTONDOWN:
		POINT cursor;
		if (GetCursorPos(&cursor))
		{
			SetCapture(hWnd);
		}
		break;
	case WM_RBUTTONUP:
		ReleaseCapture();
		break;
	case WM_MOUSEMOVE:
		{
			hdc = GetDC(hWnd);
			POINT cursor;
			WORD textSize;
			TCHAR textBuffer[32];

			GetCursorPos(&cursor);
			ScreenToClient(hWnd, &cursor);

			textSize = wsprintf(textBuffer, TEXT("(%d, %d)"), cursor.x, cursor.y);

			TextOut(hdc, 920, 440, _T("                         "), strlen("                         "));
			//InvalidateRect(hWnd, NULL, TRUE);
			TextOut(hdc, 920, 440, textBuffer, textSize);

			ReleaseDC(hWnd, hdc);
		}
		break;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		case IDM_PERL:
			hIco = LoadImage(hInst, MAKEINTRESOURCE(IDI_PERLICON), IMAGE_ICON, 48, 48, LR_DEFAULTCOLOR);
			SetClassLong(hWnd, GCLP_HICON, (LONG)hIco);
			SetClassLong(hWnd, GCLP_HICONSM, (LONG)hIco);
			break;
		case IDM_PYTHON:
			hIco = LoadImage(hInst, MAKEINTRESOURCE(IDI_PYTHONICON), IMAGE_ICON, 48, 48, LR_DEFAULTCOLOR);
			SetClassLong(hWnd, GCLP_HICON, (LONG)hIco);
			SetClassLong(hWnd, GCLP_HICONSM, (LONG)hIco);
			break;
		case IDM_RUBY:
			hIco = LoadImage(hInst, MAKEINTRESOURCE(IDI_RUBYICON), IMAGE_ICON, 48, 48, LR_DEFAULTCOLOR);
			SetClassLong(hWnd, GCLP_HICON, (LONG)hIco);
			SetClassLong(hWnd, GCLP_HICONSM, (LONG)hIco);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT: // Перерисовать окно
		hdc = BeginPaint(hWnd, &ps); // Начать графический вывод
		
		TextOut(hdc, 5, 5, text, _tcslen(text));
		TextOut(hdc, 5, 24, text2, _tcslen(text2));

		EndPaint(hWnd, &ps); // Закончить графический вывод
		break;
	case WM_DESTROY: // Завершение работы
		PostQuitMessage(0);
		break;
	default:
		// Обработка сообщений, которые не обработаны пользователем
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}