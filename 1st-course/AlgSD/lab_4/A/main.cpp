#include <iostream>
#include <stdio.h>
using namespace std;

int main()
{
	freopen("input.txt", "r", stdin);
	int n;
	cin>>n;
	int *mas = new int[n];
	for(int i = 0; i < n; ++i)
		cin>>mas[i];
	int c, t;
	cin>>c;
	for(int i = 0; i < c; ++i)
	{
		cin>>t;
		--mas[t-1];
	}
	for(int i = 0; i < n; ++i)
	{
		if(mas[i]>=0) cout<<"no"<<endl;
		else cout<<"yes"<<endl;
	}
	return 0;
}