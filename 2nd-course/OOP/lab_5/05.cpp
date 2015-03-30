/*
�������� ����
���-12-1

�� 5
����������� ���������, ������� ��������� ����� � ������������ ����� ���������� ������� �����, �� ����������� ����, ��������� � ������.
����� � ������ ����������� ���������.

������� ����� ���������� ����� ������������� � ������� �������������� �������, ������ ���� ��� ���������� ������������� � ������� ���������.
������ ���, ����� ����������� ����� �� ������, �������� ���������.
������� ����� ������� ��� ������ ����������� � ������� �� � ��������� ����.
���������� ������� ������� � ������������ ����.
�������� ������ ������� �� ����� � ������� � ����.

apple asus lenovo
samsung hp apple lenovo samsung dell asus hp samsung
*/

#include <iostream>
#include <map>
#include <set>
#include <string>
#include <locale>
#include <fstream>
#include <algorithm>
using namespace std;

class Text
{
private:
	map<string, int> count_words;
	set<string> exception;
	set<string>::iterator si;
public:
	void output_exception()
	{
		cout << "�����-����������: ";
		for (si = exception.begin(); si != exception.end(); si++)
			cout << *si << " ";
	}
	void input_exception(string words)
	{
		string word;
		while (isalpha(words[0]))
		{
			size_t found = words.find(' ');
			if (found != string::npos)
			{
				word.insert(0, words, 0, found);
				words.erase(0, found + 1);
			}
			else
			{
				word.insert(0, words);
				words.clear();
			}

			exception.insert(word);
			word.clear();
		}
	}
	void input_text(string str)
	{
		cout << "\n�������� ������: " << str;
		string word;
		while (isalpha(str[0]))
		{
			size_t found = str.find(' ');
			if (found != string::npos)
			{
				word.insert(0, str, 0, found);
				str.erase(0, found + 1);
			}
			else
			{
				word.insert(0, str);
				str.clear();
			}

			if ((exception.find(word)) == exception.end())
			{
				count_words[word]++;
			}
			word.clear();
		}
	}
	void output_word()
	{
		cout << endl;
		map<string, int>::iterator wi;
		for (wi = count_words.begin(); wi != count_words.end(); wi++)
			cout << "�����: " << wi->first << "\t���-�� ���������: " << wi->second << endl;

	}
};
int main()
{
	setlocale(LC_ALL, "Russian");
	string words, t;
	freopen("input.txt", "r", stdin);
	getline(cin, words);
	getline(cin, t);

	Text text;
	text.input_exception(words);
	text.output_exception();
	text.input_text(t);
	text.output_word();
	
	cin.get();
	cin.get();
	return 0;
}