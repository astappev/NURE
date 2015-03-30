/*
Астаппев Олег											Вариант №1
Разработать класс, представляющий студента.
Студент характеризуется: именем, фамилией, группой и набором экзаменов, которые он сдавал.
Экзамен характеризуется: названием предмета, оценкой студента по нему и датой сдачи(год, семестр).
Группа характеризуется: курсом и факультетом.

1. конструктор по умолчанию +
2. деструктор +
3. конструкторы с параметрами +
4. конструктор копирования +
5. перегруженную операцию присваивания +
6. перегруженную операцию вывода в поток +

Необходимые операции таковы :
1. узнать полное имя студента(имя + фамилия) и его курс +
2. узнать, учится ли он на заданном факультете +
4. добавить ему оценку по экзамену +
3. узнать наивысшую оценку среди всех экзаменов по данному предмету +
5. удалить для него оценку по экзамену +
6. узнать число экзаменов, которые он сдал с указанной оценкой +
7. узнать его средний балл за указанный семестр +
*/
#include <iostream>
#include <string>
#include <locale>
#include <fstream>
#include <vector>
using namespace std;

struct GROUP {
	int course;
	string faculty;
};

struct EXAM {
	string name;
	int bal;
	int date;
	int semestr;
};

template <typename T>
class TStudent {
protected:
	string first_name;
	string last_name;
	GROUP group;
	vector<T> marks;
public:
	TStudent()
	{
		this->first_name = "Unknown name";
		this->last_name = "Unknown last name";
		this->group.course = 1;
		this->group.faculty = "PM";
	}
	TStudent(string name, string last_name, int course, string faculty)
	{
		this->first_name = name;
		this->last_name = last_name;
		this->group.course = course;
		this->group.faculty = faculty;
	}
	TStudent(const TStudent &Stud)
	{
		if (this == &Stud) return;
		this->first_name = Stud.first_name;
		this->last_name = Stud.last_name;
		this->group = Stud.group;
		this->marks = Stud.marks;

	}

	~TStudent(){}
	virtual void AddExam(string name, int bal, int date, int semestr) = 0;
	virtual void Info() = 0;
	virtual bool isFaculty(string faculty) = 0;
	virtual int MarksInfo(string name) = 0;
	virtual void DelExam(string name, int semestr) = 0;
	virtual int CountExam(int bal) = 0;
	virtual double SrBal(int semestr) = 0;
	
};

class Stud : public TStudent<EXAM> {
public:
	Stud() : TStudent<EXAM>(){};
	Stud(string name, string last_name, int course, string faculty) : TStudent<EXAM>(name, last_name, course, faculty){};
	Stud(const Stud &Stud) : TStudent<EXAM>(Stud){};

	void Info() //узнать полное имя студента(имя + фамилия) и его курс
	{
		cout << "Имя и фамилия: " << first_name << ' ' << last_name << "\tКурс: " << group.course << "\tФакультет: " << group.faculty << '\n';
		for (int i = 0; i < marks.size(); i++)
			cout << "Экз. №" << i + 1 << "\tПредмет: " << marks[i].name << "\tОценка: " << marks[i].bal << "\tГод: " << marks[i].date << "\tСеместр: " << marks[i].semestr << '\n';
	}
	bool isFaculty(string faculty) //узнать, учится ли он на заданном факультете
	{
		if (faculty != group.faculty) throw ("нет, не учится.");
		return 1;
	}
	void AddExam(string name, int bal, int date, int semestr) //добавить ему оценку по экзамену
	{
		for (int i = 0; i < marks.size(); i++)
		if (marks[i].name == name && marks[i].semestr == semestr)
			return;

		EXAM temp;
		temp.name = name;
		temp.bal = bal;
		temp.date = date;
		temp.semestr = semestr;

		marks.push_back(temp);
	}
	int MarksInfo(string name) //узнать наивысшую оценку среди всех экзаменов по данному предмету
	{
		int max = 0;
		for (int i = 0; i < marks.size(); i++)
		if (marks[i].name == name && marks[i].bal > max) max = marks[i].bal;
		return max;
	}
	void DelExam(string name, int semestr) //удалить для него оценку по экзамену
	{
		for (int i = 0; i < marks.size(); i++)
		if (marks[i].name == name && marks[i].semestr == semestr)
		{
			marks.erase(marks.begin() + i);
			break;
		}	
	}
	int CountExam(int bal) //узнать число экзаменов, которые он сдал с указанной оценкой
	{
		int count = 0;
		for (int i = 0; i < marks.size(); i++)
			if (marks[i].bal == bal) count++;
		return count;
	}
	double SrBal(int semestr) //узнать его средний балл за указанный семестр
	{
		double bal = 0;
		int count = 0;
		for (int i = 0; i < marks.size(); i++)
		if (marks[i].semestr == semestr)
		{
			count++;
			bal += marks[i].bal;
		}
		return bal/count;
	}

