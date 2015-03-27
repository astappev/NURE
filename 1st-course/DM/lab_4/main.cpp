#include <iostream>
#include <locale>
using namespace std;

#define LETTER(a){\
	switch(a)\
	{\
		case 1: cout<<'A'; break;\
		case 2:	cout<<'B'; break;\
		case 3: cout<<'C'; break;\
		case 4: cout<<'D'; break;\
		case 5: cout<<'E'; break;\
		case 6: cout<<'F'; break;\
		case 7: cout<<'G'; break;\
		case 8: cout<<'H'; break;\
		default: cout<<"Ошибка"; break;\
	}\
};

int main()
{
	setlocale(LC_ALL, "Russian");
	const int n=8;
	int predok[n], nach = -1, D[n], max=999;
    bool flag[n], dow=false;
	int matr[8][8]={0,7,4,25,max,12,22,max,max,0,max,36,max,10,11,19,max,12,0,max,max,max,max,max,max,36,12,0,14,42,14,12,max,max,max,max,0,max,6,21,max,10,max,max,19,0,8,max,max,max,max,14,6,max,0,17,max,max,max,12,21,max,max,0};
	cout<<"Исходная матрица растояний:\nA\tB\tC\tD\tE\tF\tG\tH"<<endl;
	for (int i = 0; i < n; ++i, cout<<endl)
		for (int j = 0; j < n; ++j, cout<<'\t')
			if(matr[i][j]==max) cout<<'*';
			else cout<<matr[i][j];

		cout<<"\nКратчайший путь от (введите значение от 1 до 8): ";
		cin>>nach;
		--nach;
	
	for (int i = 0; i < n; i++) {
        predok[i] = nach;
        flag[i] = false;
        D[i] = matr[nach][i];
    }

	flag[nach] = true;
    predok[nach] = 0;
    for (int i = 0; i < n - 1; i++) {
        int k = 0;
        int minras = max;
        for (int j = 0; j < n; j++) {
            if (!flag[j] && minras > D[j]) {
                minras = D[j];
                k = j;
            }
        }
        flag[k] = true;
        for (int j = 0; j < n; j++) {
            if (!flag[j] && D[j] > D[k] + matr[k][j]) {
                D[j] = D[k] + matr[k][j];
                predok[j] = k;
            }
        }
    }
	
    cout<<"Заданные растояния:"<<endl;
    for (int i = 0; i < n; i++) {
		{
			if(D[i]==max)
			{
				cout<<"От ";
				LETTER(nach+1)
				cout<<" до ";
				LETTER(i+1)
				cout<<": не достежимо"<<endl;
			}
			else if (D[i]==0)
			{
				cout<<"От ";
				LETTER(nach+1)
				cout<<" до ";
				LETTER(i+1)
				cout<<": исходная точка"<<endl;
			}
			else
			{
				cout<<"От ";
				LETTER(nach+1)
				cout<<" до ";
				LETTER(i+1)
				cout<<": "<<D[i]<<endl;
			}
		}
    }
    return 0;
}