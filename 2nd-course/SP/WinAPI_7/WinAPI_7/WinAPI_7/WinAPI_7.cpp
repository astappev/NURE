// WinAPI_7.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "WinAPI_7.h"

#define MAX_LOADSTRING 100
#define ID_TIMERch 2
#define ID_CHILDWINDOW 1000 

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name

//LPCTSTR
TCHAR lpszChild[MAX_LOADSTRING] = L"MDIChild";
HWND      hWndClient = NULL;

int peroType = 1;
COLORREF crRec = RGB(0, 0, 0);

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
ATOM                MyRegisterClassChild(HINSTANCE hInstance);

BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
LRESULT CALLBACK	ChildWndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

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
	LoadString(hInstance, IDC_WINAPI_7, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);
	MyRegisterClassChild(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_WINAPI_7));

	// Main message loop:
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
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_WINAPI_7));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_WINAPI_7);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}
ATOM MyRegisterClassChild(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = ChildWndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, lpszChild);
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = NULL;
	wcex.lpszClassName = lpszChild;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
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
	HDC hdc;

	switch (message)
	{
	case WM_CREATE:
		CLIENTCREATESTRUCT ccs;

		// Assign the 'Window' menu.
		ccs.hWindowMenu = GetSubMenu(GetMenu(hWnd), 0);
		ccs.idFirstChild = ID_CHILDWINDOW;

		// Create the client window.
		hWndClient = CreateWindowEx(WS_EX_CLIENTEDGE,
			_T("MDICLIENT"), NULL,
			WS_CHILD | WS_CLIPCHILDREN,
			0, 0, 0, 0,
			hWnd, (HMENU)0xCA0, hInst, &ccs);
		ShowWindow(hWndClient, SW_SHOW);

		break;
	case WM_SIZE:
		// Size the client window to the size of the client area of the main application window.
		MoveWindow(hWndClient, 0, 0, LOWORD(lParam), HIWORD(lParam), TRUE);

		break;
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);

		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_NEW:
			{
				HWND hWndChild;
				hWndChild = CreateMDIWindow((LPTSTR)lpszChild,
					_T("Wallpaper"), 0L,
					CW_USEDEFAULT, CW_USEDEFAULT,
					CW_USEDEFAULT, CW_USEDEFAULT,
					hWndClient, hInst, 0L);
				ShowWindow(hWndChild, SW_SHOW);
			}
			break;
		case IDM_CLOSE:
			{
				HWND hActiveWnd;

				// Close the active child window.
				hActiveWnd = (HWND)SendMessage(hWndClient, WM_MDIGETACTIVE, 0, 0);
				if (hActiveWnd)
					SendMessage(hWndClient, WM_MDIDESTROY, (WPARAM)hActiveWnd, 0);
			}
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_PERO:
			peroType = 1;
			break;
		case IDM_LINE:
			peroType = 2;
			break;
		case IDM_SQUARE:
			peroType = 3;
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

void DrowSquareChildWindow(HWND hwnd, POINT ptBeg, POINT ptEnd)
{
	HDC hdc;
	hdc = GetDC(hwnd);
	SetROP2(hdc, R2_NOT);
	SelectObject(hdc, GetStockObject(NULL_BRUSH));
	Rectangle(hdc, ptBeg.x, ptBeg.y, ptEnd.x, ptEnd.y);
	ReleaseDC(hwnd, hdc);
}

