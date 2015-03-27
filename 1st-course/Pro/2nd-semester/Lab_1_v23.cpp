#include <iostream>

int main()
{
	int x=4;
	double y=0.0, y_sum=0.0, f1=1.0, f2=1.0;
	int k=1;

	do{
		f1*=x*x;
		f2*=k*2;
		y=f1/f2;
		++k;
		y_sum+=y;
	}while(y>0.0001);

	std::cout<<y_sum<<'\n';
	return 0;
}