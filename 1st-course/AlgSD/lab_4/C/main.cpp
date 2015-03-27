#include <iostream>
#include <stdio.h>
using namespace std;

void qmSort(int* A, int low, int high) {
      int i = low;                
      int j = high;
      int x = A[(low+high)/2];
      do {
          while(A[i] < x) ++i;
          while(A[j] > x) --j;
          if(i <= j){           
              int temp = A[i];
              A[i] = A[j];
              A[j] = temp;
              i++; j--;
          }
      } while(i < j);
      if(low < j) qmSort(A, low, j);
      if(i < high) qmSort(A, i, high);
  }

int main()
{
	freopen("input.txt", "r", stdin);
	int n;
	cin>>n;
	int *mas = new int[n];
	for(int i = 0; i < n; ++i)
		cin>>mas[i];
	//qsort (mas, n, sizeof(int), compare);
	qmSort(mas, 0, n-1);
	
	for(int i = 0; i < n; ++i, cout<<' ')
		cout<<mas[i];
	return 0;
}