LRESULT CALLBACK ChildWndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc;                       // дескриптор контекста устройства
	RECT rcClient;                 // пр€моугольник клиентской области
	POINT ptClientUL;              // верхний левый угол клиент.области
	POINT ptClientLR;              // нижний правый угол клиент.области
	static POINTS ptsBegin;        // начальна€ точка
	static POINTS ptsEnd;          // нова€ конечна€ точка
	static POINTS ptsPrevEnd;      // предыдуща€ конечна€ точка
	static BOOL fPrevLine = FALSE; // флаг предыдущей линии
	static POINT ptBeg, ptEnd, ptBoxBeg, ptBoxEnd;
	static BOOL  fNullRec = false, fSolidRec = false;

	HPEN hPen = NULL;

	static int cxClient, cyClient;
	int wmId = LOWORD(wParam);
	int wmEvent = HIWORD(wParam);

	switch (uMsg)
	{
	case WM_INITDIALOG:
		hPen = CreatePen(PS_SOLID, 3, RGB(128, 0, 0));
		break;
	case WM_LBUTTONDOWN:
		if (peroType == 1)
		{
			fNullRec = TRUE;
			ptBeg.x = LOWORD(lParam);
			ptBeg.y = HIWORD(lParam);
		}
		if (peroType == 2)
		{
			SetCapture(hWnd);

			// ѕолучаем экранные координаты клиентской области, и преобразуем их в клиентские координаты.
			GetClientRect(hWnd, &rcClient);
			ptClientUL.x = rcClient.left;
			ptClientUL.y = rcClient.top;

			// ƒобавл€ем один пиксель справа и снизу, так как координаты, полученные из GetClientRect не включают левого и нижнего пикселей.
			ptClientLR.x = rcClient.right + 1;
			ptClientLR.y = rcClient.bottom + 1;
			ClientToScreen(hWnd, &ptClientUL);
			ClientToScreen(hWnd, &ptClientLR);

			//  опируем клиентские координаты клиентской области в структуру rcClient.
			// ќграничиваем курсор мышки клиентской областью, передав структуру rcClient в функцию ClipCursor.
			SetRect(&rcClient, ptClientUL.x, ptClientUL.y,
				ptClientLR.x, ptClientLR.y);
			ClipCursor(&rcClient);

			// ѕреобразуем координаты курсора дл€ структуры POINTS,
			// котора€ определ€ет начальную точку рисовани€ линии в течение сообщени€ WM_MOUSEMOVE.
			ptsBegin = MAKEPOINTS(lParam);
		}
		else if (peroType == 3)
		{
			crRec = RGB(rand() % 255, rand() % 255, rand() % 255);
			ptBeg.x = ptEnd.x = LOWORD(lParam);
			ptBeg.y = ptEnd.y = HIWORD(lParam);
			DrowSquareChildWindow(hWnd, ptBeg, ptEnd);
			SetCapture(hWnd);
			SetCursor(LoadCursor(NULL, IDC_CROSS));
			fNullRec = true;
		}
		break;
	case WM_MOUSEMOVE:
		if (peroType == 1)
		{
			if (fNullRec)
			{
				hdc = GetDC(hWnd);
				MoveToEx(hdc, ptBeg.x, ptBeg.y, NULL);
				LineTo(hdc, ptBeg.x = LOWORD(lParam), ptBeg.y = HIWORD(lParam));
				ReleaseDC(hWnd, hdc);
			}
		}
		if (peroType == 2)
		{
			// „тобы рисовалась лини€, то при движении мышки
			// пользователь должен удерживать нажатой левую кнопку мышки.

			if (wParam & MK_LBUTTON)
			{
				// ѕолучаем контекст устройства (DC) дл€ клиентской области
				hdc = GetDC(hWnd);

				// —ледующа€ функци€ гарантирует, что пиксели
				// предыдущей линии установлены в белый цвет, а вновь нарисованной линии - в чЄрный.
				SetROP2(hdc, R2_NOTXORPEN);

				// ≈сли лини€ была нарисована в предыдущем WM_MOUSEMOVE,
				// то рисуем поверх неЄ. “ем самым, установив пиксели линии в белый цвет, мы сотрЄм еЄ.
				if (fPrevLine)
				{
					MoveToEx(hdc, ptsBegin.x, ptsBegin.y, (LPPOINT)NULL);
					LineTo(hdc, ptsPrevEnd.x, ptsPrevEnd.y);
				}

				// ѕреобразуем текущие координаты курсора в структуру POINTS, а затем рисуем новую линию.
				ptsEnd = MAKEPOINTS(lParam);
				MoveToEx(hdc, ptsBegin.x, ptsBegin.y, (LPPOINT)NULL);
				LineTo(hdc, ptsEnd.x, ptsEnd.y);

				// ”станавливаем флаг предыдущей линии, сохран€ем конечную точку новой линии, а затем освобождаем DC.
				fPrevLine = TRUE;
				ptsPrevEnd = ptsEnd;
				ReleaseDC(hWnd, hdc);
			}
		}
		else if (peroType == 3)
		{
			if (fNullRec)
			{
				SetCursor(LoadCursor(NULL, IDC_CROSS));
				DrowSquareChildWindow(hWnd, ptBeg, ptEnd);
				ptEnd.x = LOWORD(lParam);
				ptEnd.y = HIWORD(lParam);
				DrowSquareChildWindow(hWnd, ptBeg, ptEnd);
			}
		}
		break;

	case WM_LBUTTONUP:
		if (peroType == 1)
		{
			if (fNullRec)
			{
				hdc = GetDC(hWnd);
				MoveToEx(hdc, ptBeg.x, ptBeg.y, NULL);
				LineTo(hdc, LOWORD(lParam), HIWORD(lParam));
				ReleaseDC(hWnd, hdc);
				fNullRec = FALSE;
			}
		}
		if (peroType == 2)
		{
			// ѕользователь закончил рисовать линию. —брасываем флаг
			// предыдущей линии, освобождаем курсор мышки и освобождаем захват мышки.

			fPrevLine = FALSE;
			ClipCursor(NULL);
			ReleaseCapture();
		}
		else if (peroType == 3)
		{
			if (fNullRec)
			{
				DrowSquareChildWindow(hWnd, ptBeg, ptEnd);
				ptBoxBeg = ptBeg;
				ptBoxEnd.x = LOWORD(lParam);
				ptBoxEnd.y = HIWORD(lParam);
				ReleaseCapture();
				SetCursor(LoadCursor(NULL, IDC_ARROW));
				fNullRec = false;
				fSolidRec = true;
				InvalidateRect(hWnd, NULL, FALSE);
			}
		}
		break;
	case WM_SIZE:
		cxClient = LOWORD(lParam);
		cyClient = HIWORD(lParam);
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		if (fSolidRec)
		{
			DrowSquareChildWindow(hWnd, ptBeg, ptEnd);
		}
		EndPaint(hWnd, &ps);
		break;
	case WM_WININICHANGE:
		InvalidateRect(hWnd, NULL, TRUE);
		break;
	default:
		return(DefMDIChildProc(hWnd, uMsg, wParam, lParam));
	}

	return(0L);
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
