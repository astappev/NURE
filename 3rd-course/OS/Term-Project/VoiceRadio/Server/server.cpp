#include "../Common/header.h"
#include "server.h"
//#include "chat.cpp"

#define WM_ERROR	WM_USER

#define ClassName "RadioServer"
#define AppName "Voice Radio Server"

Settings::WaweFormat waweSettings;
Settings::UdpSetting udpSettings;

static char SERVERADDR[20] = "127.0.0.255";
static int bufsize;
WAVEHDR waveHdr;
SOCKET Client;
int result;
const int F = 50, Fmax = 10000, N = 320, Ns = 200;

USRDATA UsrList[20];
int nUsers = 0;

bool GetUserList();
bool AddUser(LPUSRDATA);
bool DelUser(LPUSRDATA);
bool ChangeUserName(LPUSRDATA);
bool UpdateUserList();
bool UserInList(LPUSRDATA);

RECT ClRect;
HINSTANCE hInst;
HWND hwnd, hEdtMsg, hEdtChat, hLstUsers, hBtnMainCh, hBtnStart, hBtnStop, hUsrLabel;

void CALLBACK OnWave(HWAVEIN, UINT, DWORD_PTR, DWORD_PTR, DWORD_PTR);

DWORD ServerChatOn(HWND hWnd);
HANDLE ChatHandle;
DWORD id = 0u;
void SendError();

void ErrorHandle(HWND hwnd)
{
	ShowWindow(hwnd, SW_HIDE);
	MessageBox(hwnd, "Error", AppName, MB_OK);
	DestroyWindow(hwnd);
}

LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

HWAVEIN waveIn;

