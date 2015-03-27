#include <iostream>
#include <locale> 
#include <time.h> 
using namespace std;

#define PRINT_MASS(mas,n){\
	for(int i=0; i<n; ++i)\
		cout<<*(mas+i)<<' ';\
}
#define RAND_MASS(mas,n,k){\
	for(int i=0; i<n; ++i)\
		*(mas+i)=rand()%k*2-k;\
}
#define SUM_MIN_MASS(mas,n){\
	int sum=0;\
	for(int i=0; i<n; ++i)\
		if(*(mas+i)<0) sum+=*(mas+i);\
	cout<<"\n����� ������������� ��������� ������� = "<<sum;\
}
#define MULTIPLY_MASS(mas,n){\
	int multiply=1;\
	if(n==1) cout<<"����������� � ������������ ������� - ������. ����� ���� ��� ��������."<<endl;\
	else\
	{\
		for(int i=0; i<n; ++i)\
			multiply=multiply*(*(mas+i));\
		cout<<"������������ ��������� ������� ������������� ����� ������������ � ����������� ����������:\n(";\
		for(int i=0; i<n; ++i)\
			cout<<*(mas+i)<<' ';\
		cout<<") = "<<multiply<<endl;\
	}\
}
#define MIN_ELEM_MASS(mas,n,min_elem){\
	int min=0;\
	for(int i=0; i<n; ++i)\
		if(*(mas+i)<=min){\
			min_elem=i; min=*(mas+i);\
		}\
}
#define MAX_ELEM_MASS(mas,n,max_elem){\
	int max=0;\
	for(int i=0; i<n; ++i)\
		if(*(mas+i)>max){\
			max_elem=i; max=*(mas+i);\
		};\
}
#define EXCHANGE_ELEM(one,two){\
	int temp=one;\
	one=two;\
	two=temp;\
}
#define MULTIPLY_FROM_POST_TO_NEX(mas,n){\
	int min_elem=0, max_elem=0;\
	MIN_ELEM_MASS(mas,n,min_elem);\
	MAX_ELEM_MASS(mas,n,max_elem);\
	cout<<"\n������������ ������� ������� = "<<*(mas+max_elem)<<'('<<max_elem+1<<')';\
	cout<<"\n����������� ������� ������� = "<<*(mas+min_elem)<<'('<<min_elem+1<<')';\
	if(max_elem>min_elem)\
	{\
		cout<<"\n������ ���������������� ��������, ������������ ������� ���������� ����� ������������!";\
		EXCHANGE_ELEM(*(mas+max_elem),*(mas+min_elem));\
		EXCHANGE_ELEM(max_elem,min_elem);\
		cout<<"\n������������ � �����������, �������� �������."<<endl;\
	}\
	else cout<<"\n������������ �����."<<endl;\
	MULTIPLY_MASS(mas+max_elem+1,min_elem-max_elem);\
}
#define SORT_MASS(mas,n){\
	for(int i=0; i<n-1; ++i)\
	for(int j=0; j<n-1-i; ++j)\
		if(*(mas+j)>*(mas+j+1))\
		{\
			int c=*(mas+j);\
			*(mas+j)=*(mas+j+1);\
			*(mas+j+1)=c;\
		}\
}

int main()
{
	setlocale(LC_ALL,"Russian");
	srand(time(NULL));

	const int n=10;
	int mas[n]; //� ���������� �������, ��������� �� n ������������ ���������
	RAND_MASS(mas,n,10);
	cout<<"�������� ������:"<<endl;
	PRINT_MASS(mas,n);
	cout<<endl;

	SUM_MIN_MASS(mas,n); //����� ������������� ��������� �������
	cout<<endl;

	MULTIPLY_FROM_POST_TO_NEX(mas, n); //������������ ��������� �������, ������������� ����� ������������ � ����������� ����������
	SORT_MASS(mas,n); //����������� �������� ������� �� �����������.

	cout<<"\n������������� �� �����������, ������:"<<endl;
	PRINT_MASS(mas,n);

	cin.get();
	cin.get();
	return 0;
}