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
	int StrW0();
	int MaxNotOnly();

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
		cout<<"ќшибка. ћатрица не должна быть квадратной!"<<endl;
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
			matr[i][j]=rand()%k;
}
int Matrica::StrW0() //строк без 0 n*m
{
	int nS(0);
	for(int i=0; i<n; i++)
	{
		int t=0;
		for(int j=0; j<m; j++)
			if(matr[i][j]==0) ++t;
		if(t==0) ++nS;
	}
	return nS;
}
int Matrica::MaxNotOnly() //максимальное из чисел, встречающихс€ в заданной матрице более одного раза.
{
	int max=0, count=0, fmax=0;
		do{
			fmax=max;
			max=0;
			for(int i=0; i<n; i++)
				for(int j=0; j<m; j++)
					if(matr[i][j]>max && matr[i][j]!=fmax)
					{
						max=matr[i][j];
						count=1;
					}
					else if (matr[i][j]==max) ++count;
		}while(count==1);
	return max;
}
ostream& operator<<(ostream& out,Matrica& obj) //использует€ дл€ вывода
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
	pmatr.Rand(10);
	cout<<"»сходные матрицы:"<<endl;	
	cout<<"ћатрица по умолчанию:\n"<<dmatr<<endl;
	cout<<"ћатрица с параметрами:\n"<<pmatr<<endl;
	cout<<" оличество строк без 0, в матрице по умочанию: "<<dmatr.StrW0()<<endl;
	cout<<" оличество строк без 0, в матрице с параметрами: "<<pmatr.StrW0()<<endl;
	cout<<"ћаксимальное, не уникальное число в матрице по умолчанию: "<<dmatr.MaxNotOnly()<<endl;
	cout<<"ћаксимальное, не уникальное число в матрице с параметрами: "<<pmatr.MaxNotOnly()<<endl;

	return 0;
}
