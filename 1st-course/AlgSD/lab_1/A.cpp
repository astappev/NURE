#include <iostream>
using namespace std;

int main()
{
	int m,n,k;
	cin>>n;
	cin>>m;
	cin>>k;

	if(k>m*n || m*n>30000) cout<<"NO";
	else if(k%n==0 || k%m==0) cout<<"YES";
		else cout<<"NO";
	
}