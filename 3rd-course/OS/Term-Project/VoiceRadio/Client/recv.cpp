#include <windows.h>
#include "../Common/Setting.cpp"
#pragma comment(lib, "Ws2_32.lib")

Settings::WaweFormat waweSettings;
Settings::UdpSetting udpSettings;

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
	for (int i = 0; i < BufferCount; ++i){
		fHeaders[i].dwFlags = WHDR_INQUEUE;
		fHeaders[i].dwBufferLength = bufsize;
		fHeaders[i].dwBytesRecorded = 0;
		fHeaders[i].dwUser = 0;
		fHeaders[i].dwLoops = 1;
		fHeaders[i].lpData = PCHAR(GlobalAlloc(GMEM_FIXED, bufsize));
	}

	MSG msg;
	ZeroMemory(&msg, sizeof(MSG));

	int i = 0;
	while (++i) {
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
			for (int i = 0; i < BufferCount; ++i){
				fHeaders[i].dwFlags = WHDR_INQUEUE;
				fHeaders[i].dwBufferLength = bufsize;
				fHeaders[i].dwBytesRecorded = 0;
				fHeaders[i].dwUser = 0;
				fHeaders[i].dwLoops = 1;
			}
			i = 0;
		}
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