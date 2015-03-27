#include <iostream>
#include <string>
using namespace std;
struct STUDENT {
	char fio[90];
	int group;
	int bal[5];
};

template <typename T>
class TStudent {
protected:
	T *mas;
	int n;
public:
	TStudent()
	{
		n=3;
		mas=new T[n];
	}
	TStudent(int k)
	{
		n=k;
		mas=new T[n];
	}
	TStudent(const TStudent &Stud)
	{
		if (this==&Stud) return;
		this->n=Stud.n;
		mas=new T[n];
		for(int i=0;i<n;i++)
			mas[i]=Stud.mas[i];
	}

	virtual ~TStudent()
	{
		delete []mas;
	}
	virtual void input()=0;
	virtual void output()=0;
};

class Stud: public TStudent<STUDENT> {
public:
	Stud(): TStudent<STUDENT>(){};
	Stud(int k): TStudent<STUDENT>(k){};
	Stud(const Stud &Stud): TStudent<STUDENT>(Stud){};
	virtual void input()
	{
		cout<<"Input info for "<<n <<" students"<<endl;
		for(int i=0;i<n;i++)
		{
			cout<<"Input name: ";
			cin>>mas[i].fio;
			cout<<"Input group: ";
			cin>>mas[i].group;
			cout<<"Input bals:  ";
			for(int j=0;j<5;++j)
			cin>>mas[i].bal[j];
		}
	};

	virtual void output()
	{
		for(int i=0;i<n;i++,cout<<'\n')
		{
			cout<<mas[i].fio<<'\t'<<mas[i].group<<'\t';
			for(int j=0;j<5;++j,cout<<' ')
				cout<<mas[i].bal[j];
		}
	};

	virtual void output_wbal()
	{
		int min_bal;
		cout<<"Vvedite minimalniy bal ";
		cin>>min_bal;
		for(int i=0;i<n;i++,cout<<'\n')
		{
			int s_sum=0;
			for(int j=0;j<5;++j,cout<<' ')
				s_sum+=mas[i].bal[j];
			s_sum/=5;
			if(s_sum>=min_bal){
				cout<<mas[i].fio<<'\t'<<mas[i].group<<'\t';
				for(int j=0;j<5;++j,cout<<' ')
					cout<<mas[i].bal[j];
			}
		}
	};
};

int main()
{
	Stud ten_students(2);
	//Stud ten_students_copy(ten_students);
	ten_students.input();
	ten_students.output_wbal();

	cin.get();
	cin.get();
	return 0;
}