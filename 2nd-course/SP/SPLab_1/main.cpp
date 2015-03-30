#include <iostream>
using namespace std;
int main()
{
	__int16 y = 0;
	__int16 x, a, z = 1387;
	cout << "VVedite X, A: ";
	cin >> x >> a;

	_asm {
		mov ax, [x]
		mov bx, [a]
		mov cx, 0
		cmp ax, cx	// Сравнение
		jg m1		// x > 0	=> m1
		jle m2		// 0 <= x	=> m2

		m1: // y = a*a/x+(1387/x-x)*a
			mov ax, [a]
			mov cx, [x]
			mul ax
			div cx
			mov cx, ax
			
			mov ax, [z]
			mov bx, [x]
			cwd
			div bx
			sub ax, bx
			mov bx, [a]
			imul bx

			add ax, cx
			
			mov y, ax
			jmp res

		m2:
			mov y, 0

		res:
	}
	cout << y;
	return 0;
}