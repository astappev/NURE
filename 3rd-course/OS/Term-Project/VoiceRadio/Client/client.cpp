#include "../Common/header.h"
#include "client.h"

#define ClassName _T("Client")
#define AppName _T("Voice Radio Client")

Settings::WaweFormat waweSettings;
Settings::UdpSetting udpSettings;

HANDLE ClientHandle;
DWORD id = 0u;
int xView = 0, yView = 0, k;
DWORD ClientOn(HWND);
const int F = 50, Fmax = 10000, N = 1000, Ns = 200;
HFONT font = (HFONT)GetStockObject(DEFAULT_GUI_FONT);
char server_ip[] = "127.0.0.1";

RECT ClRect, invRectSpectr;
HINSTANCE hInst;
HWND hwnd, hEdtMsg, hBtnStart, hBtnStop, hStatusMsg;

//typedef int Data[N];
static int BufData[8][N];

const TCHAR* statuses[] = {
	_T("Необходимо подключиться к серверу!"),
	_T("Подключение установлено"),
	_T("Подключение прервано"),
	_T("Подключение возобновлено")
};

enum StateConnected
{
	NEED,
	CONNECTED,
	CLOSE,
	RESUMED,
};

void SendMsgToServer(char *msg);
void SendError();

void ErrorHandle(HWND hwnd)
{
	ShowWindow(hwnd, SW_HIDE);
	MessageBox(hwnd, _T("Error"), AppName, MB_OK);
	DestroyWindow(hwnd);
}

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
BOOL CALLBACK ConnectDlgProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow){
	
	InitCommonControls();
	WNDCLASSEX wndClass;
	HWND hWnd;
	MSG msg;

	wndClass.cbSize = sizeof(wndClass);
	wndClass.style = CS_HREDRAW | CS_VREDRAW;
	wndClass.lpfnWndProc = WndProc;
	wndClass.cbClsExtra = 0;
	wndClass.cbWndExtra = 0;
	wndClass.hInstance = hInstance;
	wndClass.hIcon = LoadIcon((HINSTANCE)GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_FAVICON));
	wndClass.hCursor = LoadCursor(NULL, IDC_ARROW);
	wndClass.hbrBackground = GetStockBrush(BLACK_BRUSH);
	wndClass.lpszMenuName = _T("MainMenu");
	wndClass.lpszClassName = ClassName;
	wndClass.hIconSm = LoadIcon((HINSTANCE)GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_FAVICON));

	hInst = hInstance;
	RegisterClassEx(&wndClass);

	MainWndLeft = 100;
	MainWndTop = 100;
	MainWndWidth = 600;
	MainWndHeight = 400;
	EdtMsgHeight = 40;
	LstUsersWidth = 150;
	BtnHeight = 30;

	hWnd = CreateWindow(
		ClassName,
		AppName,
		WS_OVERLAPPEDWINDOW,
		MainWndLeft, MainWndTop,
		MainWndWidth,
		MainWndHeight,
		NULL,
		NULL,
		hInst,
		NULL
	);
	ShowWindow(hWnd, nCmdShow);

	hwnd = hWnd;
	GetClientRect(hWnd, &ClRect);
	EnableMenuItem(GetMenu(hWnd), IDM_SAVE, MF_DISABLED);
	EnableMenuItem(GetMenu(hWnd), IDM_PORT, MF_DISABLED);

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	// Выводим сообщения
	while (GetMessage(&msg, NULL, 0, 0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return (msg.wParam);
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static StateConnected state = NEED;
	HDC hdc;
	PAINTSTRUCT ps;
	HPEN hPen;

	switch (msg)
	{
	case WM_GETMINMAXINFO:
	{
		MINMAXINFO *pInfo = (MINMAXINFO *)lParam;
		POINT Min = { 334, 300 };
		pInfo->ptMinTrackSize = Min; // Установили минимальный размер
		return 0;
	}
	case WM_CREATE:
		GetClientRect(hWnd, &ClRect);
		hBtnStart = CreateWindow(_T("button"), _T("Подключиться"),
			WS_CHILD | WS_VISIBLE | BS_VCENTER | BS_CENTER,
			ClRect.right - LstUsersWidth * 2 - 12, ClRect.top + 6, LstUsersWidth, BtnHeight,
			hWnd, (HMENU)IDC_BTN_START, hInst, NULL);
		hBtnStop = CreateWindow(_T("button"), _T("Отключиться"),
			WS_CHILD | WS_VISIBLE | BS_VCENTER | BS_CENTER,
			ClRect.right - LstUsersWidth - 6, ClRect.top + 6, LstUsersWidth, BtnHeight,
			hWnd, (HMENU)IDC_BTN_STOP, hInst, NULL);
		hStatusMsg = CreateWindow(_T("static"), NULL,
			WS_CHILD | WS_VISIBLE | BS_VCENTER,
			ClRect.left + 6, ClRect.bottom - EdtMsgHeight*1.5 - 10, ClRect.right - 12, EdtMsgHeight/2,
			hWnd, (HMENU)IDC_EDT_STATUS, hInst, NULL);
		hEdtMsg = CreateWindow(_T("edit"), NULL,
			WS_CHILD | WS_BORDER | WS_VISIBLE | ES_LEFT | ES_MULTILINE | ES_AUTOVSCROLL | ES_NOHIDESEL,
			ClRect.left + 6, ClRect.bottom - EdtMsgHeight - 6, ClRect.right - 12, EdtMsgHeight,
			hWnd, (HMENU)IDC_EDT_MSG, hInst, NULL);
		EnableWindow(hBtnStop, 0);
		SetFocus(hEdtMsg);
		break;
	case WM_SIZE:
		GetClientRect(hWnd, &ClRect);
		HDWP hdwp;
		hdwp = BeginDeferWindowPos(5);
		hdwp = DeferWindowPos(hdwp, hBtnStart, NULL,
			ClRect.right - LstUsersWidth * 2 - 12, ClRect.top + 6, LstUsersWidth, BtnHeight,
			SWP_NOACTIVATE | SWP_NOZORDER);
		hdwp = DeferWindowPos(hdwp, hBtnStop, NULL,
			ClRect.right - LstUsersWidth - 6, ClRect.top + 6, LstUsersWidth, BtnHeight,
			SWP_NOACTIVATE | SWP_NOZORDER);
		hdwp = DeferWindowPos(hdwp, hStatusMsg, NULL,
			ClRect.left + 6, ClRect.bottom - EdtMsgHeight*1.5 - 10, ClRect.right - 12, EdtMsgHeight / 2,
			SWP_NOACTIVATE | SWP_NOZORDER);
		hdwp = DeferWindowPos(hdwp, hEdtMsg, NULL,
			ClRect.left + 6, ClRect.bottom - EdtMsgHeight - 6, ClRect.right - 12, EdtMsgHeight,
			SWP_NOACTIVATE | SWP_NOZORDER);		
		EndDeferWindowPos(hdwp);
		xView = LOWORD(lParam);
		yView = HIWORD(lParam);
		break;
	case WM_CTLCOLORSTATIC:
		if (hStatusMsg == (HWND)lParam)
		{
			SetBkMode((HDC)wParam, TRANSPARENT);
			SetTextColor((HDC)wParam, RGB(121, 121, 121));
			return (BOOL)GetStockObject(HOLLOW_BRUSH);
		}
	case WM_COMMAND:
		if ((HWND)lParam == hBtnStart){
			state = CONNECTED;
			EnableWindow(hBtnStart, 0);
			EnableWindow(hBtnStop, 1);
			ClientHandle = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ClientOn, hWnd, 0, &id);
			WaitForSingleObject(ClientHandle, 500);
		}
		if ((HWND)lParam == hBtnStop){
			state = CLOSE;
			CloseHandle(ClientHandle);
			EnableWindow(hBtnStop, 0);
			EnableWindow(hBtnStart, 1);
			PostThreadMessage(id, WM_QUIT, 0, 0);
		}
		switch (LOWORD(wParam))
		{
		case IDM_EXIT:
			SendMessage(hWnd, WM_CLOSE, NULL, NULL);
			break;
		case IDM_SERVER:
			if (DialogBox(NULL, MAKEINTRESOURCE(IDD_IPSELECT), hWnd, ConnectDlgProc) == 1)
			{
				TCHAR textBuffer[128];
				wsprintf(textBuffer, TEXT("Текущий ip адресс сервера: %s"), server_ip);
				MessageBox(NULL, textBuffer, "IP адресс сервера", MB_ICONINFORMATION | MB_OK);
			}
		case IDC_EDT_MSG:
			switch (HIWORD(wParam))
			{
			case EN_UPDATE:
				if (LOBYTE(GetAsyncKeyState(VK_RETURN)))
				{
					char *buf = new char[MAX_MSG_LENGTH];
					char *msg = new char[MAX_MSG_LENGTH];
					GetWindowText(hEdtMsg, buf, MAX_MSG_LENGTH);
					if (strlen(buf) > 2)
					{
						if (!(GetKeyState(VK_CONTROL) & 0x1000))
						{
							SetWindowText(hEdtMsg, NULL);
							SendMsgToServer(buf);
						}
					}
					else {
						SetWindowText(hEdtMsg, NULL);
					}
					SetFocus(hEdtMsg);
					delete buf;
					delete msg;
				}
				break;
			}
			break;
		}

		invRectSpectr = { ClRect.left, BtnHeight + 12, ClRect.right, ClRect.bottom - EdtMsgHeight - 6 };
		InvalidateRect(hWnd, &invRectSpectr, 1);
		SetWindowText(hStatusMsg, statuses[state]);
		break;
	case WM_PAINT:
		invRectSpectr = { ClRect.left, BtnHeight + 12, ClRect.right, ClRect.bottom - EdtMsgHeight - BtnHeight - 12 };
		InvalidateRect(hWnd, &invRectSpectr, 1); // обновляем окно
		hdc = BeginPaint(hWnd, &ps);
		SetMapMode(hdc, MM_ISOTROPIC); // устанавливаем режим отображения основаный на масштабировании
		SetWindowExtEx(hdc, 500, 500, NULL); // устанавливает масштаб
		SetViewportExtEx(hdc, xView, -yView, NULL); // без нее не работает масштаб
		SetViewportOrgEx(hdc, 0, yView / 2, NULL); // устанавливает смещение начала логических координат от левого верхнего угла окна в физических координатах (пикселях).

		// инициализируем линию
		hPen = CreatePen(0, 1, RGB(26, 207, 214));
		SelectObject(hdc, hPen);

		k = wParam;
		MoveToEx(hdc, 0, 0, NULL);
		// рисуем линию
		for (int i = 0; i < N; ++i){
			LineTo(hdc, i, BufData[k][i] / 3.0);
		}
		EndPaint(hWnd, &ps);

		ReleaseDC(hWnd, hdc);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, msg, wParam, lParam);
	}
}

