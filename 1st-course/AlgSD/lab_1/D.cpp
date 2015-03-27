#include <iostream>
using namespace std;

int main()
{
	int a,b,c,d;
	cin>>a;
	cin>>b;
	c=a;
	d=b;
	while(a!=b){
		if(a>b) b+=d;
		else a+=c;
	}
	cout<<a;
}