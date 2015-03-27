#include <iostream>
#include <math.h>
using namespace std;
 
int main()
{
 double a=0.5, b=2.9, x=0.3;
 double alfa, beta;
 alfa=(pow(a,x)+pow(b,-x)*sin(a-b))/(sqrt(fabs(a-b)));
 beta=a*exp(-(sqrt(a))*cos(b*x/a));
 cout<<"Alfa="<<alfa<<endl;
 cout<<"Beta="<<beta<<endl;
 cin.get();
 return 0;
}