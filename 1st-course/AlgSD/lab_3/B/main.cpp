#include <cstdlib>
#include <iostream>
using namespace std;

typedef struct
{
	int hsize;
	int *mas;
} heap;

int get_max(heap *heap)
{
	return heap->mas[0];
}

void add_heap(heap *heap, int x)
{
	int y, pos=heap->hsize, npos;
	heap->mas[heap->hsize++] = x;
	npos=(pos-1)/2;
	while (pos && heap->mas[pos] > heap->mas[npos]) {
		y=heap->mas[pos];
		heap->mas[pos]=heap->mas[npos];
		heap->mas[npos] = y;
		pos=npos;
		npos=(pos-1)/2;
	}
}

void print(heap *heap)
{
	int pos=heap->hsize;
	for(int i=0; i < pos; ++i)
		cout<<heap->mas[i]<<' ';
}

void checkdown(heap *heap, int p)
{
	int size=heap->hsize;

	int c;
	c = 2*p+1;
	if( c > size )
	{
		cout<<p+1<<endl;
		return;
	}

	if( c+1 < size && heap->mas[c + 1] > heap->mas[c] )
		c++;

	if( heap->mas[c] > heap->mas[p] )
	{
		int tmp = heap->mas[c];
		heap->mas[c] = heap->mas[p];
		heap->mas[p] = tmp;
		checkdown(heap, c);
	}
	else cout<<p+1<<endl;
}

void m_elem(heap *heap, int p, int v)
{
	--p;
	heap->mas[p] -= v;
	checkdown(heap, p);
}

int main(){
	freopen("input.txt", "r", stdin);
	int n, m, t, v;
	cin>>n;
	int *mas = new int[n];
	heap heap={0, mas};

	for (int i = 0; i < n; i++)
	{
		cin>>t;
		add_heap(&heap, t);
	}
	cin>>m;
	for (int i = 0; i < m; i++)
	{
		cin>>t>>v;
		m_elem(&heap, t, v);
	}

	//cout<<get_max(&heap);
	print(&heap);

	return 0;
}