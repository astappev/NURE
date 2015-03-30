#pragma once

#include <vector>
using std::vector;

// ����� DataStorage �������� ���������� ����������: ������ ��������������� �����.
// ������ ��� ������ ���������� �� ����.
class DataStorage
{
private:
	// �������� ������� � ���������.
	vector<double> values;
	// ������ ��������� ���������� (� ������ X ���������� ���������� �������� �������).
public:
	DataStorage();
	// ���������� ������ �������� �������.
	vector<double>& GetValues() { return values; }
};