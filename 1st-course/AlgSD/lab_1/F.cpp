#include <iostream>
#include <math.h>

using namespace std;

int main()
{
	int n; 
	cin>>n;
	double y=sqrt(n);

	for(int i=2; i<=y; i++)
	{
		while (n>1 && n%i==0){
			cout<<i<<" ";
			n/=i;
		}       
	}
	if (n>1) cout<<n;

	return 0;
}
