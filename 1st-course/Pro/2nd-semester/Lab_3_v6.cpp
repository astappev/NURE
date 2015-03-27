/*
Лабораторная работа 6 (3)
1)  количество строк, не содержащих ни одного нулевого элемента;
2)  максимальное из чисел, встречающихся в заданной матрице более одного раза.

Вариант 6
Дана целочисленная прямоугольная матрица. Определить:
1)  сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент;
2)  номера строк и столбцов всех седловых точек матрицы.

*/
#include <iostream>
using namespace std;
int main()
{
	FILE *fmas(NULL),*fout(NULL);
	fmas=fopen("matr.txt","r");
	if (!fmas)
	{
		cout<<"Can not open file"<<endl;
		return 1;
	}
	int n,m;
	fscanf(fmas,"%d%d",&n,&m);
	int **mas=new int*[n];

	for(int i=0; i<n; i++)
		mas[i]=new int[m];

	for(int i=0; i<n; i++)
		for(int j=0; j<m; j++)
			fscanf(fmas,"%d",&mas[i][j]);
	fclose(fmas);

	//вывод матрицы
	for(int i=0;i<n;i++,cout<<endl)
		for(int j=0;j<m;j++)
			cout<<mas[i][j]<<'\t';
	fout=fopen("finish.txt","w");
	int sum=0;
	for(int i=0; i<n; i++)
	{
		sum=0;
		bool otr=false;
		for (int j=0; j<m; j++)
		{
            if (mas[i][j]<0) otr=true;
			sum+=mas[i][j];
		}
		if (otr) fprintf(fout, "\nSumma otricatelnih v %d  stroke = %d", (i+1), sum);		
	}

	int min=0, jmin=0, max=0, imax=0;
	for(int i=0; i<n; i++)
	{
		min=mas[i][0];
		for(int j=0; j<m; j++)
		{
			if(mas[i][j]<min)
			{
				min=mas[i][j];
				jmin=j;
			}
		}
		max=mas[0][jmin];
		for(int k=0; k<n; k++)
		{
			if(mas[k][jmin]>max)
			{
				max=mas[k][jmin];
				imax=k;
			}
		}
		if(max==min) fprintf(fout, "\nSedlovaya tochka = %d. Находится в строке %d, столбце %d\n", mas[imax][jmin], imax+1, jmin+1);
	}
	
	fclose(fout);
	cin.get();
	cin.get();
	return 0;
}
/*
matr.txt
3 4
5 6 4 5
-2 5 3 7
8 7 -2 6
*/