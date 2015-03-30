#include <iostream>
using namespace std;

int main()
{
	const int n = 5;
	__int16 a[n];

	for (int i = 0; i < n; ++i)
		a[i] = 0;

	__int16 matr[n][n];

	for (int i = 0; i < n; ++i)
	for (int j = 0; j < n; ++j)
	{
		matr[i][j] = rand() % 21 - 10;
	}

	cout << "Matr:" << endl;
	for (int i = 0; i < n; ++i, cout << '\n')
	for (int j = 0; j < n; ++j)
	{
		cout << matr[i][j] << '\t';
	}

	int k = 0;
	_asm
	{
		mov eax, 0
		lea esi, matr
		lea edi, a

		push eax
		mov eax, n
		mul eax
		mov ecx, eax
		pop eax

		beg:
			cmp k, 5
			je null
			mov ax, [esi]
			add ax, [edi]
			mov [edi], ax
			add edi, 2
			inc k

		endl:
			add esi, 2
			loop beg
		jmp fin

		null:
			mov k, 0
			sub edi, 10
		jmp beg

		fin:
	}
	
	cout << "Mas output: " << endl;
	for (int i = 0; i < k; ++i)
	{
		cout << a[i] << '\t';
	}

	cin.get();
	return 0;
}