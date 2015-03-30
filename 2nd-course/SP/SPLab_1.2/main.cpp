#include <iostream>
using namespace std;

int main()
{
	const int n = 10;
	__int8 masA[n] = { 1, -2, 8, -2, 0, -1, 0, -4, 9, 3 };
	__int8 masB[n];
	int col = 0;
	_asm
	{
		lea esi, [masA]
		mov ecx, [n]
		mov ebx, [col]

	f1: mov al, [esi]
		cmp al, 0
		jle f2
		mov masB[ebx], al
		inc ebx

	f2: inc esi
		loop f1

		mov col, ebx
	}

	for (int i = 0; i < col; ++i)
	{
		cout << (int) masB[i] << '\t';
	}

	cout << "\nCount: " << col;
	cin.get();
	return 0;
}