#include <iostream>
#include <locale>
using namespace std;

double Newton(int n, double x, double *x_mas, double *y_mas, double h)
{
	double **y_matr = new double*[n];
	for (int i = 0; i < n; ++i)
	{
		y_matr[i] = new double[n];
		y_matr[0][i] = y_mas[i];
	}

	for (int i = 1; i < n; i++)
	for (int j = 0; j < n - i; j++)
		y_matr[i][j] = y_matr[i - 1][j + 1] - y_matr[i - 1][j];

	double y, yi, q;
	if (x < x_mas[5])
	{
		q = (x - x_mas[0]) / h;
		y = y_matr[0][0] + q*y_matr[1][0];
		for (int i = 2; i < n; i++)
		{
			yi = 1;
			for (int j = 2; j < i + 1; j++)
				yi *= (q - j + 1) / j;

			y += yi*y_matr[i][0] * q;
		}
	}
	else
	{
		q = (x - x_mas[n - 1]) / h;
		y = y_matr[0][n - 1] + q*y_matr[1][n - 2];
		for (int i = 2; i < n; i++)
		{
			yi = 1;
			for (int j = 2; j < i + 1; j++)
				yi *= (q + j - 1) / j;
			y += yi*y_matr[i][10 - i] * q;
		}
	}

	return y;
}

double Lagrange(int n, double x, double *x_mas, double *y_mas)
{
	double y=0.;
	for (int j = 0; j < n; j++)
	{
		double l = 1.;
		for (int i = 0; i < n; i++)
			if (i != j) l = ((x - x_mas[i]) / (x_mas[j] - x_mas[i]))*l;

		y += y_mas[j] * l;
	}

	return y;
}

double f(double x)
{
	return x*x + log(x);
}

int main()
{
	setlocale(LC_ALL, "Russian");

	int n = 11;
	double a = 0.4, b = 0.9, h = (b - a) / 10;

	double *x = new double[n];
	double *y = new double[n];

	for (int i = 0; i < n; i++)
	{
		x[i] = a + i*h, y[i] = f(x[i]);
		cout << i + 1 << ":\tx = " << x[i] << ",\t y = " << y[i] << '\n';
	}

	cout << "\nДля Х = x4 + 0.021 (" << x[3] + 0.021 << "):\n\tПо методу Лагранжа:\t\t y = " << Lagrange(n, x[3] + 0.021, x, y) << "\n\tПо методу Ньютона:\t\t y = " << Newton(n, x[3] + 0.021, x, y, h) << "\n\tПодстановкой в функцию: \t y = " << f(x[3] + 0.021) << endl;
	cout << "\nДля Х = x7 + 0.0146 (" << x[6] + 0.0146 << "):\n\tПо методу Лагранжа:\t\t y = " << Lagrange(n, x[6] + 0.0146, x, y) << "\n\tПо методу Ньютона:\t\t y = " << Newton(n, x[6] + 0.0146, x, y, h) << "\n\tПодстановкой в функцию: \t y = " << f(x[6] + 0.0146) << endl;

	cin.get();
	cin.get();
	return 0;
}