void MsgOut(char *msg);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow) {
	
	InitCommonControls();
	WNDCLASSEX wndClass;
	HWND hWnd;
	MSG msg;
	wndClass.style = CS_HREDRAW | CS_VREDRAW;
	wndClass.lpfnWndProc = WndProc;
	wndClass.cbClsExtra = 0;
	wndClass.cbWndExtra = 0;
	wndClass.hInstance = hInstance;
	wndClass.hIcon = LoadIcon((HINSTANCE)GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_FAVICON));
	wndClass.hCursor = LoadCursor(NULL, IDC_ARROW);
	wndClass.hbrBackground = GetStockBrush(WHITE_BRUSH);
	wndClass.lpszMenuName = "MainMenu";
	wndClass.lpszClassName = ClassName;
	wndClass.cbSize = sizeof(WNDCLASSEX);
	wndClass.hIconSm = LoadIcon((HINSTANCE)GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_FAVICON));

	MainWndLeft = 100;
	MainWndTop = 100;
	MainWndWidth = 600;
	MainWndHeight = 400;
	EdtMsgHeight = 80;
	LstUsersWidth = 150;
	BtnHeight = 30;

	hInst = hInstance;
	RegisterClassEx(&wndClass);

	hWnd = CreateWindow(
		ClassName, // имя класса
		AppName, // текст в заголовке окна
		WS_OVERLAPPEDWINDOW, // тип создаваемого окна
		MainWndLeft, MainWndTop, // положение окна по X, Y
		MainWndWidth, // ширина окна в пикселях
		MainWndHeight, // высота окна в пикселях
		NULL, // дескриптор родительского окна (у этого окна не будет родителя)
		NULL, // декскриптор меню окна
		hInst, // декскриптор текущего экзмепляра приложения
		NULL // значение, которое будет передано окну после создания (нам это не нужно)
	);
	ShowWindow(hWnd, nCmdShow);


	hwnd = hWnd;
	GetClientRect(hWnd, &ClRect);
	EnableMenuItem(GetMenu(hWnd), IDM_MASK, MF_DISABLED);
	EnableMenuItem(GetMenu(hWnd), IDM_PORT, MF_DISABLED);
	EnableMenuItem(GetMenu(hWnd), IDM_PLAY, MF_DISABLED);

	WAVEFORMATEX Format;
	Format.nChannels = waweSettings.getChannel();
	Format.wFormatTag = WAVE_FORMAT_PCM;
	Format.nSamplesPerSec = waweSettings.getSamplesPerSec();
	Format.wBitsPerSample = waweSettings.getBitsPerSample();
	Format.nBlockAlign = waweSettings.getBlockAlign();
	Format.cbSize = waweSettings.getCbSize();
	Format.nAvgBytesPerSec = waweSettings.getAvgBytesPerSec();

	bufsize = (Format.nAvgBytesPerSec * 2) / 16;

	waveInOpen(&waveIn, WAVE_MAPPER, &Format, (DWORD)OnWave, 0, CALLBACK_FUNCTION);

	waveHdr.lpData = PCHAR(GlobalAlloc(GMEM_FIXED, bufsize));
	waveHdr.dwBufferLength = bufsize;
	waveHdr.dwFlags = 0;

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	while (GetMessage(&msg, NULL, 0, 0)){
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return (int) msg.wParam;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	HDC hdc;
	RECT rect;
	rect.left = 0;
	rect.right = 100;
	rect.bottom = 50;
	rect.top = 0;
	const TCHAR* mes = "Неккоректный ip адресс!";
	switch (msg)
	{
	case WM_GETMINMAXINFO:
	{
		MINMAXINFO *pInfo = (MINMAXINFO *)lParam;
		POINT Min = { 500, 350 };
		pInfo->ptMinTrackSize = Min; // Установили минимальный размер
		return 0;
	}
	case WM_CREATE:
		GetClientRect(hWnd, &ClRect);
		hEdtMsg = CreateWindow("edit", NULL,
			WS_CHILD | WS_BORDER | WS_VSCROLL | WS_VISIBLE | ES_LEFT | ES_MULTILINE | ES_AUTOVSCROLL | ES_NOHIDESEL,
			ClRect.left + 6, ClRect.bottom - EdtMsgHeight - 6, ClRect.right - LstUsersWidth - 18, EdtMsgHeight,
			hWnd, (HMENU)IDC_EDT_MSG, hInst, NULL);
		hEdtChat = CreateWindow("edit", NULL,
			WS_CHILD | WS_BORDER | WS_VSCROLL | WS_VISIBLE | ES_LEFT | ES_MULTILINE | ES_AUTOVSCROLL | ES_NOHIDESEL | ES_READONLY,
			ClRect.left + 6, ClRect.top + 6, ClRect.right - LstUsersWidth - 18, ClRect.bottom - EdtMsgHeight - 24,
			hWnd, (HMENU)IDC_EDT_MSG, hInst, NULL);
		hBtnStart = CreateWindow("button", "Начать трансляцию",
			WS_CHILD | WS_VISIBLE | BS_VCENTER | BS_CENTER,
			ClRect.right - LstUsersWidth - 6, ClRect.top + 6, LstUsersWidth, BtnHeight,
			hWnd, (HMENU)IDC_BTN_START, hInst, NULL);
		hBtnStop = CreateWindow("button", "Завершить трансл.",
			WS_CHILD | WS_VISIBLE | BS_VCENTER | BS_CENTER,
			ClRect.right - LstUsersWidth - 6, ClRect.top + BtnHeight + 12, LstUsersWidth, BtnHeight,
			hWnd, (HMENU)IDC_BTN_STOP, hInst, NULL);
		EnableWindow(hBtnStop, 0);
		hUsrLabel = CreateWindow("static", "Пользователи:",
			WS_CHILD | WS_VISIBLE | BS_VCENTER,
			ClRect.right - LstUsersWidth - 6, ClRect.top + BtnHeight * 2 + 34, LstUsersWidth, BtnHeight - 16,
			hWnd, (HMENU)IDC_USRLABEL, hInst, NULL);
		hLstUsers = CreateWindow("listbox", "users",
			WS_CHILD | WS_BORDER | WS_VISIBLE | LBS_EXTENDEDSEL | LBS_NOINTEGRALHEIGHT | LBS_NOTIFY | LBS_SORT,
			ClRect.right - LstUsersWidth - 6, ClRect.top + BtnHeight * 3 + 24, LstUsersWidth, ClRect.bottom - BtnHeight * 3 - 30,
			hWnd, (HMENU)IDC_LST_USERS, hInst, NULL);
		SetFocus(hEdtMsg);
		break;
	case WM_SIZE:
		GetClientRect(hWnd, &ClRect);
		HDWP hdwp;
		hdwp = BeginDeferWindowPos(5);
		hdwp = DeferWindowPos(hdwp, hEdtMsg, NULL,
			ClRect.left + 6, ClRect.bottom - EdtMsgHeight - 6, ClRect.right - LstUsersWidth - 18, EdtMsgHeight,
			SWP_NOACTIVATE | SWP_NOZORDER);
		hdwp = DeferWindowPos(hdwp, hEdtChat, NULL,
			ClRect.left + 6, ClRect.top + 6, ClRect.right - LstUsersWidth - 18, ClRect.bottom - EdtMsgHeight - 24,
			SWP_NOACTIVATE | SWP_NOZORDER);
		hdwp = DeferWindowPos(hdwp, hBtnStart, NULL,
			ClRect.right - LstUsersWidth - 6, ClRect.top + 6, LstUsersWidth, BtnHeight,
			SWP_NOACTIVATE | SWP_NOZORDER);
		hdwp = DeferWindowPos(hdwp, hBtnStop, NULL,
			ClRect.right - LstUsersWidth - 6, ClRect.top + BtnHeight + 12, LstUsersWidth, BtnHeight,
			SWP_NOACTIVATE | SWP_NOZORDER);
		hdwp = DeferWindowPos(hdwp, hUsrLabel, NULL,
			ClRect.right - LstUsersWidth - 6, ClRect.top + BtnHeight * 2 + 34, LstUsersWidth, BtnHeight - 16,
			SWP_NOACTIVATE | SWP_NOZORDER);
		hdwp = DeferWindowPos(hdwp, hLstUsers, NULL,
			ClRect.right - 6 - LstUsersWidth, ClRect.top + BtnHeight * 3 + 24, LstUsersWidth, ClRect.bottom - BtnHeight * 3 - 30,
			SWP_NOACTIVATE | SWP_NOZORDER);
		EndDeferWindowPos(hdwp);
		break;
	case WM_CTLCOLORSTATIC:
		if (hUsrLabel == (HWND)lParam)
		{
			SetBkMode((HDC)wParam, TRANSPARENT);
			return (BOOL)GetStockObject(HOLLOW_BRUSH);
		}
	case WM_COMMAND:
		if ((HWND)lParam == hBtnStart) {
			EnableWindow(hBtnStart, 0);
			EnableWindow(hBtnStop, 1);
			waveInPrepareHeader(waveIn, &waveHdr, sizeof(WAVEHDR));
			waveInAddBuffer(waveIn, &waveHdr, sizeof(WAVEHDR));
			waveInStart(waveIn);

			MsgOut("!: Сервер запущен");

			
			ChatHandle = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)ServerChatOn, hWnd, 0, &id);
			WaitForSingleObject(ChatHandle, 500);
			
		}
		if ((HWND)lParam == hBtnStop) {
			//InvalidateRect(hWnd, &rect, 1);
			EnableWindow(hBtnStop, 0);
			EnableWindow(hBtnStart, 1);
			waveInUnprepareHeader(waveIn, &waveHdr, sizeof(WAVEHDR));
			waveInStop(waveIn);

			MsgOut("!: Сервер остановлен");

			PostThreadMessage(id, WM_QUIT, 0, 0);
		}
		switch (LOWORD(wParam))
		{
		case IDM_EXIT:
			SendMessage(hWnd, WM_CLOSE, NULL, NULL);
			break;
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

							MsgOut(buf);
							/*SOCKDATA sdata;
							memset(&sdata, 0, sizeof(SOCKDATA));
							sdata.type = SDT_MAIN_CHANAL_MSG;
							strcpy((char *)&(sdata.data), buf);
							strcpy((char *)&(sdata.user), UserName);
							SendToChanal(ID_CHANAL_MAIN, &sdata);*/
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
		break;
	case WM_PAINT:
		if (wParam == 1){
			hdc = GetDC(hWnd);
			TextOut(hdc, 0, 0, mes, sizeof(mes));
			ReleaseDC(hWnd, hdc);
		}
		if (wParam == 2)
			InvalidateRect(hWnd, &rect, 1);
		break;
	case WM_DESTROY:
		closesocket(Client);
		//GlobalFree(waveHdr.lpData);
		WSACleanup();
		PostQuitMessage(0);
		break;
	case WM_ERROR:
		InvalidateRect(hWnd, NULL, FALSE);
		UpdateWindow(hWnd);
		return 0;
	default:
		return DefWindowProc(hWnd, msg, wParam, lParam);
	}
}

