#include <iostream>
using namespace std;

int compare (const void *a, const void *b)
{
  return ( *(int*)a - *(int*)b );
}

int main()
{
	freopen("input.txt", "r", stdin);
	bool flag;

	int n;
	cin>>n;
	int *a = new int[n];
	for(int i = 0; i < n; i++)
		cin>>a[i];

	int m;
	cin>>m;
	int *b = new int[m];
	for(int i = 0; i < m; i++)
		cin>>b[i];

	qsort (a, n, sizeof(int), compare);
	qsort (b, m, sizeof(int), compare);
	for(int i = 0, j=0; i < n; i++)
	{
		flag = false;
		for(; j < m; j++)
		{
			if(a[i] == b[j])
			{
				flag = true;
				break;
			}
		}
		if(!flag)
		{
			cout<<"NO";
			return 0;
		}
	}

	for(int i = 0, j = 0; i < m; i++)
	{
		flag = false;
		for(; j < n; j++)
		{
			if(b[i] == a[j])
			{
				flag = true;
				break;
			}
		}
		if(!flag)
		{
			cout << "NO";
			return 0;
		}
	}
	cout << "YES";
	return 0;
}