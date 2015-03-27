#include <iostream>
using namespace std;

int main()
{
	const int n=5;
	int matr[n][n];
	for (int i=0; i<n; i++)
		for (int j=0; j<n; j++)    
			matr[i][j]=rand()%35;

	cout<<"Default"<<endl;
	for (int i=0; i<n; cout<<'\n', ++i)
		for (int j=0; j<n; j++)
			cout<<matr[i][j]<<'\t';

	cout<<"\n\nPeresobran"<<endl;
	for (int j=0; j<n; ++j)
	{
		for (int i=0; i<n; ++i)
		{
			if (matr[i][j]>matr[0][j]) matr[0][j]=matr[i][j];
		}
	}
	for (int i=0; i<n; cout<<'\n', ++i)
		for (int j=0; j<n; j++)
			cout<<matr[i][j]<<'\t';

	cout<<"\n\nOtsorterovana pobochnaya diagonal"<<endl;
	for(int i=0; i<n-1; ++i)
		for(int j=0; j<n-1-i; ++j)
		{
			if(matr[j][n-1-j]>matr[j+1][n-j])
			{
				int c=matr[j][n-1-j];
				matr[j][n-1-j]=matr[j+1][n-j];
				matr[j+1][n-j]=c;
			}
		}
	for (int i=0; i<n; cout<<'\n', ++i)
		for (int j=0; j<n; j++)
			cout<<matr[i][j]<<'\t';

	int s=0;
	for(int i=0; i<n; ++i)
		for(int j=0; j<n; ++j)
		{
			if(i<j) s+=matr[i][j];
		}
	cout<<"\n\nSumma elementov vishe glavnoy diagonali = "<<s<<endl;
	cin.get();
	cin.get();
	return 0;
}