DWORD ClientOn(HWND hWnd){
	// Инцициализация WinSock
	WSADATA ws;
	if (WSAStartup(MAKEWORD(2, 2), &ws)){
		//
	}

	// Открывает серверный соккет
	SOCKET Client;
	Client = socket(AF_INET, SOCK_DGRAM, 0);

	sockaddr_in local_addr;
	local_addr.sin_family = AF_INET;
	local_addr.sin_addr.s_addr = INADDR_ANY;
	local_addr.sin_port = htons(udpSettings.getPort());
	bind(Client, (sockaddr*)&local_addr, sizeof(local_addr));

	//sockaddr_in client_addr;
	int bsize;
	const int BufferCount = 8;

	HWAVEOUT waveOut;

	int bufsize;
	WAVEFORMATEX Format;
	Format.nChannels = waweSettings.getChannel();
	Format.wFormatTag = WAVE_FORMAT_PCM;
	Format.nSamplesPerSec = waweSettings.getSamplesPerSec();
	Format.wBitsPerSample = waweSettings.getBitsPerSample();
	Format.nBlockAlign = waweSettings.getBlockAlign();
	Format.cbSize = waweSettings.getCbSize();
	Format.nAvgBytesPerSec = waweSettings.getAvgBytesPerSec();

	bufsize = (Format.nAvgBytesPerSec * 2) / 16;

	waveOutOpen(&waveOut, WAVE_MAPPER, &Format, NULL, 0, CALLBACK_NULL);

	WAVEHDR fHeaders[BufferCount];
	for (int z = 0; z < BufferCount; ++z){
		fHeaders[z].dwFlags = WHDR_INQUEUE;
		fHeaders[z].dwBufferLength = bufsize;
		fHeaders[z].dwBytesRecorded = 0;
		fHeaders[z].dwUser = 0;
		fHeaders[z].dwLoops = 1;
		fHeaders[z].lpData = PCHAR(GlobalAlloc(GMEM_FIXED, bufsize));
	}

	MSG msg;
	ZeroMemory(&msg, sizeof(MSG));

	int i = 0;
	while (true) {
		// Пока не поступит команда о завершении соединения, мы получаем данные
		if (PeekMessage(&msg, NULL, WM_QUIT, WM_QUIT, PM_REMOVE)) {
			break; // больше не получаем
		}
		if (fHeaders[i].dwUser == 0) {
			bsize = recv(Client, fHeaders[i].lpData, fHeaders[i].dwBufferLength, 0);
			waveOutPrepareHeader(waveOut, &fHeaders[i], sizeof(WAVEHDR));
			//waveOutSetVolume(waveOut, 0xFFFFFFFF);
			waveOutWrite(waveOut, &fHeaders[i], sizeof(WAVEHDR));
			for (int j = 0; j < N; ++j) {
				BufData[i][j] = fHeaders[i].lpData[j];
			}
			SendMessage(hWnd, WM_PAINT, i, 0);
			fHeaders[i].dwUser = 0;
		}
		if (i == BufferCount - 1) {
			for (int z = 0; z < BufferCount; ++z){
				fHeaders[z].dwFlags = WHDR_INQUEUE;
				fHeaders[z].dwBufferLength = bufsize;
				fHeaders[z].dwBytesRecorded = 0;
				fHeaders[z].dwUser = 0;
				fHeaders[z].dwLoops = 1;
			}
			i = 0;
		}
		++i;
	}

	waveOutReset(waveOut);
	for (int i = 0; i < BufferCount; ++i) {
		waveOutUnprepareHeader(waveOut, &fHeaders[i], sizeof(WAVEHDR));
	}
	waveOutClose(waveOut);
	for (int i = 0; i < BufferCount; ++i) {
		GlobalFree(fHeaders[i].lpData);
	}
	closesocket(Client);

	WSACleanup();
	return 0u;
}

