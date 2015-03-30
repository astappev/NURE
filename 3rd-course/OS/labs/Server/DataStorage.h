#pragma once

#include <vector>
using std::vector;

// Класс DataStorage содержит результаты вычислений: вектор отсортированных чисел.
// Именно эти данные передаются по сети.
class DataStorage
{
private:
	// Значения функции в диапазоне.
	vector<double> values;
	// Начало диапазона вычислений (с какого X начинались вычисления значений функции).
public:
	DataStorage();
	// Возвращает вектор значений функции.
	vector<double>& GetValues() { return values; }
};