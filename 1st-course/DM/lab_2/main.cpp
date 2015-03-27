#include <iostream>
using namespace std;

int main()
{
	int sum = 0;
	for (int i = 1; i <= 5; i++)
		for (int j = 1; j <= 5; j++)
			if (i != j)
			{
				++sum;
				cout<<i<<", "<<j<<endl;
			}
	cout<<"Kolichestvo podmnozestv = "<<sum;
	cin.get();
	return 0;
}
