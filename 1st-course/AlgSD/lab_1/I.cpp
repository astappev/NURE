#include <iostream>
#include <math.h>

int main ()
{ 
    long x1, x2, y1, y2, x, y;

    std::cin>>x1>>y1>>x2>>y2;

    x = abs(x1 - x2);
    y = abs(y1 - y2);

    if (x == 0) std::cout<<y+1;
    else 
        if (y == 0) std::cout<<x+1;
        else 
        {
               while (x != 0 && y != 0)
            {
                if (x > y) x = x%y;
                else y = y%x;
            }
               std::cout<<x+y+1;
        }
return 0;
}