/*
�������� ����
������������ �2
������� 1.

���� ����� A � ����������� ����� b1,b2,b3...,bn. ���������� � ����������� �������� ���������� �� ��������:
a) c=(...((A-b1)-b2)-...-bn)
b) c=A-[Sum �� i=1 �� n]b[i]
*/

#include <iostream>
#include <locale>
using namespace std;

int req_line(int *mas, int n, int a)
{
	if (n == 0) return a;
	else return req_line(mas + 1, --n, a - *mas);
}
int line(int *mas, int n, int a)
{
	if (n != 0)
	{
		for (int i = 0; i < n; ++i)
			a -= *(mas + i);
	}
	return a;
}

int req_sum(int *mas, int n, int sum)
{
	if (n == 0) return sum;
	else return req_sum(mas + 1, --n, sum + *mas);
}
int sum(int *mas, int n, int sum)
{
	if (n != 0)
	{
		for (int i = 0; i < n; ++i)
			sum += *(mas + i);
	}
	return sum;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	int a, n;
	cout << "������� A: ";
	cin >> a;
	cout << "������� ���-�� ��������� ������������������: ";
	cin >> n;
	int *b = new int[n];
	cout << "�������� �������� ������������������: ";
	for (int i = 0; i < n; ++i)
		cin >> b[i];

	cout << "\na) " << req_line(b, n, a);
	cout << "\n�� ����������: " << line(b, n, a);
	cout << "\n�) " << a - req_sum(b, n, 0);
	cout << "\n�� ����������: " << a - sum(b, n, 0);
	cout << endl;

	cin.get();
	cin.get();
	return 0;
}