void SendMsgToServer(char *msg) {
	struct sockaddr_in si_other;
	int s, slen = sizeof(si_other);
	char buffer[MAX_MSG_LENGTH];
	WSADATA wsa;

	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0) {
		MessageBox(NULL, "Ошибка при создании WSASturtup", "Связь с сервером", MB_ICONERROR | MB_OK);
		return;
	}

	if ((s = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP)) == SOCKET_ERROR) {
		MessageBox(NULL, "Ошибка при создании сокета", "Связь с сервером", MB_ICONERROR | MB_OK);
		return;
	}
	HOSTENT *hst;

	memset((char *)&si_other, 0, sizeof(si_other));
	si_other.sin_family = AF_INET;
	si_other.sin_port = htons(udpSettings.getChatPort());
	if (inet_addr(server_ip)) {
		si_other.sin_addr.s_addr = inet_addr(server_ip);
	}
	else {
		if (hst = (HOSTENT*)gethostbyname(server_ip)) {
			si_other.sin_addr.s_addr = ((unsigned long**)hst->h_addr_list)[0][0];
		}
		else {
			ErrorHandle(hwnd);
		}
	}

	if (sendto(s, msg, strlen(msg), 0, (struct sockaddr *) &si_other, slen) == SOCKET_ERROR) {
		MessageBox(NULL, "Ошибка при отправке данных", "Связь с сервером", MB_ICONERROR | MB_OK);
		return;
	}

	memset(buffer, '\0', MAX_MSG_LENGTH);
	if (recvfrom(s, buffer, MAX_MSG_LENGTH, 0, (struct sockaddr *) &si_other, &slen) == SOCKET_ERROR) {
		MessageBox(NULL, "Ошибка при получении данных", "Связь с сервером", MB_ICONERROR | MB_OK);
		return;
	}
	SetWindowText(hStatusMsg, "Данные успешно переданы!");

	closesocket(s);
	WSACleanup();
}

BOOL CALLBACK ConnectDlgProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
		// Пользователь закрывает диалог или нажимает кнопку OK:
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDC_OK:
			char textBuffer[32];
			if (!GetDlgItemTextA(hWnd, IDC_IP, textBuffer, sizeof(textBuffer)))
			{
				MessageBox(NULL, _T("Пожалуйста, введите IP-адрес."), AppName, MB_ICONERROR | MB_OK);
				return TRUE;
			}

			strcpy(server_ip, textBuffer);
			EndDialog(hWnd, 1);
			return TRUE;
		case IDCANCEL:
			EndDialog(hWnd, 0);
			return TRUE;
		}
	}
	return FALSE;
}