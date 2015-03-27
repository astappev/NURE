#include <iostream>
using namespace std;

int main ()
{
	int n,m;
	cout<<"Vvedite n,m"<<endl;
	cin>>n>>m;

	int** matr = new int* [n];
	for(int i=0; i<n;++i)
		matr[i]=new int [m];


	for(int i=0;i<n;++i, cout<<'\n')
		for(int j=0;j<m;++j)
		{
			matr[i][j]=rand()%100;
			cout<<matr[i][j]<<'\t';
		}


		for(int i=0;i<m-1;++i)
			for(int j=0;j<m-1-i;++j)
			{
				if(matr[2][j]>matr[2][j+1])
				{
					for(int k=0;k<n;++k)
					{
						int c=matr[k][j];
						matr[k][j]=matr[k][j+1];
						matr[k][j]=c;
					}
				}
			}


			for(int i=0;i<n;++i, cout<<'\n')
				for(int j=0;j<m;++j)
					cout<<matr[j][i]<<'\t';


			for(int i=0;i<n;++i)
				delete[] matr[i];
			delete[] matr;
			return 0;
			cin.get();
			cin.get();
}