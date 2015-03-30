//�������� ����				���-12-1	�� 3

#include <iostream>
#include <locale>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	//������� �������������
	const int n = 25;
	double h = 1;
	double **matr = new double*[n];
	for (int i(0); i<n; i++)
		matr[i] = new double[2];

	//c������ y
	double x = 0., y;
	for (int i = 0; i < n; i++)
	{
		x+=h;
		if (x <= n / 9)
			y = 0;
		else if (x <= 4 * n / 9) // ���������� 2 ������ 4-� (�������� ������ ��������� ���  ������� ������).
			y = i - n / 9;
		else if (x <= 7 * n / 9)
			y = 7*n/9-i;
		else
			y = 0;
		matr[i][0] = x, matr[i][1] = y;
	}
	// ����� ��� x, y
	cout << "������� �������� XY:" << endl;
	for (int i = 0; i < n; i++, cout << '\n')
		cout << "X = " << matr[i][0] << ", Y = " << matr[i][1];

	//������� ����� � ������, ����� �������
	int center=0, begin = 0, end=0; //cenetr - ����� ������ (���� �� 2 - ������� ������), begin -������ �������, end - ��������� ��������� �����
	while (matr[begin][1] == 0) begin++;
	center = begin;
	while (!(matr[center - 1][1] < matr[center][1] && matr[center][1] >= matr[center + 1][1])) center++;
	end = center;
	while (matr[end][1] > 0) end++;
	int size = end - begin, write = 0; //size - ���-�� ��������� ��������� �������, write(-1) - ������� ��������� �������� � finaly
	double *finaly = new double[size]; //������ ��� �������� ��������������� �������� y
	finaly[write++] = matr[center][1];

	//�������, "��� ���� ������ 2".
	if (matr[center][1] == matr[center + 1][1])
	{
		cout << "\n������ - " << begin + 1 << ", �������� - " << center + 1 << ", " << center + 2  << ", ����� - " << end-- << ", ������ - " << size << endl;
		finaly[write++] = matr[center + 1][1];
	}
	else
	{
		cout << "\n������ - " << begin + 1 << ", �������� - " << center + 1 << ", ����� - " << end-- << ", ������ - " << size << endl;
	}

	//������ ����������, �������� �������
	int ii = begin, jj = end, k = size - 1;
	while (ii != jj && ii < center && jj > (center + write - 1))
	{
		if (matr[ii][1]>matr[jj][1]) finaly[k] = matr[jj][1], k--, jj--;
		else if (matr[ii][1]<matr[jj][1]) finaly[k] = matr[ii][1], k--, ii++;
		else finaly[k] = matr[jj][1], k--, jj--, finaly[k] = matr[ii][1], k--, ii++;
	}
	
	//��������� � ��������� �����, ���� ����� ���� �� ������ ������ ������.
	if (write != k - 1)
	{
		while (ii < center) finaly[k] = matr[ii][1], k--, ii++;
		while (jj > (center + write - 1)) finaly[k] = matr[jj][1], k--, jj--;		
	}

	//����� ��������������� �������
	cout << "\n��������������� ������ Y:" << endl;
	for (int f = 0; f < size; f++, cout<<' ')
		cout << finaly[f];
	
	cin.get();
	return 0;
}