#include <iostream>
#include <cmath>
#include <locale>
using namespace std;

bool converge(double *x, double *prev, double epsilant, int n)
{
	for (int i = 0; i < n; i++)
	{
		if (fabs(x[i] - prev[i]) >= epsilant)
			return false;
	}
	return true;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	const int n = 3;
	double b[n] = { 8, -2, 21 };
	double a[n][n] = { -6, 3, 3, 2, -4, 1, 3, -1, 5 };
	double epsilant = 0., x[n] = { 0, 0, 0 }, prev[n];

	bool isExit;
	do{
		do{
			cout << "������� ��������: ";
			cin >> epsilant;
		} while (epsilant <= 0 || epsilant >= 1);
		
		int count = 0;
		do
		{
			count++;
			for (int i = 0; i < n; i++)
				prev[i] = x[i];

			for (int i = 0; i < n; i++)
			{
				double var = 0;

				for (int j = 0; j < i; j++)
					var += (a[i][j] * x[j]); // �������� ����� ����� �� ������� ���������

				for (int j = i + 1; j < n; j++)
					var += (a[i][j] * prev[j]); // ������� ������ ����� ����� ������� ���������

				x[i] = (b[i] - var) / a[i][i];
			}
		} while (!converge(x, prev, epsilant, n)); // ��������� ����������� ���������


		cout << "�� ���������� �� " << count << " ��������, � ���� X �����:" << endl;
		for (int i = 0; i < n; i++)
			cout << 'X' << i + 1 << " = " << x[i] << '\t';
		cout << endl;

		for (int i = 0; i < n; i++)
			cout << "���������� � ���� ���������, ����� = " << x[0] * a[i][0] + x[1] * a[i][1] + x[2] * a[i][2] << ", � ������� ���� = " << b[i] << ".\n";

		char answer;
		cout << "\n\n������ ���������? (Y|N)";
		cin >> answer;

		if (answer == 'Y' || answer == 'y') isExit = true;
		else isExit = false;
	} while (isExit);
	

	return 0;
}