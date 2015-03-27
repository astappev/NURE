#include <iostream>
#include <conio.h>
#include <string.h>
using namespace std;
int main()
{
	char str[] = "I love country";
	char strCopy[sizeof(str)];
	cout<<str<<endl;
	char *token = strtok(str, seps);//пошук першого слова
	int lenResult=0;
	int countWord=0; //кількість слів
	//Підрахуємо кількість необхідної пам'яты для рядка-результата
	while( token != NULL )
	{
		int last = strlen(token)-1;
		if (
			(token[0]    == 'a' || token[0]    == 'A')
			&& (token[last] == 'a' || token[last] == 'A')
			)
		{
			lenResult+= strlen(token)+1;
			++countWord;
		}
		token = strtok(NULL, seps );//пошук наступного слова
	}
	char* resString = new char [lenResult];
	resString[0]='\0'; //створюєму пустий рядок
	strcpy(str,strCopy);//відновлюємо рядок
	token = strtok(str, seps);//пошук першого слова
	int curentNumberWord=0;
	while( token != NULL )
	{
		int last = strlen(token)-1;
		if (
			(token[0]    == 'a' || token[0]    == 'A')
			&& (token[last] == 'a' || token[last] == 'A')
			)
		{
			strcat(resString,token);
			++curentNumberWord;
			if (countWord!=curentNumberWord)//Якщо не останнє слово
			{
				strcat(resString," ");
			}
		}
		token = strtok(NULL, seps );//пошук наступного слова
	}
	cout<<"Result:\n"<<str;
	cin.get();
	cin.get();
	return 0;
}