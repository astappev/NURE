#include <iostream>
using namespace std;
void randMatr (int *matr, int n, int k)
{
	for (int i = 0; i<n; ++i)
		for (int j = 0; j<n; ++j)
			matr[i * n + j] = rand()%k;
}
void outputMatr (int *matr, int n)
{
	for (int i=0; i<n; ++i, cout<<'\n')
		for (int j = 0; j<n; ++j)
			cout<<matr[i * n + j]<<'\t';
}
void min_elemnent (int *matr, int n)
{
	int min=matr[0];
	for (int i = 0; i<n; ++i)
		for (int j = 0; j<n; ++j)
		{
			if (matr[i*n+j]<min) min = matr[i*n+j];	
		}
	cout<<"\nNaimenshiy elenent = "<<min<<endl;
}
void sortMatr (int *matr, int n)
{
	for (int i = 0; i<n; ++i)
		for (int j = 0; j<n; ++j)
			if(matr[j*n+j]>matr[(j+1)*n+j+1])
			{
				int c=matr[j*n+j];
				matr[j*n+j]=matr[(j+1)*n+j+1];
				matr[(j+1)*n+j+1]=c;
			}
}
int main()
{
	const int n = 4;
	int matr[n][n];
	randMatr (&matr[0][0], n, 17);
	cout<<"Ishodniy masiv"<<endl;
	outputMatr (&matr[0][0], n);
	min_elemnent (&matr[0][0], n);
	sortMatr (&matr[0][0], n);
	cout<<"\nOtsortirovanaya glavnaya diagonal"<<endl;
	outputMatr (&matr[0][0], n);
	return 0;
}