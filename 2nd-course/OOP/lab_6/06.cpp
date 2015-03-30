/*
Àñòàïïåâ Îëåã
ÈÍÔ-12-1

*/
#include <iostream>
using namespace std;
template <class T>
class Array2D
{
public:
	class ArraylD
	{
	private:
		int dim2;
		T * Array1;
	public:
		friend class Array2D;
		ArraylD() :Array1(NULL), dim2(0) {}
		T& operator[](int index);
		const T& operator[] (int index) const;
	}; //class ArraylD 
private:
	int dim1;
	ArraylD* Array2;
public:
	Array2D() :dim1(0), Array2(NULL){};
	Array2D(int d1, int d2);
	virtual ~Array2D();
	ArraylD& operator[] (int index)
	{
		return Array2[index];
	}
	const ArraylD& operator[] (int index) const
	{
		return Array2[index];
	}
};
template <class T>
T& Array2D<T>::ArraylD::operator[](int index)
{
	return Array1[index];
}
template <class T>
const T& Array2D<T>::ArraylD::operator[](int index)const
{
	return Array1[index];
}
template <class T>
Array2D<T>::Array2D(int d1, int d2)
{
	dim1 = d1;
	Array2 = new ArraylD[dim1];
	for (int i(0); i<d1; ++i)
	{
		Array2[i].dim2 = d2;
		Array2[i].Array1 = new T[d2];
	}
}
template <class T>
Array2D<T>::~Array2D()
{
	for (int i(0); i<dim1; ++i)
	{
		delete[]Array2[i].Array1;
	}
	delete[] Array2;
}
int main()
{
	int n(5), m(6);
	Array2D<int> array2D(n, m);
	for (int i = 0; i< n; cout << endl, ++i)
	for (int j = 0; j< m; ++j)
	{
		array2D[i][j] = rand() % 11;
		cout << array2D[i][j] << '\t';
	}
	
	int *mas = new int[n];
	for (int i = 0; i < n; ++i)
	{
		int min = array2D[i][0];
		for (int j = 0; j < m; ++j)
		if (array2D[i][j] < min) min = array2D[i][j];
		mas[i] = min;
	}
	cout << endl;
	int max = mas[0], index = 0;
	for (int i = 0; i < n; ++i)
	{
		cout << mas[i] << ' ';
		if (mas[i] > max)
		{
			max = mas[i];
			index = i;
		}
	}
	cout << "\nIndex max = " << index + 1;
		
	cin.get();
	return 0;
}