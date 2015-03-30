/* 
Астаппев Олег
Лб № 1
Вариант №1

Пошук елемента серед уведених цілих чисел методом половинного розподілу.
*/
#include <iostream>
#include <locale>
using namespace std;

void Sort(int *mas, int n)
{
	for (int i = 0; i < n; ++i)
	for (int j = n - 1; j > i; --j)
	{
		if (*(mas + j - 1) > *(mas + j))
		{
			int temp = *(mas + j - 1);
			*(mas + j - 1) = *(mas + j);
			*(mas + j) = temp;
		}
	}
}

void find_elem(int *mas, int n, int find)
{
	size_t first = 0;
	size_t last = n - 1;
	size_t mid = (last + first) / 2;

	while (first <= last)
	{
		if (*(mas + mid) == find)
			break;
		else if (*(mas + mid) < find)
			first = mid + 1;
		else
			last = mid - 1;

		mid = (last + first) / 2;
	}

	if (*(mas + mid) == find)
		cout << "Искомый элемент найден, его порядок в упорядочненом массиве - " << mid + 1 << endl;
	else if (*(mas + last) != find)
		cout << "Искомый элемент НЕ найден!" << endl;
	else
		cout << "Искомый элемент найден, его порядок в упорядочненом массиве - " << last + 1 << endl;
		
}

int main()
{
	int n;
	setlocale(LC_ALL, "Russian");
	bool isFirst = false;
	do{
		if (isFirst) cout << "Массив должен содержать элементы, он не может быть меньше или равен 0. Повторите попытку." << endl;
		cout << "Введите количество цифер: ";
		cin >> n;
		isFirst = true;
	} while (n == 0);

	int *mas = new int[n];
	cout << "\nВведите цифры: ";
	for (int i = 0; i < n; i++)
		cin >> mas[i];

	Sort(mas, n);

	/*
	cout << "\nУпорядочненый массив: " <<endl;
	for (int i = 0; i < n; i++)
	cout << mas[i] << ' ';
	*/

	char ask;
	do{
		int find;
		isFirst = false;
		do{
			if (isFirst) cout << "Элемент выходит за пределы последовательности. Повторите ввод." << endl;
			cout << "\nВведите искомый элемент: ";
			cin >> find;
			isFirst = true;
		} while (mas[0] > find || mas[n - 1] < find);

		find_elem(mas, n, find);
		cout << "Хотите повторить? (Y/N): ";
		cin >> ask;
	} while (ask == 'Y' || ask == 'y');

	return 0;
	cin.get();
	cin.get();
}