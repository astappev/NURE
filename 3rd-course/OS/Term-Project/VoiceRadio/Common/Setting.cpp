namespace Settings {

	struct UdpSetting
	{
	private:
		int port = 1001;

	public:
		int getPort() {
			return port;
		}
	};

	struct WaweFormat
	{
	private:
		int channel = 1;
		int samplesPerSec = 8000;
		int bitsPerSample = 8;
		int blockAlign = 1;
		int cbSize = 0;
		int avgBytesPerSec = 8000;

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


//Format.nChannels = 1;
//Format.wFormatTag = WAVE_FORMAT_PCM;
//Format.nSamplesPerSec = 8000;
//Format.wBitsPerSample = 8;
//Format.nBlockAlign = 1;
//Format.cbSize = 0;
//Format.nAvgBytesPerSec = 8000;

/*int sampleRate = 44100;
Format.nChannels = 2; // 1 - mono, 2 - stereo
Format.wFormatTag = WAVE_FORMAT_PCM; // simple, uncompressed format
Format.nSamplesPerSec = sampleRate;
Format.wBitsPerSample = 16; //  16 for high quality, 8 for telephone-grade
Format.nBlockAlign = Format.nChannels * Format.wBitsPerSample / 8;
Format.cbSize = 0;
Format.nAvgBytesPerSec = sampleRate * Format.nChannels * Format.wBitsPerSample / 8;*/