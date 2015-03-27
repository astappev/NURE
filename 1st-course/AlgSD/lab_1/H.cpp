#include <iostream>
using namespace std;
 
unsigned long long Nod(long a, long b)
{
    while (a && b)
        if (a >= b)
           a %= b;
        else
           b %= a;
    return a | b;
}

int main()
{
	unsigned long long m,n,p,k,t;
	std::cin>>m>>n>>p;

	k=(m*n-(m+n-Nod(m,n)))/2;

	t=k%p;
	k=p-t;
	if(t<=0) k=0;
	std::cout<<k;
	return 0;
}