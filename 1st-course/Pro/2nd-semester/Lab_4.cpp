#include <iostream>
#include <fstream>
#include <iomanip>
#include <string>
using namespace std;
struct STUDENT {
	char fio[200];
	char group[20];
	int mas_bal[5];
operator int() const
{
	int sum=0;
	for(int i=0; i<5; ++i)
		sum+=mas_bal[i];
	return (sum);
}
void operator()(char* name, char* gr, int b1, int b2, int b3, int b4, int b5)
{
	strcpy(fio,name);
	strcpy(group,gr);
	mas_bal[0]=b1;
	mas_bal[1]=b2;
	mas_bal[2]=b3;
	mas_bal[3]=b4;
	mas_bal[4]=b5;
}
};
STUDENT& operator ++(STUDENT &Stud)
{
	for (int i=0; i<5; ++i)
	++Stud.mas_bal[i];
	return Stud;
}
STUDENT& operator --(STUDENT &Stud)
{
	for (int i=0; i<5; ++i)
	--Stud.mas_bal[i];
	return Stud;
}
STUDENT operator +(const STUDENT &Stud1, const STUDENT &Stud2)
{
	STUDENT Stud=Stud1;
	strcat(Stud.fio,Stud2.fio);
	for (int i=0; i<5; ++i)
	Stud.mas_bal[i]+=Stud2.mas_bal[i];
	return Stud;
}

bool operator >(const  STUDENT &Stud1, const  STUDENT &Stud2)
{
	int sum1=0, sum2=0;
	for (int i=0; i<5; ++i)
	{
		sum1+=Stud1.mas_bal[i];
		sum2+=Stud2.mas_bal[i];
	}
	return sum1>sum2;
}
ostream& operator<<(ostream& out, STUDENT &Stud)
{
	int sum=0;
	for (int i=0; i<5; ++i)
	{
		sum+=Stud.mas_bal[i];
	}
	out<<setw(20)<<setfill('.')<<setiosflags(ios::left)<<Stud.fio<<' '<<Stud.group<<' '<<sum/5;
	return out;
}
istream& operator>>(istream& in,STUDENT &Stud)
{
	cout<<"Vvedite FIO\n";
	in>>Stud.fio;
	cout<<"Vvedite Grupu\n";
	in>>Stud.group;
	cout<<"Vvedite Bali\n";
	for (int i=0; i<5; ++i)
	{
		in>>Stud.mas_bal[i];
		while(Stud.mas_bal[i]<0 || Stud.mas_bal[i]>5){
			cout<<"Error, incorrect number"<<endl;
			in>>Stud.mas_bal[i];
		};
	}
	return in;
}
int main()
{
	const int n=4;
	STUDENT StudentMas[n];
	STUDENT StudentMas2;
	for(int i=0;i<n-1;i++)
		cin>>StudentMas[i];
	StudentMas[n-1]=StudentMas[1]+StudentMas[2];
	StudentMas[n-1]--;
	StudentMas[1]++;
	if(StudentMas[1]>StudentMas[2]) 
		cout<<StudentMas[1].fio<<" luche chem "<<StudentMas[2].fio<<endl;
	else cout<<StudentMas[2].fio<<" luche chem "<<StudentMas[1].fio<<endl;

	StudentMas2("Sidorov", "Gr-1", 5, 5, 5, 4, 3);
	for(int i=0;i<n;i++)
		cout<<StudentMas[i]<<endl;
	
	cout<<StudentMas2<<endl;
	cin.get();
	cin.get();
	return 0;
}