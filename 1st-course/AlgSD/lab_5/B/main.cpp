//должно
//ћаксимальный подпалиндромы
/*
ƒана непуста€ строка, длина которой не превышает 10^6. “ребуетс€ дл€ каждой позиции символа в строке найти
длину наибольшего палиндрома с центром в этом символе. —трока состоит из букв английского алфавита, большие
и маленькие буквы считаютс€ различными. ќграничение времени - 1 секунда.
*/
#include <iostream>
#include <cstdlib>
#include <cstring>
#include <vector>
#include <string>
using namespace std;

int main()
{
	freopen("input.txt", "rt", stdin);
	freopen("output.txt", "wt", stdout);

	string s;
	cin>>s;

	int n = s.size();
	vector<int> vect(n);
	int l = 0, r = -1;

	for (int i = 0; i < n; ++i)
	{
		int k;
		if (i > r)
			k = 1;
		else
			k = min(vect[l + r - i], r - i);

		while ((i + k < n) && (i - k >= 0) && (s[i + k] == s[i - k]))
			++k;

		vect[i] = k--;

		if (i + k > r)
		{
			l = i - k;
			r = i + k;
		}
	}
	for (int i = 0; i < n; i++)
		cout<<2*vect[i] - 1<<' ';

	return 0;
}