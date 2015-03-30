#include <cmath>

extern "C" __declspec(dllexport) double _cdecl f1(double x)
{
	return cos(x);
}

extern "C" __declspec(dllexport) double _cdecl f2(double x)
{
	return sin(x);
}