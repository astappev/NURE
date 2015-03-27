#include <stdio.h>
#include <iostream>

using namespace std;
struct Clas{
	int clas;
	char name[90];
};
int main()
{
	int n=0;
	Clas* Children=new Clas[n+2];
	freopen("input.txt","rt",stdin);
		while(cin>>Children[n].clas>>Children[n].name)
			n++;
	fclose(stdin);
	freopen("output.txt","wt",stdout);
	for(int k=0; k<13; ++k)
		for (int i=0; i<n; ++i)
			if(Children[i].clas==k)
				cout<<Children[i].clas<<' '<<Children[i].name<<endl;
	fclose(stdout);
	return 0;
}