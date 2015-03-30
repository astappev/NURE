/* Астаппев Олег											ИНФ-12-1
Якщо у заданому рядку є слово ‘КН’, то знайти його позицію та створити рядок,
де після цього слова стоїть фраза ‘спеціальність століття’.. */
#include <intrin.h>
#include <iostream>
#include <locale>
#include "cppFunction.h"
using namespace std;

extern "C" char *asmFunction_(char* s, int s_size, char* insert, int insert_size, char* result);

int main()
{
	setlocale(LC_ALL, "Russian");

	char s[] = "Fakultet KN, odin iz fakultetov NURE.";
	int s_size = strlen(s);

	char insert[] = "specialnist stolottya";
	int insert_size = strlen(insert);

	char result[200];
	memset(result, 0, sizeof(char)*200);

	__int64 time, time_start, time_end;

	cout << "Начальные данные:\n" << s << '\n' << endl;

	cout << "Функция C++:\n";
	time_start = __rdtsc();
	cppFunction(s, s_size, result, insert, insert_size);
	time_end = __rdtsc();
	time = time_end - time_start;
	cout << "Время работы: " << (int)time << '\n' << result << '\n' << endl;
	strcpy(result, "");

	cout << "Функция Assambler:\n";
	time_start = __rdtsc();
	asmFunction_(s, s_size, insert, insert_size, result);
	time_end = __rdtsc();
	time = time_end - time_start;
	cout << "Время работы: " << (int)time << '\n' << result << '\n' << endl;
	strcpy(result, "");

	cout << "C++:\n";
	time_start = __rdtsc();
	int size = 0;
	for (int i = 0; i < s_size - 1; ++i)
	{
		if (s[i] == 'K' && s[i + 1] == 'N')
		{
			result[size++] = s[i];
			result[size++] = s[i + 1];
			result[size++] = ' ';
			for (int j = 0; j < insert_size; ++j)
			{
				result[size++] = insert[j];
			}
			i += 2;
		}
		result[size++] = s[i];
	}
	result[size] = '\0';
	time_end = __rdtsc();
	time = time_end - time_start;
	cout << "Время работы: " << (int)time << '\n' << result << '\n' << endl;
	strcpy(result, "");

	cout << "Assambler:\n";
	time_start = __rdtsc();
	__asm
	{
		lea edi, [s]
		lea esi, [result]
		mov ecx, [s_size]

		beg :
			cmp byte ptr[edi], 'K'
			jne nen // не совпадает

			inc edi
			cmp byte ptr[edi], 'N'
			jne neno

			dec edi
			mov al, byte ptr[edi]
			mov byte ptr[esi], al
			inc edi
			inc esi

			mov al, byte ptr[edi]
			mov byte ptr[esi], al
			inc edi
			inc esi

			mov byte ptr[esi], ' '
			inc esi

			push edi
			push ecx

			lea edi, [insert]
			mov ecx, [insert_size]

			beg_vnt:
				mov al, byte ptr[edi]
				mov byte ptr[esi], al
				inc edi
				inc esi

			loop beg_vnt

			pop ecx
			pop edi
			jne nen

		neno:
			dec edi
		nen:
			mov al, byte ptr[edi]
			mov byte ptr[esi], al
			inc edi
			inc esi

		loop beg
	}

	time_end = __rdtsc();
	time = time_end - time_start;
	cout << "Время работы: " << (int)time << '\n' << result << '\n' << endl;

	cin.get();
	return 0;
}