#include <iostream>
#include <stack>
using namespace std;

//push() - добавить элемент
//pop() - удалить верхний элемент
//top() - получить верхний элемент
//size() - размер стека
//empty() - true, если стек пуст

int main()
{
	int shelves;

	freopen("input.txt","rt",stdin);
		cin>>shelves;
		stack<int> *container=new stack<int>[shelves];
		bool *neporadok=new bool[shelves];

		//for(int i=0, s=0; i<shelves; ++i)
		//	neporadok[i]=true;

		for(int i=0, s=0; i<shelves; ++i)
		{
			cin>>s;
			for(int j=0, e=0; j<s; ++j)
			{
				cin>>e;
				if(e > shelves){ cout <<'0'<< endl; exit(1); }
				container[i].push(e);
				if(e != i+1) neporadok[i]=false;
			}
		}
	fclose(stdin);

	//ѕроверка на правильность
	bool cool=true;
	for(int i=0; i<shelves; ++i)
		if(!(neporadok[i]))
		{
			cool=false;
			break;
		}
	if(cool == true) exit(1);
	/*if(shelves == 2)
	{
		if(!neporadok[0] && !neporadok[1])
		{
			cout <<'0'<< endl;
			exit(1);
		}
		if (container[0].size() == 0)
			if(container[1].top() != 2)
			{
				cout <<'0'<< endl;
				exit(1);
			}
		if (container[1].size() == 0)
			if(container[0].top() != 1)
			{
				cout <<'0'<< endl;
				exit(1);
			}
	}*/


	//ищем максимально большую полку
	int max_shelves_true=0;
	int max_shelves=0;
	for(int i=0, value=0; i<shelves; ++i)
		if(container[i].size() > value)
		{
			max_shelves = i;
			value = container[i].size();
		}
	int storage_one;
	int storage_two;
	if(shelves == max_shelves+1)
	{
		storage_one=max_shelves-1;
		storage_two=max_shelves-2;
	}
	else if(max_shelves == 0)
	{
		storage_one=max_shelves+1;
		storage_two=max_shelves+2;
	}
	else
	{
		storage_one=max_shelves+1;
		storage_two=max_shelves-1;
	}

	if(neporadok[max_shelves])
		max_shelves_true=container[max_shelves].size();

	//¬се в максимальную полку
	for(int i = 0; i < shelves; ++i)
	{
		while (container[i].size() != 0 && neporadok[i] == false && max_shelves != i)
		{
			int t=container[i].top();
			if(container[i].size() == 1 && t-1 == i) break;

			container[max_shelves].push(t);
			container[i].pop();

			cout<<i+1<<' '<<max_shelves+1<<endl;
		}
	}
	
	int t = container[max_shelves].top();
	
	//раскидывание
	int isshelves = 0;
	while (container[max_shelves].size() != max_shelves_true)
	{
		t = container[max_shelves].top();
		if(t-1 == max_shelves && container[max_shelves].size() == 1)
		{
			break;
		}
		else if(t-1 == max_shelves)
		{
			++isshelves;
			container[storage_one].push(t);
			container[max_shelves].pop();

			cout<<max_shelves+1<<' '<<storage_one+1<<endl;
		}
		else if(t-1 == storage_one && isshelves != 0)
		{
			int isshelvestemp = isshelves;
			while(isshelvestemp != 0)
			{
				container[storage_two].push(max_shelves+1);
				container[storage_one].pop();
					
				cout<<storage_one+1<<' '<<storage_two+1<<endl;					
				--isshelvestemp;
			}

			container[t-1].push(t);
			container[max_shelves].pop();

			cout<<max_shelves+1<<' '<<t<<endl;
				
			while(isshelvestemp != isshelves)
			{
				container[storage_one].push(max_shelves+1);
				container[storage_two].pop();

				cout<<storage_two+1<<' '<<storage_one+1<<endl;

				++isshelvestemp;
			}
		}
		else
		{
			container[t-1].push(t);
			container[max_shelves].pop();

			cout<<max_shelves+1<<' '<<t<<endl;
		}
	}

	while(isshelves != 0)
	{
		container[max_shelves].push(max_shelves+1);
		container[storage_one].pop();

		cout<<storage_one+1<<' '<<max_shelves+1<<endl;
		--isshelves;
	}

	cin.get();
	cin.get();
	return 0;
}