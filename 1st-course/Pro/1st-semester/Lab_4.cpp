#include <iostream>
#include <string.h>
using namespace std;
struct bal
{
	char fio[100];
	int exz1;
	int exz2;
	int exz3;
};
int main()
{
	int n, i, s=0;
	cout<<"Vvedite kol-vo studentov: ";
	cin>>n;
	bal * stud = new bal[n];
		for(i=0; i<n; ++i)
		{
			cout<<"\nVvedite fio studenta: ";
				cin>>stud[i].fio;
to1:
			cout<<"Vvedite 1 examen: ";
			cin>>stud[i].exz1;
			if(stud[i].exz1>5)
			{
				cout<<"Error"<<endl;
				goto to1;
			}
to2:
			cout<<"Vvedite 2 examen: ";
			cin>>stud[i].exz2;
			if(stud[i].exz2>5)
			{
				cout<<"Error"<<endl;
				goto to2;
			}
to3:
			cout<<"Vvedite 3 examen: ";
			cin>>stud[i].exz3;
			if(stud[i].exz3>5)
			{
				cout<<"Error"<<endl;
				goto to3;
			}
		}
		cout<<"\nStependiyu poluchat :"<<endl;
		for(i=0; i<n; ++i)
		{
			int sbal=0;
			sbal=(stud[i].exz1+stud[i].exz2+stud[i].exz3)/3;
			if(sbal>=4)
			{
				cout<<stud[i].fio<<endl;
				s++;
			}

		}
		if(s==0)
			cout<<"Vse provalili :D"<<endl;
		delete[]stud;
	cin.get();
	return 0;
}
