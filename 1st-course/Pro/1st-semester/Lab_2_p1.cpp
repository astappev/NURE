#include <iostream>
using namespace std;

int main()
{
	const int n=5, m=6;
	int matr[n][m];
	int mas[n];
	for (int i=0; i<n; i++)
		for (int j=0; j<m; j++)    
			matr[i][j]=rand()%47-10;
	
	for (int i=0; i<n; cout<<'\n', ++i)
		for (int j=0; j<m; j++)
			cout<<matr[i][j]<<'\t';

	for (int i=0; i<n; ++i)
	{
		int min=matr[i][0];

		for (int j=0; j<m; ++j)
		{
			if (matr[i][j]<min) min=matr[i][j];
			mas[i]=min;			
		}
	}

	for (int i=0; i<n; ++i)
		cout<<"V "<<i+1<<" radku, naimenshoe znachenie = "<<mas[i]<<'\n';

	int max=0, nomer=0;
	for (int i=0; i<n; i++)
		if (mas[i]>max)
			{
				max=mas[i];
				nomer=i+1;
			}
	cout<<"Nomer maksimalnogo iz nih: "<<nomer;

	cin.get();
	cin.get();
	return 0;
}