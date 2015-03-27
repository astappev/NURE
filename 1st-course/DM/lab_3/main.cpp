#include <iostream>
using namespace std;
struct Graf
{
	int a;
	int b;
};

int main()
{
	Graf * graf = new Graf[37];
	graf[0].a=1; graf[0].b=1;
	graf[1].a=1; graf[1].b=3;
	graf[2].a=1; graf[2].b=6;
	graf[3].a=1; graf[3].b=9;
	graf[4].a=2; graf[4].b=1;
	graf[5].a=2; graf[5].b=4;
	graf[6].a=2; graf[6].b=5;
	graf[7].a=2; graf[7].b=6;
	graf[8].a=2; graf[8].b=7;
	graf[9].a=2; graf[9].b=8;
	graf[10].a=3; graf[10].b=2;
	graf[11].a=3; graf[11].b=3;
	graf[12].a=3; graf[12].b=6;
	graf[13].a=3; graf[13].b=9;
	graf[14].a=4; graf[14].b=2;
	graf[15].a=4; graf[15].b=5;
	graf[16].a=5; graf[16].b=7;
	graf[17].a=5; graf[17].b=8;
	graf[18].a=5; graf[18].b=9;
	graf[19].a=6; graf[19].b=1;
	graf[20].a=6; graf[20].b=2;
	graf[21].a=6; graf[21].b=5;
	graf[22].a=6; graf[22].b=8;
	graf[23].a=7; graf[23].b=1;
	graf[24].a=7; graf[24].b=2;
	graf[25].a=7; graf[25].b=3;
	graf[26].a=7; graf[26].b=5;
	graf[27].a=7; graf[27].b=9;
	graf[28].a=8; graf[28].b=2;
	graf[29].a=8; graf[29].b=3;
	graf[30].a=8; graf[30].b=4;
	graf[31].a=8; graf[31].b=7;
	graf[32].a=8; graf[32].b=9;
	graf[33].a=9; graf[33].b=1;
	graf[34].a=9; graf[34].b=2;
	graf[35].a=9; graf[35].b=4;
	graf[36].a=9; graf[36].b=5;
	
	cout<<"Matrica smeznosti:\n";
	//смежность
	int matr_sm[9][9]={0};
	for (int k=0; k<36; ++k)
		matr_sm[graf[k].a-1][graf[k].b-1]=1;
	
	for (int i=0; i<9; ++i, cout<<'\n')
		for (int j=0; j<9; ++j)
			cout<<matr_sm[i][j]<<' ';

	cout<<"\nMatrica dostizimosti:\n";

	//достижимости
	int matr_ds[9][9]={0};
	for(int i=0; i<9;++i)
		for(int j=0; j<9;++j)
			matr_ds[i][j]=matr_sm[i][j];

	for(int i=0; i<9;++i)
	for(int j=0; j<9;++j)
	{
		if(!matr_sm[i][j])
		{
			for(int k=0; k<9; ++k)
				if(matr_sm[i][k])
				{
					for(int l=0; l<9; ++l)
						if(matr_sm[k][l])
						{
							matr_ds[i][j]=1;
							break;
						}
				}
		}
	}
	
	for (int k=0; k<9; ++k, cout<<'\n')
		for (int p=0; p<9; ++p)
			cout<<matr_ds[k][p]<<' ';

	cout<<"\nMatrica incidentnosti:\n";

	//инцидентность
	int matr_ic[9][36]={0};
	for (int k=0; k<36; ++k)
	{
		if(graf[k].a==graf[k].b) matr_ic[k][k]=2;
		else
		{
		matr_ic[graf[k].a-1][k]=1;
		matr_ic[graf[k].b-1][k]=-1;
		}
	}
			
	for (int k=0; k<9; ++k, cout<<'\n')
		for (int p=0; p<36; ++p)
			cout<<matr_ic[k][p]<<' ';
}