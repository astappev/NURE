#include <iostream>
#include <math.h>
using namespace std;

int simple(int n)
{
	for(int i=2; i<=sqrt(n); i++)
		if((n%i)==0)
			 return 0;
	return 1;
}
 
int main()
{
	int n, p;
	cin>>n;
	for(int i=2; i<n; ++i)
	{
		int k;
		if(simple(i)) k=n-i;
		else continue;

		if(simple(k))
		{
			cout<<k<<' '<<i;
			break;
		}
	}
}
