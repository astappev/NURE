// WinAPI_1.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "WinAPI_1.h"

#define MAX_LOADSTRING 100
#define IDM_MYMENURESOURCE 5

// ���������� ����������:
HINSTANCE hInst;								// ��������� ����������
TCHAR szTitle[] = _T("������������ WIN API");	// The title bar text
TCHAR szWindowClass[] = _T("Oleg");			// the main window class name

// ��������������� �������� �������:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

// �������� ��������� 
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
	// ����������� ������ ���� 
	MyRegisterClass(hInstance);

	// �������� ���� ����������:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_MENU));

	// ���� ��������� ���������:
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
//  PURPOSE: ������������ ����� ����.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW; 	// ����� ����
	wcex.lpfnWndProc	= WndProc; // ������� ���������
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance; // ��������� ����������
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW); // ����������� �������
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1); // ��������� ����
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_MENU); // ����������� ����
	wcex.lpszClassName	= szWindowClass; // ��� ������
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_APPLICATION)); // ����������� ������ � ������ windows
	wcex.hIconSm		= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_APPLICATION)); // ����������� ������ ����

	return RegisterClassEx(&wcex); // ����������� ������ ����
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        ������� ���� ���������� � ��������� ��������� ���������� � ���������� hInst
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // ��������� ��������� ���������� � ���������� hInst

   hWnd = CreateWindow(szWindowClass, szTitle, WS_BORDER|WS_OVERLAPPEDWINDOW, // ��� ������ ����, ��� ����������, ����� ����
	   CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, CW_USEDEFAULT, // ��������� �� �, ��������� �� Y, ������ �� �, ������ �� Y
	  NULL, NULL, hInstance, NULL); // ��������� ������������� ����, ��������� ���� ����, ��������� ����������, ��������� ��������

   if (!hWnd) // ���� ���� �� ���������, ������� ���������� FALSE
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow); // �������� ����
   UpdateWindow(hWnd); // �������� ����

   return TRUE; //�������� ���������� �������
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  ������� ���������. ��������� � ������������ ��� ���������, ���������� � ����������
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
	TCHAR text[] = _T("�������� ����");
	TCHAR text2[] = _T("���-12-1");

	switch (message)
	{
	/*
	1 �������� ���������, ������� ������ �� ������������ ��������� ���� � ������� ��� ���������� � ���� ����������.
	���� ��� ������ �� ���� ������ ������ ���� ������, ��������� ���������� ������� �� ������������ ���� � �������� �� ����������.
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
	case WM_PAINT: // ������������ ����
		hdc = BeginPaint(hWnd, &ps); // ������ ����������� �����
		
		TextOut(hdc, 5, 5, text, _tcslen(text));
		TextOut(hdc, 5, 24, text2, _tcslen(text2));

		EndPaint(hWnd, &ps); // ��������� ����������� �����
		break;
	case WM_DESTROY: // ���������� ������
		PostQuitMessage(0);
		break;
	default:
		// ��������� ���������, ������� �� ���������� �������������
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