/*
Описать структуру с именем COMP, содержащую следующие поля:
- название компьютера;
- рейтинговая частота процессора;
- количество ОЗУ.
Написать программу, выполняющую следующие действия:
- ввод с клавиатуры данных в массив, состоящий из восьми элементов типа COMP; 
- вывод на экран список компьютеров у которых мощность процессора выше среднего;
*/

#include <iostream>
#include <fstream>
#include <iomanip>
#include <locale>
using namespace std;

struct COMP{
	char name[90];
	double cp;
	int ram;
};

int binout (COMP *Comps, int n)
{
	ofstream binout("f2.txt",ios::binary);
	for(int i = 0; i < n; i++)
		binout.write((char*)&Comps[i],sizeof(COMP));
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
	const int n = 8;
	COMP Comps[n];

	for(int i = 0; i < n; i++)
	{
		char str[90];
		innn.getline(Comps[i].name,90);
		innn.getline(str,90);
		Comps[i].cp = atoi(str);
		innn.getline(str,90);
		Comps[i].ram = atoi(str);
	}
	binout (Comps, n);
	COMP Comps2[n];
	ifstream bincin("f2.txt",ios::binary);
	for(int i = 0; i < n; i++)
		bincin.read((char*)&Comps2[i],sizeof(COMP));
		bincin.close();

	//Вычисление средней частоты
	double rcp=0;
	for (int i = n; i < n; ++i)
	{
		rcp+=Comps[i].cp;
	}
	rcp/=n;

	cout<<"Проверка: чтения, записи в бинарник, чтения из него."<<endl;
	for(int i = 0; i < n; i++) 
	{
		cout<<resetiosflags(ios::right);
		cout.setf(ios::left);
		cout<<setw(20)<<setfill('.');
		cout<<Comps2[i].name;
		cout<<setw(8);
		cout.setf(ios::right);
		cout<<Comps2[i].cp;
		cout<<setw(5)<<setfill(' ');
		cout<<Comps2[i].ram<<' ';
		cout<<endl;
	}

	cout<<"Вывод с частотой >= средней"<<endl;
	for(int i = 0; i < n; i++) 
	{
		if(Comps[i].cp>=rcp)
		{
			cout<<resetiosflags(ios::right);
			cout.setf(ios::left);
			cout<<setw(20)<<setfill('.');
			cout<<Comps2[i].name;
			cout<<setw(8);
			cout.setf(ios::right);
			cout<<Comps2[i].cp;
			cout<<setw(5)<<setfill(' ');
			cout<<Comps2[i].ram<<' ';
			cout<<endl;
		}	
	}
    cout<<"Запись в файл"<<endl;
	ofstream out("finish.txt",ios::binary);
	for(int i = 0; i < n; i++) 
	{
		out<<resetiosflags(ios::right);
		out.setf(ios::left);
		out<<setw(20)<<setfill('.');
		out<<Comps2[i].name;
		out<<setw(20);
		out.setf(ios::right);
		out<<Comps2[i].cp;
		out<<setw(5)<<setfill(' ');
		out.setf(ios::right);
		out<<Comps2[i].ram<<' ';
		out<<endl;
	}
	bincin.close();
	cin.get();
    cin.get();
	return 0;
}

/*
begin.txt
Asus
4.6
1024
HP
3.2
4056
Samsung
5.1
8112
LG
4.1
4056
Apple
1.1
2048
Panasonic
1.6
2048
Acer
3.4
2048
Lenovo
4.1
4056
*/