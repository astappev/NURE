#include <locale>
#include <iostream>
using namespace std;
void size_way(int *matr, int *size, int a, int n)
{
	for(int i=0; i<n; ++i)
	{
		int k;
		if(size[2*n+a]==1) k=0;
		else k=1;
		if(matr[a*n+i]>0 && size[k*n+i]>=0 && size[2*n+i] == 0)
			size[k*n+i]=matr[a*n+i];
	}
}
void free_matr(int *size, int &free, int n)
{
	free=0;
	for(int i=0; i<n; ++i)
		if((size[0*n+i] != 0 || size[1*n+i] != 0) && size[2*n+i] == 0) ++free;
}
void min_matr(int *size, int &min, int i, int n)
{
	int min_value=999;
	for(int j=0; j<n; ++j)
		if(size[i*n+j] != 0 && min_value>size[i*n+j] && size[2*n+j] == 0)
		{
			min_value=size[i*n+j];
			min=j;
		}
}
int main()
{
	setlocale(LC_ALL, "Russian");
	freopen ("input.txt", "r", stdin);
	const int n=5; //размер матрицы
	int a, b; //входные точки
	int matr[n][n];
	for(int i = 0; i < n; ++i)
		for(int j =0; j < n; ++j)
			cin>>matr[i][j];

	cin>>a>>b;
	int size[3][n];

	for(int i = 0; i < 3; ++i)
		for(int j = 0; j < n; ++j)
			size[i][j]=0;

	size[2][a]=1;
	size[2][b]=2;
	size_way(&matr[0][0], &size[0][0], a, n);
	size_way(&matr[0][0], &size[0][0], b, n);

	int free;
	free_matr(&size[0][0], free, n);

	while (free != 0)
	{
		int mina=0, minb=0;
		min_matr(&size[0][0], mina, 0, n);
		min_matr(&size[0][0], minb, 1, n);
		if(mina == minb)
		{
			size[2][mina]=3;
		}
		else 
		{
			if(mina != 999)
			{
				size[2][mina]=1;
				size_way(&matr[0][0], &size[0][0], mina, n);
			}
			if(minb != 999)
			{
				size[2][minb]=2;
				size_way(&matr[0][0], &size[0][0], minb, n);
			}
		}
		free_matr(&size[0][0], free, n);
	}

	cout<<"Здесь результат: (вершины нумуруются с 0)"<<endl;
	cout<<"Вершины которые пренадлежат, вершине "<<a<<": ";
	for(int j = 0; j < n; ++j)
		if(size[2][j]==1) cout<<j<<' ';
	cout<<"\nВершины которые пренадлежат, вершине "<<b<<": ";
	for(int j = 0; j < n; ++j)
		if(size[2][j]==2) cout<<j<<' ';
	cout<<"\nИзолированые вершины: ";
	for(int j = 0; j < n; ++j)
		if(size[2][j]==0) cout<<j<<' ';
	cout<<"\nВершины покушение на которые было одновременным: ";
	for(int j = 0; j < n; ++j)
		if(size[2][j]==3) cout<<j<<' ';
	cout<<endl;
	return 0;
}