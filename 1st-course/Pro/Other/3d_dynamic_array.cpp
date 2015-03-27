#include <iostream>
using namespace std;
int main()
{
	int n,m,z;
	cin>>n>>m>>z;


	int*** mas3D = new int** [n];
	for (int i=0; i<n; ++i)
	{
		mas3D[i] = new int* [m];
		for (int j=0; j<m; ++j)
		{
			mas3D[i][j]=new int[z];
		}
	}
	for (int i=0; i<n; ++i, cout<<"\n\n")
		for (int j=0; j<m; ++j, cout<<'\n')
			for (int k=0; k<z; ++k)
			{
				mas3D[i][j][k]=rand()%100;
				cout<<mas3D[i][j][k]<<'\t';
			}
	for (int i=0; i<n; ++i)
	{
		for (int j=0; j<m; ++j)
		{
			delete[]mas3D[i][j];
		}
		delete[]mas3D[i];
	}
	delete[]mas3D;
	
	return 0;
	cin.get();
	cin.get();
}