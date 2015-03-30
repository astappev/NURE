#include <iostream>
using namespace std;

double f(double x)
{
	return (7 * x*x*x*x - x*x*x + 6 * x*x - 9 * x - 12);
}
double fp(double x)
{
	return (28 * x*x*x - 3 * x*x + 12 * x - 9);
}
double fpp(double x)
{
	return (168 * x - 6);
}

double Trap(int a, int b, double n)
{

	double h = (b - a) / n;
	double sum = 0.;
	for (double i = a; i < b; i += h)
		sum += (f(i) + f(i + h));
	return sum*h*0.5;
}

double Parab(int a, int b, double n)
{
	double h = (b - a) / n;
	double sum = 0.;
	for (double i = a; i < b; i += h)
	{
		sum += (h / 6)*(f(i) + 4 * f((i + h + i) / 2.0) + f(i + h));
	}
	return sum;
}

double PTrap(int a, int b, double n)
{
	double max;
	if (abs(fp(a)) > abs(fp(b)))
		max = abs(fp(a));
	else
		max = abs(fp(b));

	return (pow(b - a, 3) * max) / (12 * n*n);
}

double PParab(int a, int b, double n)
{
	double max;
	if (abs(fpp(a)) > abs(fpp(b)))
		max = abs(fpp(a));
	else
		max = abs(fpp(b));

	return (pow(b - a, 5) * max) / (pow(n, 4) * 2880);
}

int main()
{
	setlocale(LC_ALL, "Russian");

	int a = 0, b = 3;
	double n = 1000;

	cout << "Вычисление интеграла методом парабол: " << Parab(a, b, n) << endl;
	cout << "Вычисление интеграла методом трапеций: " << Trap(a, b, n) << endl;
	cout << endl; // 15.4667
	cout << "Вычисление похибки метода трапеций: " << PTrap(a, b, n) << endl;
	cout << "Вычисление похибки метода парабол: " << PParab(a, b, n) << endl;

	return 0;
}