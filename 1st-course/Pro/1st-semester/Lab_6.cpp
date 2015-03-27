/*
Описать структуру с именем STUDENT, содержащую следующие поля:
- фамилия и инициалы;
- номер группы;
- успеваемость (массив из пяти элементов).
Написать программу, выполняющую следующие действия:
- ввод с клавиатуры данных в массив, состоящий из десяти структур типа STUDENT; записи должны быть упорядочены по возрастанию номера группы;
- вывод на дисплей фамилий и номеров групп для всех студентов, включенных в массив, если средний балл студента больше 4.0;
- если таких студентов нет, вывести соответствующее сообщение.
*/

main.cpp
#include "namespace.h"
using namespace st;
int main()
{
	int output_st=0, n=0;
	std::cout<<"Vvedite kol-vo studentov: ";
	std::cin>>n;
	STUDENT * stud = new STUDENT[n];
	SetStudents (stud, n);
	OutputStudents (stud, n, output_st);
	WarningStudents (output_st);
	delete[]stud;
	std::cin.get();
	return 0;
}

namespace.h
#include<iostream>
namespace st
{
	struct STUDENT
	{
		char fio[100];
		int number_group;
		int mas_marks[5];
	};
	void SetStudents (STUDENT *stud, int n);
    void OutputStudents (STUDENT *stud, int n, int &st);
    void WarningStudents (int st);
}
void st::SetStudents (STUDENT *stud, int n)
{
	for(int i=0; i<n; ++i)
	{
		std::cout<<"\nVvedite fio "<<i+1<<" studenta: ";
		std::cin>>stud[i].fio;
		std::cout<<"Vvedite nomer grupi: ";
		std::cin>>stud[i].number_group;
		std::cout<<"Vvedite 5 ocenok po ekzamenam: ";
		for(int m=0; m<5; ++m)
		{
error:
			std::cin>>stud[i].mas_marks[m];
			if(stud[i].mas_marks[m]<0 || stud[i].mas_marks[m]>5)
			{
				std::cout<<"Error\nVvedite ocenku ece raz, vi previshili maksimalno dopustimu\n";
				goto error;
			}
		}
	}
}
void st::OutputStudents (STUDENT *stud, int n, int &st)
{
	for(int i=0; i<n; ++i)
	{
		double sbal=0;
		for(int m=0; m<5; ++m)
			sbal+=stud[i].mas_marks[m];
		sbal=sbal/5;
		if(sbal>=4.0)
		{
			std::cout<<"Fio studenta: "<<stud[i].fio<<"\tNomer grupi: "<<stud[i].number_group<<"\tSredniy bal: "<<sbal<<'\n';
			st++;
		}
	}
}
void st::WarningStudents (int st)
{
	if(st==0)
		std::cout<<"Vse studenti plohie!";
}
