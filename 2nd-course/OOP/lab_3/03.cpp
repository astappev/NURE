/*
Создать программу, которая вводит c клавиатуры массив строк и еще две
строки и заменяет в массиве все символы, найденные в первой строке, на
соответствующие символы второй строки (транслирует строки). Выдать
оттранслированные строки и массив пар "символ"-"число замен".
*/

#include <iostream>
#include <vector>
#include <string>
using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");
	vector<string> mas;
	string find, replace;
	int n;

	cout << "Сколько строк необходимо добавить в массив? ";
	cin >> n;
	for (int i = 0; i < n; ++i)
	{
		cin.get();
		string t;
		getline(cin, t, '\n');
		mas.push_back(t);
	}
	cout << "Введите строку алфавита поиска: ";
	cin >> find;
	cout << "Введите строку алфавита замены: ";
	cin >> replace;

	if (find.length() == replace.length())
	{
		int *counter = new int[find.length()];
		for (int j = 0; j < find.length(); ++j) counter[j] = 0;
		for (int i = 0; i < mas.size(); ++i)
		for (int j = 0; j < find.length(); ++j)
		{
			while (mas[i].find(find[j]) != -1)
			{
				counter[j]++;
				int k = mas[i].find(find[j]);
				mas[i].replace(k, 1, replace, j, 1);
			}
		}

		for (int i = 0; i < mas.size(); ++i, cout << '\n')
			cout << mas[i];

		for (int j = 0; j < find.length(); ++j)
			cout << '\'' << find[j] << "' замен - " << counter[j] << endl;
	}
	else cout << "Различия в длине между исходной и конечной азбукой" << endl;

	
}