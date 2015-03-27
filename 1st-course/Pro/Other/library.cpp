#include <iostream> /*Подключение библиотеке*/
using namespace std; /*Объявление пространства имён*/

struct Data{
	double day;
	double month;
	double year;
};
struct Student{
	char name[12];
	char name2[12];
	char name3[12];
	Data birth;
	char sex;
	int kurs;
};

Student * read (Student* book, int size){
	FILE * f;
	f=fopen("book.txt","r+b");
	int b=fread(book,sizeof(Student),size,f);  
fclose(f);
return book;
}

void write (Student* book,int size){
	FILE * f;
	f=fopen("book.txt","w+b");
	int b=fwrite(book,sizeof(Student),size,f); 
	fclose(f);
}

void out(Student* book,int size){
for (int i=0; i<size; i++){
	cout<<(*(book+i)).name<<" "<<(*(book+i)).name2<<" "<<(*(book+i)).name3<<" "<<(*(book+i)).birth.day<<"."<<(*(book+i)).birth.month<<"."<<(*(book+i)).birth.year<<" "<<(*(book+i)).sex<<" "<<(*(book+i)).kurs<<"\n";
}
}

Student *add (Student* book,int size){
	Student *book2=new Student[size+1];
	for (int i=0; i<size;i++){
		strcpy((*(book2+i)).name,(*(book+i)).name);
		strcpy((*(book2+i)).name2,(*(book+i)).name2);
		strcpy((*(book2+i)).name3,(*(book+i)).name3);
		(*(book2+i)).birth.day=(*(book+i)).birth.day;
		(*(book2+i)).birth.month=(*(book+i)).birth.month;
		(*(book2+i)).birth.year=(*(book+i)).birth.year;
		(*(book2+i)).sex=(*(book+i)).sex;
		(*(book2+i)).kurs=(*(book+i)).kurs;
	}
	
	cout<<"Введите имя, отчество, фамлию, дату рождения(день, месяц, год), пол и курс"<<"\n";
	cin.getline((*(book2+size)).name,12);
	cin.get();
	cin.getline((*(book2+size)).name2,12);
	cin.get();
	cin.getline((*(book2+size)).name3,12);
	cin>>(*(book2+size)).birth.day;
	cin>>(*(book2+size)).birth.month;
	cin>>(*(book2+size)).birth.year;
	cin>>(*(book2+size)).sex;
	cin>>(*(book2+size)).kurs;
return book2;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	int size=0;
 Student *book=new Student[size];
int answ;

while(true){
	cout<<"Выберете действие и нажмите соотв. цифру"<<"\n"<<"1.Вывести книгу на экран"<<"\n"<<"2.добавит запись"<<"\n"<<"3.Записать книгу в файл"<<"\n"<<"4.Вызвать книгу из файла"<<"\n";
	cin>>answ;
	if (answ==1){
		out(book,size);
	}
	if(answ==2){
		Student *book2=new Student[size+1];
		book2=add(book,size);
		size++;
		Student *book=new Student[size];
		book=book2;
	}
	if(answ==3){
		write(book,size);}
	if(answ==4){
			book=read(book,size);
		}	
}
	return 0;
}