	friend ostream& operator<<(ostream& out, Stud &Stud)
	{
		out << "Имя: " << Stud.first_name << ' ' << Stud.last_name << "\tКурс: " << Stud.group.course << "\tФакультет: " << Stud.group.faculty << '\n';
		return out;
	}
	friend istream& operator>>(istream& in, Stud &Stud)
	{
		cout << "Введите имя: ";
		in >> Stud.first_name;
		cout << "\nВведите фамилию: ";
		in >> Stud.last_name;
		cout << "\nВведите курс: ";
		in >> Stud.group.course;
		cout << "\nВведите факультет: ";
		in >> Stud.group.faculty;
		return in;
	}
	Stud& operator=(Stud &Stud)
	{
		if (this == &Stud) return *this;
		this->~Stud();
		this->first_name = Stud.first_name;
		this->last_name = Stud.last_name;
		this->group = Stud.group;
		this->marks = Stud.marks;
		return *this;
	}
};

int main()
{
	setlocale(LC_ALL, "Russian");
	cout << "Создание с использование конструктора по умолчанию, его отображение:" << endl;
	Stud unknown;
	cout << unknown;
	cout << '\n';
	cout << "Создание с использование конструктора с параметрами, его отображение:" << endl;
	Stud vasia("Василий", "Иванов", 1, "ПМ");
	cout << vasia;
	cout << "Добавление 2-х экзаменов, вывод:" << endl;
	vasia.AddExam("Физика", 3, 2012, 1);
	vasia.AddExam("Математика", 4, 2012, 1);
	vasia.Info();
	cout << "Средний бал за 1-й семестр: " << vasia.SrBal(1) << endl;
	cout << '\n';
	cout << "Создание с использование конструктора копирования, его отображение:" << endl;
	Stud vasia_klon(vasia);
	cout << vasia_klon;
	cout << "Добавление 2-х экзамена (к склонированому студенту), вывод:" << endl;
	vasia_klon.AddExam("Укр. яз", 5, 2012, 2);
	vasia_klon.AddExam("Математика", 4, 2013, 2);
	vasia_klon.Info();
	cout << "Удаление экзамена по \"Укр. Яз\", вывод:" << endl;
	vasia_klon.DelExam("Укр. яз", 2);
	vasia_klon.Info();
	cout << '\n';
	cout << "Проверка учится ли скопированый студен на факультете \"КН\": ";
	try
	{
		vasia_klon.isFaculty("КН");
		cout << "да, учится." << endl;
	}
	catch (const char *s)
	{
		cout << s << endl;
	}
	cout << "Наивысшая оценку среди всех экзаменов по Математике: " << vasia_klon.MarksInfo("Математика") <<endl;
	cout << "Количество экзаменов, сданых на 3 бала: " << vasia_klon.CountExam(3) << endl;

	cin.get();
	return 0;
}