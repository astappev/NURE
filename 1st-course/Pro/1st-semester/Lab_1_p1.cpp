#include <iostream>
#include <math.h>
using namespace std;

int main()
{
	int a,b,c,p;
	double ha,hb,hc;
	cout<<"Vvedite storoni trikutnika A,B,C: ";
	cin>>a>>b>>c;

	p=(a+b+c)/2;
	ha=sqrt(p*(p-a)*(p-b)*(p-c))*2/a;
	hb=sqrt(p*(p-a)*(p-b)*(p-c))*2/b;
	hc=sqrt(p*(p-a)*(p-b)*(p-c))*2/c;

	cout<<"Poluperimetr ABC = "<<p<<endl;
	cout<<"Visota A="<<ha<<endl;
	cout<<"Visota B="<<hb<<endl;
	cout<<"Visota C="<<hc<<endl;
	
	cin.get();
	cin.get();
	return 0;
}