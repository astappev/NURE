/*
���� ������������� ������������� �������. ����������:
1)  ���������� �����, �� ���������� �� ������ �������� ��������;
2)  ������������ �� �����, ������������� � �������� ������� ����� ������ ����.

����� ���� ������ ��������������� �������� ����� ������ �������������:
1. ����������� �� ���������
2. ����������
3. ������������ � �����������
4. ����������� �����������
5. ������������� �������� ������������

����������� ��������� ������:
1.���������� ������ ��������� �������;
2.���������� ��������� ������ �������.
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
		cout<<"������. ������� �� ������ ���� ����������!"<<endl;
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
void Matrica::OtrWithNull() //���������� ������������� ��������� � ������ ���������� 0
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
		if(null==true) cout<<"� "<<i+1<<" ������, "<<count<<" ������������� ���������.\n";
		else cout<<"� "<<i+1<<" ������, ������� ��������� ���.\n";
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
		if(max==min) cout<<"�������� �����, ��������� "<<matr[imax][jmin]<<". ��������� � ������ "<<imax+1<<", ������� "<<jmin+1<<endl;
	}
}
ostream& operator<<(ostream& out,Matrica& obj) //����������� ��� ������
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
	cout<<"������� �� ���������:\n"<<dmatr<<endl;
	dmatr.OtrWithNull();
	dmatr.SedlPoints();

	cout<<"\n\n������� � �����������:\n"<<pmatr<<endl;
	pmatr.OtrWithNull();
	pmatr.SedlPoints();
	

	return 0;
}
