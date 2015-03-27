//почти
//коммерческий каркул€тор
/*
‘ирма OISAC выпустила новую версию калькул€тора. Ётот калькул€тор берет с пользовател€ деньги за совершаемые
арифметические операции. —тоимость каждой операции в долларах равна 5% от числа, которое €вл€етс€ результатом операции. 
Ќа этом калькул€торе требуетс€ вычислить сумму N натуральных чисел (числа известны). Ќетрудно заметить, что от того, в каком пор€дке мы будем складывать эти числа, иногда зависит, в какую сумму денег нам обойдетс€ вычисление суммы чисел (тем самым оказываетс€ нарушен классический принцип Уот перестановки мест слагаемых сумма не мен€етс€Ф). 
Ќапример, пусть нам нужно сложить числа 10, 11, 12 и 13. “огда если мы сначала сложим 10 и 11 (это обойдетс€ нам в 1.05 И), потом результат с 12 (1.65 И), и затем с 13 (2.3 И), то всего мы заплатим 5 И, если же сначала отдельно сложить 10 и 11 (1.05 И), потом 12 и 13 (1.25 И) и, наконец, сложить между собой два полученных числа (2.3 И), то в итоге мы заплатим лишь 4.6 И. 
Ќапишите программу, котора€ будет определ€ть, за какую минимальную сумму денег можно найти сумму данных N чисел.
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