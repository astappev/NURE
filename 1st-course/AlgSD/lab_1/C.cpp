#include <iostream>
#include <math.h>
using namespace std;

int main()
{
	int k,m,n;
	cin>>k;
	cin>>m;
	cin>>n;
	if (n<k){
		cout<< m*2;
		return 0;
	}
	int time=(n*2)/k;
	if ((n*2)%k==0) cout<<time*m;
	else cout<<(time + 1)*m;
}