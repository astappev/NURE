/*
������� ���������, ������� ������ c ���������� ������ ����� � ��� ���
������ � �������� � ������� ��� �������, ��������� � ������ ������, ��
��������������� ������� ������ ������ (����������� ������). ������
����������������� ������ � ������ ��� "������"-"����� �����".
*/

#include <iostream>
#include <vector>
#include <string>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	vector<string> mas;
	string find, replace;
	int n;

	cout << "������� ����� ���������� �������� � ������? ";
	cin >> n;
	for (int i = 0; i < n; ++i)
	{
		cin.get();
		string t;
		getline(cin, t, '\n');
		mas.push_back(t);
	}
	cout << "������� ������ �������� ������: ";
	cin >> find;
	cout << "������� ������ �������� ������: ";
	cin >> replace;

	if (find.length() == replace.length())
	{
		int *counter = new int[find.length()];
		for (int j = 0; j < find.length(); ++j) counter[j] = 0;
		for (int i = 0; i < mas.size(); ++i)
		for (int j = 0; j < find.length(); ++j)
		{
			while (mas[i].find(find[j]) != -1)
			{
				counter[j]++;
				int k = mas[i].find(find[j]);
				mas[i].replace(k, 1, replace, j, 1);
			}
		}

		for (int i = 0; i < mas.size(); ++i, cout << '\n')
			cout << mas[i];

		for (int j = 0; j < find.length(); ++j)
			cout << '\'' << find[j] << "' ����� - " << counter[j] << endl;
	}
	else cout << "�������� � ����� ����� �������� � �������� �������" << endl;

	
}