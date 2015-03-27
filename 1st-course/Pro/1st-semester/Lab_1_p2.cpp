#include <iostream>
#include <math.h>
using namespace std;

int main()
{
	double a=0.75, b=1.19, c=-2.5, h=0.1, y=1.0, x=2;
	for(x=0;x<2.001;x+=h)
	{
		if(x<=0.5)
		{
			y=a*x+b*cos(x);
			cout<<"x="<<x<<"\ty= "<<y<<endl; 

		}
		else if(x<0.99)
		{
			y=b*pow(x,2)+c*sin(2*x);
			cout<<"x="<<x<<"\ty= "<<y<<endl; 
		}
		else cout<<"x="<<x<<"\tNe vhodit v diapazon"<<endl; 
	}
	cin.get();
	return 0;
}