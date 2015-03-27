/*
Дана целочисленная прямоугольная матрица. Определить:
1)  количество строк, не содержащих ни одного нулевого элемента;
2)  максимальное из чисел, встречающихся в заданной матрице более одного раза.

Кроме того каждый разрабатываемый основной класс должен реализовывать:
1. конструктор по умолчанию
2. деструктор
3. конструкторы с параметрами
4. конструктор копирования
5. перегруженную операцию присваивания

Реализовать следующие методы:
1.заполнение данных случайным образом;
2.сортировку указанной строки матрицы.
*/
#include <iostream>
#include <locale>
#include <time.h>
using namespace std;

class Matrica
{
	int **matr;
	int n,m;
public:
	Matrica();
	Matrica(int,int);
	Matrica(Matrica &);
	~Matrica();

	void Rand(int);
	void OtrWithNull();
	void SedlPoints();

	friend ostream& operator<<(ostream&,Matrica&);
	Matrica& operator=(Matrica&);
};

Matrica::Matrica()
{	this->n=5; 
	this->m=7;
	matr=new int*[n];
	for(int i(0);i<n;i++)
		matr[i]=new int[m];
}
Matrica::Matrica(int n, int m)
{	
	this->n=n; 
	this->m=m; 
	if(n==m)
		cout<<"Ошибка. Матрица не должна быть квадратной!"<<endl;
	else
	{
		matr=new int*[n];
		for(int i(0);i<n;i++)
			matr[i]=new int[m];
	}
}
Matrica::Matrica(Matrica &obj)
{
	this->n=obj.n; 
	this->m=obj.m; 
	matr=new int*[n];
	for(int i(0);i<n;i++)
		matr[i]=new int[m];
	for(int i(0);i<n;i++)
		for(int j(0);j<m;j++)
			matr[i][j]=obj.matr[i][j];
};
Matrica::~Matrica()
{
	for(int i(0);i<n;i++)
		delete[]matr[i];
	delete[]matr;

}
void Matrica::Rand(int k)
{
	srand(time(NULL));
	for(int i(0);i<n;i++)
		for(int j(0);j<m;j++)
			matr[i][j]=rand()%k*2-k;
}
void Matrica::OtrWithNull() //количество отрицательных элементов в строке содержащей 0
{
	int count=0;
	for(int i(0);i<n;i++)
	{
		bool null=false;
		for(int j(0);j<m;j++)
		{
			if(matr[i][j]<0) count++;
			else if(matr[i][j]==0) null=true;
		}
		if(null==true) cout<<"В "<<i+1<<" строке, "<<count<<" отрицательных элементов.\n";
		else cout<<"В "<<i+1<<" строке, нулевых элементов нет.\n";
		count=0;
	}
}
void Matrica::SedlPoints()
{
	int min=0, jmin=0, max=0, imax=0;
	for(int i=0; i<n; i++)
	{
		min=matr[i][0];
		for(int j=0; j<m; j++)
		{
			if(matr[i][j]<min)
			{
				min=matr[i][j];
				jmin=j;
			}
		}
		max=matr[0][jmin];
		for(int k=0; k<n; k++)
		{
			if(matr[k][jmin]>max)
			{
				max=matr[k][jmin];
				imax=k;
			}
		}
		if(max==min) cout<<"Седловая точка, значением "<<matr[imax][jmin]<<". Находится в строке "<<imax+1<<", столбце "<<jmin+1<<endl;
	}
}
ostream& operator<<(ostream& out,Matrica& obj) //используетя для вывода
{
	for(int i(0);i<obj.n;out<<'\n',i++)
		for(int j(0);j<obj.m;j++)
		{
			out<<obj.matr[i][j]<<'\t';
		}
	return out;
}
Matrica& Matrica::operator=(Matrica& obj)
{
	if(this==&obj) return *this;
	this->~Matrica();
	this->n=obj.n; 
	this->m=obj.m; 
	matr=new int*[n];
	for(int i(0);i<n;i++)
		matr[i]=new int[m];
	for(int i(0);i<n;i++)
		for(int j(0);j<m;j++)
			matr[i][j]=obj.matr[i][j];
	return *this;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	
	Matrica dmatr, pmatr(3,5);
	dmatr.Rand(9);
	pmatr.Rand(20);	
	cout<<"Матрица по умолчанию:\n"<<dmatr<<endl;
	dmatr.OtrWithNull();
	dmatr.SedlPoints();

	cout<<"\n\nМатрица с параметрами:\n"<<pmatr<<endl;
	pmatr.OtrWithNull();
	pmatr.SedlPoints();
	

	return 0;
}
