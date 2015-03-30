#include <iostream>
using namespace std;

int main()
{
	const int n = 10;
	__int16 masA[n] = { 5, -2, 8, -2, 0, -1, 0, -4, 9, 3 };
	__int16 masB[n];

	int k = 0;
	_asm
	{
		lea esi, [masA]
		lea edi, [masB]
		mov ecx, [n]

	f1:
		push ecx
		mov ax, [esi]

			ror ax, 3
			xor dx, dx
			mov cx, 4
		cycl:
			ror ax, 1
			jnc not_one
			inc dx
		not_one:
			loop cycl

		mov [edi], dx
		add edi, 2
		pop ecx

	f3:
		add esi, 2
		loop f1
	}

	for (int i = 0; i < n; ++i)
		cout << (int) masA[i] << '\t';

	for (int i = 0; i < n; ++i)
		cout << (int) masB[i] << '\t';
	
	cin.get();
	return 0;
}