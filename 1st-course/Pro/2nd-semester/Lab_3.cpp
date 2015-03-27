#include <iostream>
using namespace std;
int main()
{
	FILE *fmatr(NULL),*fout(NULL);
	fmatr=fopen("matr.txt","r");
	if (!fmatr)
	{
		cout<<"Can not open file"<<endl;
		return 1;
	}
	int n,m;
	fscanf(fmatr,"%d%d",&n,&m);//считываем два числа которые
	int **mas=new int*[n];

	for(int i=0; i<n; i++)
		mas[i]=new int[m];

	for(int i=0; i<n; i++)
		for(int j=0; j<m; j++)
			fscanf(fmatr,"%d",&mas[i][j]);
	fclose(fmatr);
	for(int i=0;i<n;i++,cout<<endl)
		for(int j=0;j<m;j++)
			cout<<mas[i][j]<<'\t';

	int count=0;
	for(int i=0; i<n; i++)
	{
		bool null=false;
		for (int j=0; j<m; j++)   
            if (mas[i][j]==0) null=true;
		if (!null) count++;
	}
	cout<<"Kol-vo strok bez nuley = "<<count<<endl;

	int max=0, cmax=0, fmax=999;
		do{
			max=0;
			for(int i=0; i<n; i++)
				for(int j=0; j<m; j++)
				{
					if(mas[i][j]>max && mas[i][j]<fmax)
					{
						max=mas[i][j];
						cmax=1;
					}
					else if (mas[i][j]==max) ++cmax;
				}
			fmax=max;
		}while(cmax<2);
	cout<<"Maksimalniy chto vstrecaetsa mnogo raz = "<<max<<endl;
	
	fout=fopen("finish.txt","w");
	fprintf(fout,"%s%d","\nKol-vo strok bez nuley = ",count);
	fprintf(fout,"%s%d","\nMaksimalniy chto vstrecaetsa mnogo raz = ",max);
	fclose(fout);
	cin.get();
	return 0;
}

/*
matr.txt
3 4
5 4 7 4
-8 9 -9 -3
4 -5 6 0
*/