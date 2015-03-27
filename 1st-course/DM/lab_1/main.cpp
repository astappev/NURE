#include <iostream>
using namespace std;

int main()
{
	bool f;
	cout<<"A\tB\tC\tD\t\tf\n----------------------------------------\n";
	for (int a=0; a<2; ++a)
	   for (int b=0; b<2; ++b)
		for (int c=0; c<2; ++c)
		  for (int d=0; d<2; ++d)
			{
				f=!(!a&&b&&d||!c&&a)||!(b&&d||!(a&&d&&c));
				cout<<a<<'\t'<<b<<'\t'<<c<<'\t'<<d<<"\t\t"<<f<<'\n';
			}

	cin.get();
	return 0;
}