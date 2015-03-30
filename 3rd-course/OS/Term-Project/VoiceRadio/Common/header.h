#ifndef _HEADER_COMMON
#define _HEADER_COMMON

#include <windows.h>
#include <windowsx.h>
#include <stdio.h>
#include <tchar.h>

#include <commctrl.h>
#include <mmsystem.h>
#include <mmreg.h>
#include <string.h>

#pragma comment(lib, "Ws2_32.lib")
#pragma comment(lib, "winmm.lib")
#pragma comment(lib, "comctl32")

const int MAX_MSG_LENGTH = 512;

namespace Settings {

	struct UdpSetting
	{
	private:
		int port = 1001;
		int chat_port = 8888;
		int chat_bufer = 512;

	public:
		int getPort() {
			return port;
		}
		int getChatPort() {
			return chat_port;
		}
		int getChatBufer() {
			return chat_bufer;
		}
	};

	struct WaweFormat
	{
	private:
		int channel = 1; //  1=mono, 2=stereo
		int samplesPerSec = 8000;
		int bitsPerSample = 8; //  16 for high quality, 8 for telephone-grade
		int blockAlign = channel * bitsPerSample / 8;
		int cbSize = 0;
		int avgBytesPerSec = samplesPerSec * channel * bitsPerSample / 8;

	public:
		int getChannel() {
			return channel;
		}
		int getSamplesPerSec() {
			return samplesPerSec;
		}
		int getBitsPerSample() {
			return bitsPerSample;
		}
		int getBlockAlign() {
			return blockAlign;
		}
		int getCbSize() {
			return cbSize;
		}
		int getAvgBytesPerSec() {
			return avgBytesPerSec;
		}
	};
}

#endif