#include <iostream>
#include <locale>
#include <math.h>
using namespace std;

double f(double x)
{
	return pow(x, 3) - 2 * pow(x, 2) - 11 * x + 12;
}

double fh(double x)
{
	return 3 * pow(x, 2) - 4 * x - 11;
}

double findHord(double a, double b, double e) // a, b - пределы хорды, e - необходимая погрешность
{
	int count = 0;
	while (fabs(b - a) >= e)
	{
		count++;
		a = b - (b - a) * f(b) / (f(b) - f(a)); // i-1
		b = a - (a - b) * f(a) / (f(a) - f(b)); // i
	}
	cout << '\t' << count << '\t';
	return b;
}

double findIter(double x, double e) // x - точка входа, e - необходимая погрешность
{
	int count = 0;
	double l, x_prev;
	l = 1 / fh(x);
	do {
		if ((fh(x) > 0 && l < 0) || (fh(x) < 0 && l > 0)) l *= -1;
		x_prev = x;
		x = x-l*f(x);
		count++;
	} while (fabs(x_prev - x) >= e);
	cout << '\t' << count<< '\t';
	return x;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	double a = 0., b = 0., e = 0., x = 0.;

	cout << "Для уравнения x^3-2x^2-11x+12. // -3 1 4" << endl;
	cout << "Введите данные о отрезке, на котором будем искать промежутки: ";
	cin >> a >> b;

	bool isRun = false;
	do{

		int m = 0;
		
		cout << "Введите погрешность: ";
		cin >> e;
		
		cout << "\nВыбирите метод: 0 - хорд, 1 - простых итераций\nВаш выбор: ";
		cin >> m;

		if (m == 0)
		{
			double now = f(a), fut = 0.;
			for (double i = a; i < b; i+=1.5)
			{
				fut = f(i + 1);

				if ((now >= 0 && fut <= 0) || (now <= 0 && fut >= 0))
				{
					double zn = findHord(i, i + 1, e);
					if (zn < 999 || zn > 999)
					{
						//cout << "Отладка: " << now << ", " << fut << ", интервал (" << i << "," << i + 1 << ")\n";
						cout << "Точка перечечения на отрезке [" << i << ", " << i + 1 << "], приходится на (" << zn << ", 0)." << endl;
					}
				}
				now = fut;
			}
		}
		else
		{
			double now = f(a), fut = 0.;
			for (double i = a; i < b; i ++)
			{
				fut = f(i + 1);
				if ((now >= 0 && fut <= 0) || (now <= 0 && fut >= 0))
				{
					double zn = findIter(i, e);
					if (zn < 999 || zn > 999)
					{
						//cout << "Отладка: " << now << ", " << fut << ", интервал (" << i << "," << i + 1 << ")\n";
						cout << "Точка перечечения, при вхоже в точке " << i << ", приходится на (" << zn << ", 0)." << endl;
					}
				}
				now = fut;
			}
		}
		char run;
		cout << "Хотите продолжить? (Y|N) ";
		cin >> run;
		if (run == 'Y' || run == 'y') isRun = true;
		else isRun = false;
	} while (isRun);

	return 0;
	cin.get();
	cin.get();
}