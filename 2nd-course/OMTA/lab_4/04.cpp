#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	const int n = 7;
	int Graph[n][n] = { 0, 1, 0, 1, 0, 0, 0,
						1, 0, 1, 1, 1, 0, 0,
						0, 1, 0, 0, 1, 0, 0,
						1, 1, 0, 0, 0, 0, 0,
						0, 1, 1, 0, 0, 1, 0,
						0, 0, 0, 0, 1, 0, 1,
						0, 0, 0, 0, 0, 1, 0 };

	int color = 1;
	Graph[0][0] = 1;
	/*
	for (int i = 0; i < n; ++i)
	for (int j = i; j < n; ++j)
	{
		if (Graph[i][j] != 0 && Graph[i][k] == Graph[i][j + 1])
		{
			color++;
			Graph[i][j + 1] = color;
			for (l = 0; l < j; ++l)
			if (Graph[l][j] != 0)
				Graph[l][j] = color;
			Graph[j + 1][j + 1] = color;
		}
		else
		{
			Graph[j + 1][j + 1] = Graph[i][j + 1];
		}	
		color = 1;
		++k;
	}
	*/
	for (int i = 1; i < n; ++i)
	{
		for (int j = 0; j < n; ++j)
		{
			if (i != j && Graph[i][j] != 0 && Graph[j][j] == color)
			{
				color++;
				j = 0;
				continue;
			}
		}
		Graph[i][i] = color;
		color = 1;
	}
	
	cout << "Конечная матрица (диагональ - цвета):" << endl;
	for (int i = 0; i < n; ++i, cout << '\n')
	for (int j = 0; j < n; ++j)
		cout << Graph[i][j] << '\t';

	int max = Graph[0][0];
	for (int i = 0; i < n; ++i)
	if (Graph[i][i]>max) max = Graph[i][i];
	cout << "Хроматическое число: " << max;

	cin.get();
	cin.get();
	return 0;
}