void SendError()
{
	SendMessage(hwnd, WM_ERROR, 0, 0);
}

void MsgOut(char *msg)
{
	char *buf;
	int lng;
	buf = new char[MAX_MSG_LENGTH];
	strcpy(buf, msg);
	strcat(buf, "\r\n");
	lng = GetWindowTextLength(hEdtChat);
	SendMessage(hEdtChat, EM_SETSEL, (WPARAM)lng, (LPARAM)lng);
	SendMessage(hEdtChat, EM_REPLACESEL, NULL, (LPARAM)buf);
	SendMessage(hEdtChat, EM_LINESCROLL, NULL, (LPARAM)(-1));
	delete buf;
}

DWORD ServerChatOn(HWND hWnd) {
	SOCKET s;
	struct sockaddr_in server, si_other;
	int slen, recv_len;
	char buf[512];
	WSADATA wsa;

	slen = sizeof(si_other);

	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0) {
		MessageBox(NULL, "Ошибка при инициализации WinSock", "Связь с клиентом", MB_ICONERROR | MB_OK);
		return 0;
	}

	if ((s = socket(AF_INET, SOCK_DGRAM, 0)) == INVALID_SOCKET) {
		MessageBox(NULL, "Ошибка при создании WinSock", "Связь с клиентом", MB_ICONERROR | MB_OK);
		return 0;
	}

	server.sin_family = AF_INET;
	server.sin_addr.s_addr = INADDR_ANY;
	server.sin_port = htons(udpSettings.getChatPort());

	if (bind(s, (struct sockaddr *)&server, sizeof(server)) == SOCKET_ERROR)
	{
		MessageBox(NULL, "Ошибка при поптыке доступа к порту", "Связь с клиентом", MB_ICONERROR | MB_OK);
		return 0;
	}

	MSG msg;
	ZeroMemory(&msg, sizeof(MSG));

	while (true)
	{
		if (PeekMessage(&msg, NULL, WM_QUIT, WM_QUIT, PM_REMOVE)) {
			break;
		}

		fflush(stdout);
		memset(buf, '\0', 512);

		if ((recv_len = recvfrom(s, buf, 512, 0, (struct sockaddr *) &si_other, &slen)) == SOCKET_ERROR)
		{
			MessageBox(NULL, "Ошибка при получении данных", "Связь с клиентом", MB_ICONERROR | MB_OK);
			return 0;
		}

		USRDATA user1;
		user1.addr = si_other.sin_addr;
		AddUser(&user1);

		char *bufnew;
		int lng;
		bufnew = new char[MAX_MSG_LENGTH];
		strcpy(bufnew, inet_ntoa(si_other.sin_addr));
		strcat(bufnew, ":-> ");
		strcat(bufnew, buf);
		MsgOut(bufnew);

		if (sendto(s, buf, recv_len, 0, (struct sockaddr*) &si_other, slen) == SOCKET_ERROR)
		{
			MessageBox(NULL, "Ошибка при отправке данных", "Связь с клиентом", MB_ICONERROR | MB_OK);
			return 0;
		}
	}

	closesocket(s);
	WSACleanup();
	return 0u;
}

