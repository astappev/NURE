/*
Создать программу, которая вводит c клавиатуры (с обработкой ошибок) двумерный квадратный массив целых чисел,
заменяет все отрицательные элементы главной диагонали на сумму всех элементов соответствующей строки
и отображает данный массив на экране в транспонированном виде
a[1,1] a[2,1] a[3,1]
a[1,2] a[2,2] ...
*/

#include <iostream>
#include <locale>
#include <vector>
#include <time.h>
using namespace std;

void rand(vector<vector<int> > &matr)
{
	srand(time(NULL));
	for (int i = 0; i<matr.size(); i++)
		for (int j = 0; j<matr[i].size(); j++)
			matr[i][j]=rand()%20-10;
}


void print(vector<vector<int> > matr)
{
	for (int i = 0; i<matr.size(); i++, cout << ' ')
		for (int j = 0; j<matr[i].size(); j++, cout << ' ')
			cout << matr[i][j];
}

void trans(vector<vector<int> > &matr)
{
	for (int i = 0; i<matr.size(); i++)
	for (int j = i + 1; j < matr[i].size(); j++)
	{
		int t = 0;
		t = matr[i][j], matr[i][j] = matr[j][i], matr[j][i] = t;
	}
}

int main()
{
	setlocale(LC_ALL, "Russian");
	int n = 1000;

	vector<vector<int> > matr(n);
	for (int i = 0; i<n; i++) {
		vector<int> line(n);
		matr[i] = line;
	}

	rand(matr);
	trans(matr);
	print(matr);

	return 0;
	cin.get();
	cin.get();
}
