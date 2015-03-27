#include <cstdlib>
#include <iostream>
using namespace std;

#define GREEN 0
#define YELLOW 1
#define RED 2

const int n = 9;
int matr[n][n], flow[n][n], status[n], way[n];
int head, tail;
int q[n+2];

int min(int x, int y) //Больше-меньше
{
	if (x < y) return x;
	else return y;
}

void enque(int x) //добавить в очередь
{
	q[tail] = x;
	tail++;
	status[x] = YELLOW;
}

 int deque() //убрать из очереди
{
	int x = q[head];
	head++;
	status[x] = RED;
	return x;
}

int bfs(int start, int end) //Поиск в ширину
{
	int u,v;
	for( u = 0; u < n; u++ )
		status[u]=GREEN;
	
	head=0;
	tail=0;
	enque(start);
	way[start]= -1;
	while(head!=tail)
	{
		u=deque();
		for( v = 0; v < n; v++ )
		{
			if(status[v] == GREEN && (matr[u][v]-flow[u][v]) > 0) {
				enque(v);
				way[v]=u;
			}
		}
	}
	if(status[end] == RED)	return 0;
	else return 1;
}

int max_flow(int source, int stock) //Максимальный поток из истока в сток
{
	int maxflow=0;
	while(bfs(source,stock) == 0)
	{
		int delta=10000;
		for(int u = n-1; way[u] >= 0; u=way[u])
		{
			delta=min(delta, ( matr[way[u]][u] - flow[way[u]][u] ) );
		}
		for(int u = n-1; way[u] >= 0; u=way[u])
		{
			flow[way[u]][u] += delta;
			flow[u][way[u]] -= delta;
		}
		maxflow+=delta;
	}
	return maxflow;
}
int restore_flow(int source, int stock) //Максимальный поток из истока в сток
{
	int maxflow=0;
	while(bfs(source,stock) == 0)
	{
		int delta=10000;
		for(int u = n-1; way[u] >= 0; u=way[u])
		{
			delta=min(delta, ( matr[way[u]][u] - flow[way[u]][u] ) );
		}
		for(int u = n-1; way[u] >= 0; u=way[u])
		{
			flow[way[u]][u] += delta;
			flow[u][way[u]] -= delta;
		}
		maxflow+=delta;
	}
	return maxflow;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	freopen ("input.txt", "r", stdin);

	for(int i = 0; i < n; i++ )
	{
		for(int j = 0; j < n; j++ )
		cin >> matr[i][j];
	}

	for(int i = 0; i < n; i++ )
	{
		for(int j = 0; j < n; j++)
			//flow[i][j] = 0;
			cin>>flow[i][j];
	}

	cout << "Максимальный поток: " << max_flow(0,n-1) << endl;
	cout << "Матрица движения потоков: " << endl;
	for(int i = 0; i < n; i++ )
	{
		for(int j = 0; j < n; j++ )
			cout << flow[i][j] << "\t";
		cout << endl;
	}
	return 0;
}
