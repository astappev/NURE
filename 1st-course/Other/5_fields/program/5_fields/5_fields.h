#include <iostream>
using namespace std;

ref class Fields
{
private:
	int **matr;

public:
	int motion = 1;
	const int n = 3;

	Fields(void)
	{
		matr = new int*[3 * n];
		for (int i = 0; i < 3 * n; ++i)
			matr[i] = new int[3 * n];
	}

	~Fields(void)
	{
		for (int i = 0; i < 3 * n; ++i)
			delete[]matr[i];
		delete[]matr;
	}

	//Получить элемент
	int get(int i, int j)
	{
		return matr[i][j];
	}

	//Изменить элемент, а точнее обменять
	void change(int i1, int j1, int i2, int j2) // перестановка фишек
	{
		if (matr[i1][j1] == 0 || matr[i2][j2] == 0)
		{
			int a = matr[i1][j1];
			matr[i1][j1] = matr[i2][j2];
			matr[i2][j2] = a;
		}
		motion = next_motion();
	}

	//Начало игры
	void play(void)
	{
		for (int i = 0; i < 3 * n; ++i)
		for (int j = 0; j < 3 * n; ++j)
			matr[i][j] = 0;
		
		for (int i = n; i < 2 * n; ++i)
		for (int j = 0; j < n; ++j)
		{
			matr[j][i] = 1;
			matr[i][j] = 2;
		}
	}

	//Проверка побед
	int check()
	{
		int one = 0, two = 0;

		for (int i = 2 * n; i < 3 * n; ++i)
		for (int j = n; j < 2 * n; ++j)
			if (matr[i][j] != 1) one++;
		if (one == 0) return 1;

		for (int i = 2 * n; i < 3 * n; ++i)
		for (int j = n; j < 2 * n; ++j)
			if (matr[j][i] != 2) two++;
		if (two == 0) return 2;
		
		return 0;
	}

	//Педача хода
	int next_motion()
	{
		if (motion == 1) return 2;
		else return 1;
	}
};