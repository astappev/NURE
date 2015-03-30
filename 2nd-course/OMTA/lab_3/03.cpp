//Астаппев Олег				ИНФ-12-1	Лб 3

#include <iostream>
#include <locale>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	//базовая инициализация
	const int n = 25;
	double h = 1;
	double **matr = new double*[n];
	for (int i(0); i<n; i++)
		matr[i] = new double[2];

	//cчитаем y
	double x = 0., y;
	for (int i = 0; i < n; i++)
	{
		x+=h;
		if (x <= n / 9)
			y = 0;
		else if (x <= 4 * n / 9) // установить 2 вместо 4-х (проверка работы программы при  плавном склоне).
			y = i - n / 9;
		else if (x <= 7 * n / 9)
			y = 7*n/9-i;
		else
			y = 0;
		matr[i][0] = x, matr[i][1] = y;
	}
	// вывод пар x, y
	cout << "Таблица значений XY:" << endl;
	for (int i = 0; i < n; i++, cout << '\n')
		cout << "X = " << matr[i][0] << ", Y = " << matr[i][1];

	//считаем центр и начало, конец графика
	int center=0, begin = 0, end=0; //cenetr - точка центра (если их 2 - второго центра), begin -начало подъема, end - последняя ненулевая точка
	while (matr[begin][1] == 0) begin++;
	center = begin;
	while (!(matr[center - 1][1] < matr[center][1] && matr[center][1] >= matr[center + 1][1])) center++;
	end = center;
	while (matr[end][1] > 0) end++;
	int size = end - begin, write = 0; //size - кол-во ненулевых элементов графика, write(-1) - счетчик записаных символов в finaly
	double *finaly = new double[size]; //служит для хранения отсортированого значения y
	finaly[write++] = matr[center][1];

	//условие, "что если вершин 2".
	if (matr[center][1] == matr[center + 1][1])
	{
		cout << "\nПодъем - " << begin + 1 << ", верхушка - " << center + 1 << ", " << center + 2  << ", спуск - " << end-- << ", размер - " << size << endl;
		finaly[write++] = matr[center + 1][1];
	}
	else
	{
		cout << "\nПодъем - " << begin + 1 << ", верхушка - " << center + 1 << ", спуск - " << end-- << ", размер - " << size << endl;
	}

	//вместо сортировки, алгоритм слияния
	int ii = begin, jj = end, k = size - 1;
	while (ii != jj && ii < center && jj > (center + write - 1))
	{
		if (matr[ii][1]>matr[jj][1]) finaly[k] = matr[jj][1], k--, jj--;
		else if (matr[ii][1]<matr[jj][1]) finaly[k] = matr[ii][1], k--, ii++;
		else finaly[k] = matr[jj][1], k--, jj--, finaly[k] = matr[ii][1], k--, ii++;
	}
	
	//проверяем и дополняем масив, если вдруг одна из сторон больше второй.
	if (write != k - 1)
	{
		while (ii < center) finaly[k] = matr[ii][1], k--, ii++;
		while (jj > (center + write - 1)) finaly[k] = matr[jj][1], k--, jj--;		
	}

	//вывод отсортированого массива
	cout << "\nОтсортированный массив Y:" << endl;
	for (int f = 0; f < size; f++, cout<<' ')
		cout << finaly[f];
	
	cin.get();
	return 0;
}