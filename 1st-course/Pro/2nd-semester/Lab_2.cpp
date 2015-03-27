#include <iostream>
#include <fstream>
#include <iomanip>
#include <locale>
using namespace std;

struct STUDENT{
	char fio[90];
	int group;
	int marks[5];
};

int binout (STUDENT *Stud, int n)
{
	ofstream binout("f2.txt",ios::binary);
	for(int i = 0; i < n; i++)
		binout.write((char*)&Stud[i],sizeof(STUDENT));
	binout.close();
	return 1;
}
int main()
{
	setlocale(LC_ALL,"Russian");
	ifstream innn("begin.txt");
	if (!innn)
	{
		cerr<<"Не удалось открыть файл\n";
		return 1;
	}
	const int n = 5;
	STUDENT Stud[n];
	for(int i = 0; i < n; i++)
	{
		char str[90];
		innn.getline(Stud[i].fio,90);
		innn.getline(str,90);
		Stud[i].group = atoi(str);
		for (int k = 0; k < 5; ++k)
		{
			innn.get(str,2);
			innn.ignore(1);
			Stud[i].marks[k] = atoi(str);
			if (Stud[i].marks[k]>5 || Stud[i].marks[k]<0)
			{
				cerr<<"Файл данных не корректен\n";
				return 1;
			}
		}
	}
	binout (Stud, n);
	STUDENT Stud2[n];
	ifstream bincin("f2.txt",ios::binary);
	for(int i = 0; i < n; i++)
		bincin.read((char*)&Stud2[i],sizeof(STUDENT));
		bincin.close();

	cout<<"Проверка: чтения, записи в бинарник, чтения из него."<<endl;
	for(int i = 0; i < n; i++) 
	{
		cout<<resetiosflags(ios::right);
		cout.setf(ios::left);
		cout<<setw(20)<<setfill('.');
		cout<<Stud2[i].fio;
		cout<<setw(8);
		cout.setf(ios::right);
		cout<<Stud2[i].group;
		cout<<setw(5)<<setfill(' ');
		for (int k=0; k<5; ++k)
			cout<<Stud2[i].marks[k]<<' ';
		cout<<endl;
	}
	cout<<"Сортировка по номеру группы."<<endl;
	for(int i = 0; i < n; ++i)
		for(int j = i+1; j < n; ++j)
			if (Stud2[i].group > Stud2[j].group)
			{
				STUDENT Studtemp;
				memcpy(&Studtemp, &Stud2[j], sizeof(STUDENT));
				memcpy(&Stud2[j], &Stud2[i], sizeof(STUDENT));
                memcpy(&Stud2[i], &Studtemp, sizeof(STUDENT));
			}

	cout<<"Вывод отличников."<<endl;
	for(int i = 0; i < n; i++) 
	{
		int sbal=0, c=0;
		for (int k=0; k<5; ++k)
			sbal+=Stud2[i].marks[k];
		if((sbal/5)>4)
		{
			cout<<resetiosflags(ios::right);
			cout.setf(ios::left);
			cout<<setw(20)<<setfill('.');
			cout<<Stud2[i].fio;
			cout<<setw(8);
			cout.setf(ios::right);
			cout<<Stud2[i].group;
			cout<<setw(5)<<setfill(' ');
			for (int k=0; k<5; ++k)
				cout<<Stud2[i].marks[k]<<' ';
			cout<<endl;
			++c;
		}
		if(c=0) cout<<"Нет никого со средним балом больше 4"<<endl;
	}
    cout<<"Запись в файл"<<endl;
	ofstream out("finish.txt",ios::binary);
	for(int i = 0; i < n; i++) 
	{
		out<<resetiosflags(ios::right);
		out.setf(ios::left);
		out<<setw(20)<<setfill('.');
		out<<Stud2[i].fio;
		out<<setw(20);
		out.setf(ios::right);
		out<<Stud2[i].group;
		out<<setw(5)<<setfill(' ');
		out.setf(ios::right);
		for (int k=0; k<5; ++k)
			out<<Stud2[i].marks[k]<<' ';
		out<<endl;
	}
	out<<"Отличники"<<endl;
	for(int i = 0; i < n; i++) 
	{
		int sbal=0, c=0;
		for (int k=0; k<5; ++k)
			sbal+=Stud2[i].marks[k];
		if((sbal/5)>4)
		{
			out<<resetiosflags(ios::right);
			out.setf(ios::left);
			out<<setw(20)<<setfill('.');
			out<<Stud2[i].fio;
			out<<setw(8);
			out.setf(ios::right);
			out<<Stud2[i].group;
			out<<setw(5)<<setfill(' ');
			for (int k=0; k<5; ++k)
				out<<Stud2[i].marks[k]<<' ';
			out<<endl;
			++c;
		}
		if(c=0) out<<"Нет никого со средним балом больше 4"<<endl;
	}
	bincin.close();
	cin.get();
    cin.get();
	return 0;
}

/*
Входной файл:
Сидоров
1
5 4 5 4 3
Максименко
2
5 5 5 5 5
Петров
1
3 4 3 4 4
Клименко
3
5 5 4 4 3
Василенко
1
4 5 4 3 4

Исходящий файл:
Сидоров................................1    5 4 5 4 3 
Петров.................................1    3 4 3 4 4 
Василенко..............................1    4 5 4 3 4 
Максименко.............................2    5 5 5 5 5 
Клименко...............................3    5 5 4 4 3 
Отличники
Максименко.................2    5 5 5 5 5 
*/