#include <iostream>
#include <locale>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	char s[] = "Lorem *ipsum* dolor sit amet, consectetuer adipiscing elit. *Aenean* commodo.";
	int n = strlen(s);

	int col = 0;
	cout << "�������� ������:\n" << s << '\n' << endl;
	__asm
	{
		lea edi, [s]
		mov ecx, [n]

		beg:
			cmp byte ptr[edi], ' '
			jne prop

			inc col

		prop :
			cmp byte ptr[edi], '*'
			jne nn

			// ���������� ������
			mov esi, edi
			inc esi
			push edi
			push ecx
			inc ecx

		m :
			mov al, byte ptr[esi]
			mov byte ptr[edi], al
			inc esi
			inc edi
			loop m
			pop ecx
			pop edi

		nn :
			inc edi

		loop beg
	}

	cout << "������ � ���������� ��������� '*':\n" << s << endl;
	cout << "���������� ����, ��� ����� ��� ��� ��������� ��������� ��������: " << col + 1 << endl;

	cin.get();
	return 0;
}