//�����
//������������ ����������
/*
����� OISAC ��������� ����� ������ ������������. ���� ����������� ����� � ������������ ������ �� �����������
�������������� ��������. ��������� ������ �������� � �������� ����� 5% �� �����, ������� �������� ����������� ��������. 
�� ���� ������������ ��������� ��������� ����� N ����������� ����� (����� ��������). �������� ��������, ��� �� ����, � ����� ������� �� ����� ���������� ��� �����, ������ �������, � ����� ����� ����� ��� ��������� ���������� ����� ����� (��� ����� ����������� ������� ������������ ������� ��� ������������ ���� ��������� ����� �� ���������). 
��������, ����� ��� ����� ������� ����� 10, 11, 12 � 13. ����� ���� �� ������� ������ 10 � 11 (��� ��������� ��� � 1.05 �), ����� ��������� � 12 (1.65 �), � ����� � 13 (2.3 �), �� ����� �� �������� 5 �, ���� �� ������� �������� ������� 10 � 11 (1.05 �), ����� 12 � 13 (1.25 �) �, �������, ������� ����� ����� ��� ���������� ����� (2.3 �), �� � ����� �� �������� ���� 4.6 �. 
�������� ���������, ������� ����� ����������, �� ����� ����������� ����� ����� ����� ����� ����� ������ N �����.
*/
#include <iostream>
#include <vector>
#include <iterator>
using namespace std;

class Heap {
public:
    Heap();
    ~Heap();
    void insert(int element);
    int deletemin();
    int size() { return heap.size(); }
private:
    int left(int parent);
    int right(int parent);
    int parent(int child);
    void heapifyup(int index);
    void heapifydown(int index);
private:
    vector<int> heap;
};

Heap::Heap() { }
Heap::~Heap() { }

void Heap::insert(int element)
{
    heap.push_back(element);
    heapifyup(heap.size() - 1);
}

int Heap::deletemin()
{
    int min = heap.front();
    heap[0] = heap.at(heap.size() - 1);
    heap.pop_back();
    heapifydown(0); //?
	heapifyup(heap.size() - 1);
    return min;
}

void Heap::heapifyup(int index)
{    
    while ( ( index > 0 ) && ( parent(index) >= 0 ) &&
            ( heap[parent(index)] > heap[index] ) )
    {
        int tmp = heap[parent(index)];
        heap[parent(index)] = heap[index];
        heap[index] = tmp;
        index = parent(index);
    }
}

void Heap::heapifydown(int index)
{     
    int child = left(index);
    if ( ( child > 0 ) && ( right(index) > 0 ) &&
         ( heap[child] > heap[right(index)] ) )
    {
        child = right(index);
    }
    if ( child > 0 )
    {
        int tmp = heap[index];
        heap[index] = heap[child];
        heap[child] = tmp;
        heapifydown(child);
    }
}

int Heap::left(int parent)
{
    int i = ( parent << 1 ) + 1;
    return ( i < heap.size() ) ? i : -1;
}

int Heap::right(int parent)
{
    int i = ( parent << 1 ) + 2;
    return ( i < heap.size() ) ? i : -1;
}

int Heap::parent(int child)
{
    if (child != 0)
    {
        int i = (child - 1) >> 1;
        return i;
    }
    return -1;
}

int main()
{
    freopen("input.txt", "r", stdin);
	int n, k;
	std::cin>>n;
	Heap* myheap = new Heap();
	for(int i = 0; i < n; ++i)
	{
		std::cin>>k;
		myheap->insert(k);
	}


    int temp1, temp2;
	double sum, cost=0;
    while(myheap->size() > 1)
	{
		temp1=myheap->deletemin();
		temp2=myheap->deletemin();
		sum=temp1+temp2;
		cost += (sum*5/100);
		myheap->insert(sum);
    }

	cout<<cost;

    delete myheap;
}