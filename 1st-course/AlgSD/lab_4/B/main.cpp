#include <iostream>
#include <string>
#include <algorithm>
using namespace std;
 
string get_palindrome(string letters, int n)
{
	sort(letters.begin(), letters.end());
 
	string palindrome;
	char middle;

	bool has_middle = false;

	for (int i = 0; i < n; ++i)
	{
		int cnt = count(letters.begin(), letters.end(), letters[i]); //Возвращает число элементов в диапазоне, значения которого соответствуют указанному значению.
		if (cnt%2 == 1)
		{
			if (!has_middle)
			{
				middle = letters[i];
				has_middle = true;
			}
		}

		palindrome += string(cnt/2, letters[i]);
		i += cnt - 1;
	}

	return palindrome + (has_middle ? string(1, middle) : "") + string(palindrome.rbegin(), palindrome.rend());
}
 
int main()
{
	freopen("input.txt", "r", stdin);
	int n;
	cin>>n;
	string letters;
	cin>>letters;
	cout<<get_palindrome(letters, n);
	return 0;
}