void CALLBACK OnWave(HWAVEIN waveIn, UINT msg, DWORD_PTR Instance, DWORD_PTR Param1, DWORD_PTR Param2){
	int count = 0;

	switch (msg) {
	case MM_WIM_DATA:
		waveInPrepareHeader(waveIn, &waveHdr, sizeof(WAVEHDR));
		waveInAddBuffer(waveIn, &waveHdr, sizeof(WAVEHDR));

		WSADATA ws;
		if (WSAStartup(MAKEWORD(2, 2), &ws)) {
			MessageBox(NULL, "Ошибка инициализации WinSock.", "Title", MB_ICONERROR | MB_OK);
			SendError();
			return;
		}

		Client = socket(AF_INET, SOCK_DGRAM, 0);
		if (Client == INVALID_SOCKET)
		{
			MessageBox(NULL, "Ошибка создания сокета.", "Title", MB_ICONERROR | MB_OK);
			closesocket(Client);
			WSACleanup();
			SendError();
			return;
		}

		HOSTENT *hst;
		sockaddr_in dest_addr;

		
		// Широковещательные
		dest_addr.sin_family = AF_INET;
		dest_addr.sin_port = htons(udpSettings.getPort());

		if (inet_addr(SERVERADDR)) {
			dest_addr.sin_addr.s_addr = inet_addr(SERVERADDR);
		} else {
			if (hst = (HOSTENT*)gethostbyname(SERVERADDR)) {
				dest_addr.sin_addr.s_addr = ((unsigned long**)hst->h_addr_list)[0][0];
			}
			else {
				ErrorHandle(hwnd);
			}
		}

		result = connect(Client, (sockaddr*)&dest_addr, sizeof(dest_addr));
		if (result == SOCKET_ERROR || Client == INVALID_SOCKET)
		{
			MessageBox(NULL, "Невозможно подключиться к серверу.", "title", MB_ICONERROR | MB_OK);
			count = result;
			SendMessage(hwnd, WM_PAINT, 1, 0);
		} else if (count != 0) {
			count = 0;
			SendMessage(hwnd, WM_PAINT, 2, 0);
		}

		result = send(Client, waveHdr.lpData, waveHdr.dwBufferLength, 0);
		if (result == -1) {
			count = result;
			SendMessage(hwnd, WM_PAINT, 1, 0);
		}
		else {
			if (count == -1) {
				SendMessage(hwnd, WM_PAINT, 2, 0);
				count = 2;
			}
		}
		closesocket(Client);
	}
}


bool UserInList(LPUSRDATA user)
{
	for (int i = 0; i < nUsers; i++)
	{
		if (UsrList[i].addr.s_addr == user->addr.s_addr)
			return TRUE;
	}

	return FALSE;
}

bool AddUser(LPUSRDATA user)
{
	if (!UserInList(user))
	{
		UsrList[nUsers] = *user;
		nUsers++;
		SendMessage(hLstUsers, LB_ADDSTRING, NULL, (LPARAM)inet_ntoa(user->addr));
		return TRUE;
	}

	return FALSE;
}