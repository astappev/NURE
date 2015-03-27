/*
создать класс примитив с двумя чисто виртуальными методами: перемещение и принт.
Создать классы точка, линия, треугольник наследуясьот базового класса примитив.
Создать класс цветная наследуясь от базового класса линия.
В классах опрделить основные конструкторы и переопределить методы перемещение и принт.
Создать функцию, которая принимает в качестве параметра ссылку на примитив и перемещает переданную фигуру несколько раз.
Визвать эту функцию в главной программы для линии, цветной линии, треугольника.
*/
#include <iostream>
#include <math.h>
using namespace std;
class Tprimitive
{
public:
	virtual void move (int delta)=0;
	virtual void print () const=0;
};
struct Tpoint: public Tprimitive
{
	int x,y;
	Tpoint(int x_, int y_):x(x_),y(y_){}
	
	Tpoint():x(0),y(0){}
	virtual void move (int delta)
	{
		x+=delta;
		y+=delta;
	}
	virtual void print () const
	{
		cout<<"point{"<<x<<":"<<y<<"} ";
	}
};
class Tline: public Tprimitive
{
	Tpoint p1,p2;//Агрегация
public:
	Tline(){}
	Tline(const Tpoint& p1_, const Tpoint& p2_):p1(p1_),p2(p2_){}
	Tline(const Tline &l) :p1(l.p1),p2(l.p2){}
	
	virtual void move (int delta)
	{
		p1.move(delta);
		p2.move(delta);
	}
	virtual void print () const
	{
		p1.print();
		p2.print();
	}
};

class TColorLine: public Tline
{
	Tpoint p1,p2;//Агрегация
	int color;
	public:
	TColorLine():color(255){}
	TColorLine(const Tpoint &p1_, const Tpoint &p2_, int c) :p1(p1_),p2(p2_), color(c){}
	TColorLine(const TColorLine &l):Tline(l), color(l.color) {}
	virtual void print () const
	{
		Tline::print();
		cout<<" color {"<<color<<"} ";
	}
};

class Ttriangle: public Tprimitive
{
	Tpoint p1,p2,p3;
	int color;public:
	Ttriangle():color(255){}
	Ttriangle(const Tpoint& p1_, const Tpoint& p2_, const Tpoint& p3_, int c):p1(p1_),p2(p2_),p3(p3_), color (c){}
	Ttriangle(const Ttriangle &l):p1(l.p1),p2(l.p2),p3(l.p3), color(l.color){}
	virtual void move(int delta)
	{
		p1.move(delta);
		p2.move(delta);
		p3.move(delta);
	}

	virtual void print () const
	{
		p1.print();
		p2.print();
		p3.print();
		cout<<" color {"<<color<<"} ";
	}
};

void move_primitive(Tprimitive& p)
{
	p.print();
	cout<<"\nmove 1:\n:";
		p.move(10);
	p.print();
	cout<<"\nmove 2:\n:";
		p.move(30);
	p.print();
	cout<<"\nmove 3:\n:";
		p.move(-10);
}
int main()
{
	cout<<"test move line:\n";
	Tline l(Tpoint(5,10),Tpoint(10,20));
	move_primitive(l);
	cout<<"ntest move color line:\n\n";
	TColorLine c1(Tpoint(5,10),Tpoint(10,20),125);
	move_primitive(c1);
	cout<<"ntest move ttriangle:\n\n";
	Ttriangle t(Tpoint(5,10),Tpoint(10,20),Tpoint(7,7), 125);
	move_primitive(t);
	cout<<endl;
	system("PAUSE");
	return 0;
}
