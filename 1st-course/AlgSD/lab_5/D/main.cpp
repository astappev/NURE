/*
Циклическая строка
Строка S была записана много раз подряд, после чего из получившиеся строки взяли подстроку и дали вам.
Ваша задача определить минимальную возможную длину исходной строки S.

N-P[N] (p - префикс-функция, N - длина строки)
*/
#include <iostream>
#include <cstdlib>
#include <vector>
#include <cstring>
#include <string>
using namespace std;

vector<int> compute_prefix_function(const string& s)
{
	int len = s.length(); //значение префокс-функции
	vector<int> p(len); //индекс вектора соответствует номеру последнего символа агрумента
	p[0]=0; //для префикса из 0 и функции из 1 символа функция равна 0
	int k=0;
	for(int i = 1; i < len; ++i)
	{
		while(k>0 && s[k] != s[i])
			k=p[k-1];
		if(s[k] == s[i])
			k++;
		p[i] = k;
	}
	return p;
}

int main()
{
	freopen("input.txt", "r", stdin);
	//freopen("output.txt", "w", stdout);
	string s;
	cin>>s;
	int len = s.length();
	vector<int> p =	compute_prefix_function(s);
	int t = len-p[len-1];
	
	cout<<t;
	return 0;
}