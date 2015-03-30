/*
Астаппев Олег											Вариант №1
Разработать класс, представляющий студента.
Студент характеризуется: именем, фамилией, группой и набором экзаменов, которые он сдавал.
Экзамен характеризуется: названием предмета, оценкой студента по нему и датой сдачи(год, семестр).
Группа характеризуется: курсом и факультетом.

Необходимые задачи таковы:
1. обеспечить для контейнера возможность чтения из файла и записи в файл с использованием итераторов потоков. +
2. обеспечить для контейнера сортировку по фамилии студента (это должна быть сортировка по умолчанию), +
   а также сортировку по его среднему баллу за последнюю сессию. +
3. вынести в отдельный вектор всех студентов, начиная со студента со средним баллом больше, чем 4
4. сохранить все средние баллы студентов из вектора шага 3 в отдельном векторе
5. узнать, сколько в векторе шага 4 значений среднего балла выше заданного
6. найти средний балл для всех студентов с использованием accumulate()
7. проверить, входит ли вектор, полученный на шаге 3, в исходный вектор как подпоследовательность.

Vasiliy Ivanov
1
INF
Fizika;5;2012;1;Matematika;5;2012;1;
Peter Dmitriev
2
PM
Fizika;4;2012;2;Istoria;5;2012;1;
Adamov Dmitry
1
PM
Fizika;3;2013;1;Istoria;5;2013;1;
*/

#include <sstream>
#include <fstream>
#include <algorithm>
#include <functional>
#include <numeric>
#include <iostream>
#include <vector>
#include <string>
#include <list>
#include <iterator>
using namespace std;

struct EXAM
{
	string name;
	int mark;
	int year;
	int semester;
};

struct GROUP {
	int course;
	string faculty;
};

int operator + (int a, const EXAM& exam)
{
	return (a + exam.mark);
}

int markAdd(int val, EXAM &exam)
{
	return val + exam.mark;
};

ostream& operator <<(ostream& out, const EXAM& p)
{
	out << "   " << p.name << " — " << p.mark << ", " << p.semester << " семестр " << p.year << " год.\n";
	return out;
}

istream& operator >>(istream& in, EXAM& p)
{
	char separator = ';';
	getline(in, p.name, separator);
	string str;
	getline(in, str, separator);
	p.mark = atoi(str.c_str());
	getline(in, str, separator);
	p.year = atoi(str.c_str());
	getline(in, str, separator);
	p.semester = atoi(str.c_str());
	return in;
}

class Student
{
public:
	string fio;
	GROUP group;
	vector <EXAM> exams;
	bool operator <(const Student &p)const
	{
		return fio < p.fio;
	}
};

ostream& operator <<(ostream& out, const Student& p)
{
	out << p.fio << "\tКурс: " << p.group.course << " Факультет: " << p.group.faculty << '\n';
	ostream_iterator<EXAM> os(out);
	copy(p.exams.begin(), p.exams.end(), os);
	return out;
}

istream& operator >>(istream& in, Student& p)
{
	getline(in, p.fio);
	string str;
	getline(in, str);
	p.group.course = atoi(str.c_str());
	getline(in, p.group.faculty);
	p.exams.clear();
	getline(in, str);
	stringstream sinn(str);
	copy(istream_iterator<EXAM>(sinn), istream_iterator<EXAM>(), back_inserter(p.exams));
	return in;
}

bool SortSrBal(const Student& a, const Student& b)
{
	int s1 = accumulate(a.exams.begin(), a.exams.end(), 0);
	int s2 = accumulate(b.exams.begin(), b.exams.end(), 0);
	return s1 < s2;
}

int sumBal(const int sum, const EXAM& exam)
{
	return(sum + exam.mark);
}

bool SrBal_4(const Student& a)
{
	int s = accumulate(a.exams.begin(), a.exams.end(), 0, sumBal);
	double sbal = s / a.exams.size();
	if (sbal >= 4) return 1;
	else return 0;
}

class ClistExam
{
	vector<EXAM> &listExam;
public:
	ClistExam(vector<EXAM> &x) :listExam(x){};
	void operator ()(const Student&y)
	{
		copy(y.exams.begin(), y.exams.end(), back_inserter(listExam));
	}
};

double &get_mark(Student& a)
{
	int s = accumulate(a.exams.begin(), a.exams.end(), 0, sumBal);
	double sbal = s / a.exams.size();
	return sbal;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	vector<Student> Stud;
	// 1. обеспечить для контейнера возможность чтения из файла и записи в файл с использованием итераторов потоков.
	ifstream in("input.txt");
	copy(istream_iterator<Student>(in), istream_iterator<Student>(), back_inserter(Stud));
	ostream_iterator<Student> os(cout);
	copy(Stud.begin(), Stud.end(), os);
	
	// 2. обеспечить для контейнера сортировку по фамилии студента (это должна быть сортировка по умолчанию), а также сортировку по его среднему баллу за последнюю сессию.
	cout << "\nСортировка по Фамилии:" << endl;
	sort(Stud.begin(), Stud.end());
	copy(Stud.begin(), Stud.end(), os);
	cout << "\nСортировка по среднему балу:" << endl;
	sort(Stud.begin(), Stud.end(), SortSrBal);
	copy(Stud.begin(), Stud.end(), os);
	
	//3. вынести в отдельный вектор всех студентов, начиная со студента со средним баллом больше, чем 4
	cout <<"\nСтуденты со стипендией:" << endl;
	vector<Student> StepStud;
	vector<Student>::iterator StepStud_Iter;
	StepStud_Iter = find_if(Stud.begin(), Stud.end(), SrBal_4);
	copy(StepStud_Iter, Stud.end(), back_inserter(StepStud));
	copy(StepStud.begin(), StepStud.end(), os);

	//4. сохранить все средние баллы студентов из вектора шага 3 в отдельном векторе
	ostream_iterator<int>out4(cout, " ");
	cout << "Средние балы студентов: ";
	vector<int> VectorMark;
	transform(StepStud.begin(), StepStud.end(), back_inserter(VectorMark), get_mark);
	copy(VectorMark.begin(), VectorMark.end(), out4);

	// 5. узнать, сколько в векторе шага 4 значений среднего балла выше заданного
	cout << "\nСтудентов из повышеной степендией: ";
	int kol_vo = count_if(VectorMark.begin(), VectorMark.end(), bind2nd(not2(less<int>()), 5));
	cout << kol_vo;
	
	// 6. найти средний балл для всех студентов с использованием accumulate()
	cout << "\nСредний бал всех студентов: ";
	vector<EXAM> ListMark;
	for_each(Stud.begin(), Stud.end(), ClistExam(ListMark));
	int sum_srbal = accumulate(ListMark.begin(), ListMark.end(), 0, markAdd);
	cout << (float)sum_srbal / ListMark.size() << endl;
	
	// 7. проверить, входит ли вектор, полученный на шаге 3, в исходный вектор как подпоследовательность.
	sort(Stud.begin(), Stud.end());
	sort(StepStud.begin(), StepStud.end());

	if (includes(Stud.begin(), Stud.end(), StepStud.begin(), StepStud.end())) cout << "Входит" << endl;
	else cout << "Не входит" << endl;
	
	
	cin.get();
	cin.get();
	return 0;
}