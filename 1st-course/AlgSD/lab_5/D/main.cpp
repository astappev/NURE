/*
����������� ������
������ S ���� �������� ����� ��� ������, ����� ���� �� ������������ ������ ����� ��������� � ���� ���.
���� ������ ���������� ����������� ��������� ����� �������� ������ S.

N-P[N] (p - �������-�������, N - ����� ������)
*/
#include <iostream>
#include <cstdlib>
#include <vector>
#include <cstring>
#include <string>
using namespace std;

vector<int> compute_prefix_function(const string& s)
{
	int len = s.length(); //�������� �������-�������
	vector<int> p(len); //������ ������� ������������� ������ ���������� ������� ���������
	p[0]=0; //��� �������� �� 0 � ������� �� 1 ������� ������� ����� 0
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