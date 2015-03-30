/*
�������� ����											������� �1
����������� �����, �������������� ��������.
������� ���������������: ������, ��������, ������� � ������� ���������, ������� �� ������.
������� ���������������: ��������� ��������, ������� �������� �� ���� � ����� �����(���, �������).
������ ���������������: ������ � �����������.

1. ����������� �� ��������� +
2. ���������� +
3. ������������ � ����������� +
4. ����������� ����������� +
5. ������������� �������� ������������ +
6. ������������� �������� ������ � ����� +

����������� �������� ������ :
1. ������ ������ ��� ��������(��� + �������) � ��� ���� +
2. ������, ������ �� �� �� �������� ���������� +
4. �������� ��� ������ �� �������� +
3. ������ ��������� ������ ����� ���� ��������� �� ������� �������� +
5. ������� ��� ���� ������ �� �������� +
6. ������ ����� ���������, ������� �� ���� � ��������� ������� +
7. ������ ��� ������� ���� �� ��������� ������� +
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

	void Info() //������ ������ ��� ��������(��� + �������) � ��� ����
	{
		cout << "��� � �������: " << first_name << ' ' << last_name << "\t����: " << group.course << "\t���������: " << group.faculty << '\n';
		for (int i = 0; i < marks.size(); i++)
			cout << "���. �" << i + 1 << "\t�������: " << marks[i].name << "\t������: " << marks[i].bal << "\t���: " << marks[i].date << "\t�������: " << marks[i].semestr << '\n';
	}
	bool isFaculty(string faculty) //������, ������ �� �� �� �������� ����������
	{
		if (faculty != group.faculty) throw ("���, �� ������.");
		return 1;
	}
	void AddExam(string name, int bal, int date, int semestr) //�������� ��� ������ �� ��������
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
	int MarksInfo(string name) //������ ��������� ������ ����� ���� ��������� �� ������� ��������
	{
		int max = 0;
		for (int i = 0; i < marks.size(); i++)
		if (marks[i].name == name && marks[i].bal > max) max = marks[i].bal;
		return max;
	}
	void DelExam(string name, int semestr) //������� ��� ���� ������ �� ��������
	{
		for (int i = 0; i < marks.size(); i++)
		if (marks[i].name == name && marks[i].semestr == semestr)
		{
			marks.erase(marks.begin() + i);
			break;
		}	
	}
	int CountExam(int bal) //������ ����� ���������, ������� �� ���� � ��������� �������
	{
		int count = 0;
		for (int i = 0; i < marks.size(); i++)
			if (marks[i].bal == bal) count++;
		return count;
	}
	double SrBal(int semestr) //������ ��� ������� ���� �� ��������� �������
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
		out << "���: " << Stud.first_name << ' ' << Stud.last_name << "\t����: " << Stud.group.course << "\t���������: " << Stud.group.faculty << '\n';
		return out;
	}
	friend istream& operator>>(istream& in, Stud &Stud)
	{
		cout << "������� ���: ";
		in >> Stud.first_name;
		cout << "\n������� �������: ";
		in >> Stud.last_name;
		cout << "\n������� ����: ";
		in >> Stud.group.course;
		cout << "\n������� ���������: ";
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
	cout << "�������� � ������������� ������������ �� ���������, ��� �����������:" << endl;
	Stud unknown;
	cout << unknown;
	cout << '\n';
	cout << "�������� � ������������� ������������ � �����������, ��� �����������:" << endl;
	Stud vasia("�������", "������", 1, "��");
	cout << vasia;
	cout << "���������� 2-� ���������, �����:" << endl;
	vasia.AddExam("������", 3, 2012, 1);
	vasia.AddExam("����������", 4, 2012, 1);
	vasia.Info();
	cout << "������� ��� �� 1-� �������: " << vasia.SrBal(1) << endl;
	cout << '\n';
	cout << "�������� � ������������� ������������ �����������, ��� �����������:" << endl;
	Stud vasia_klon(vasia);
	cout << vasia_klon;
	cout << "���������� 2-� �������� (� �������������� ��������), �����:" << endl;
	vasia_klon.AddExam("���. ��", 5, 2012, 2);
	vasia_klon.AddExam("����������", 4, 2013, 2);
	vasia_klon.Info();
	cout << "�������� �������� �� \"���. ��\", �����:" << endl;
	vasia_klon.DelExam("���. ��", 2);
	vasia_klon.Info();
	cout << '\n';
	cout << "�������� ������ �� ������������ ������ �� ���������� \"��\": ";
	try
	{
		vasia_klon.isFaculty("��");
		cout << "��, ������." << endl;
	}
	catch (const char *s)
	{
		cout << s << endl;
	}
	cout << "��������� ������ ����� ���� ��������� �� ����������: " << vasia_klon.MarksInfo("����������") <<endl;
	cout << "���������� ���������, ������ �� 3 ����: " << vasia_klon.CountExam(3) << endl;

	cin.get();
	return 0;
}