#include <iostream>
#include <cstdlib>
using namespace std;

int main()
{
	int n, e=0;
	cout<<"Vvedite n: ";
	cin>>n;
	
	for(int i = 2; i < n; ++i)
	{
		for(int j = 2; j <= i; ++j)
		{
			if(n%j == 0 && i%j == 0)
			{
				++e;
				break;
			}
		}
	}
    cout<<"Chislo Eylera = "<<n-1-e<<endl;
return 0;
}
