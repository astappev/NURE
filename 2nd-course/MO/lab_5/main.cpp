#include <iostream>
#include <vector>
using namespace std;

double f(double x, double y)
{
	return (x*y*y + x) / (y - x*x*y);
}
void Eiler(double h, double xn, double xk, double yn)
{
	vector<double> x, y;
	x.push_back(xn); y.push_back(yn);

	do{
		int i = x.size() - 1;
		cout << i + 1 << ":\t" << "x = " << x[i] << "\t" << "y = " << y[i] << '\n';
		x.push_back(x[i] + h);
		y.push_back(y[i] + h*f(x[i], y[i]));
	} while (x[x.size() - 1] <= xk);
}
void Runge(double h, double xn, double xk, double yn)
{
	vector<double> x, y;
	x.push_back(xn); y.push_back(yn);

	do
	{
		int i = x.size() - 1;
		double k1, k2, k3, k4;
		cout << i + 1 << ":\t" << "x = " << x[i] << "\t" << "y = " << y[i] << '\n';

		k1 = h*f(x[i], y[i]);
		k2 = h*f(x[i] + h / 2, y[i] + k1 / 2);
		k3 = h*f(x[i] + h / 2, y[i] + k2 / 2);
		k4 = h*f(x[i] + h, y[i] + k3);
		y.push_back(y[i] + (k1 + 2 * k2 + 2 * k3 + k4) / 6);
		x.push_back(x[i] + h);		
	} while (x[x.size() - 1] <= xk);
}
int main()
{
	double h, xn, yn, xk;
	setlocale(LC_ALL, "Russian");

	cout << "Введите x начальное: ";
	cin >> xn;
	cout << "Введите x конечное: ";
	cin >> xk;
	cout << "Введите y начальное: ";
	cin >> yn;

	cout << "Метод Эйлера для h = 0.01: " << endl;
	Eiler(0.01, xn, xk, yn);
	cout << endl;
	cout << "Метод Эйлера для h = 0.001: " << endl;
	Eiler(0.001, xn, xk, yn);
	cout << endl;
	cout << "Метод Рунге-Кутта четвертого порядка для h = 0.01: " << endl;
	Runge(0.01, xn, xk, yn);
	cout << endl;
	cout << "Метод Рунге-Кутта четвертого порядка для h = 0.001: " << endl;
	Runge(0.001, xn, xk, yn);

	cin.get();
	cin.get();
	return 0;
}
