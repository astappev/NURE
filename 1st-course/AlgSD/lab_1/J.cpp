#include <iostream>

int main()
{
	int A=0, B=0, sum=0;
	std::cin>>A>>B;

	while(A>=1 && B>=1){
		if (A>B){
			sum+=A/B;
			A%=B;
		}
		else
		{
			sum+=B/A;
			B%=A;
		}
	}
	std::cout<<sum;
}



