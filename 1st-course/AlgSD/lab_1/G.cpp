#include <iostream>
using namespace std;

int main()
{
	int k=0; //������ �� ���� ���
	int T=0; //����� ��������� �����
	int S=0; //��������� �����
	int N=0; //������������ ����
	cin>>k>>T>>S>>N;

	unsigned long long  Money = 0;
 
	unsigned long long  Mines = 0;
	unsigned long long* B = new unsigned long long[N+1];
	for (int i = 0; i<N; i++)
		B[i] = 0;
	B[0] = 1;
	for(int i = 0; i<N; i++)
	{ 
		Mines+=B[i];
		Money+=(k*Mines);
		if(Money>=S && (N-i-T-1)*k>=S)
		{
			B[i+T+1] = Money/S;
			Money%=S;
		}
	}
	cout<< Money;
}