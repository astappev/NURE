#include <cstdlib>
#include <iostream>
#include <string>
using namespace std;

class stek{
public:          
	int Size, sData[100];
	void s_exit(){
		cout<<"bye"<<endl;
		exit(0);
	}
	void clear(){
		Size=0; cout<<"ok"<<endl;
	} 
	void back(){
		if(Size!=0) cout<<sData[Size-1]<<endl; 
		else cout<<"error"<<endl;
	}
	void push(){
		int n;
		cin>>n;
		sData[Size]=n;
		Size++;
		cout<<"ok"<<endl;
	}
	void pop(){
		if(Size!=0){
			cout<<sData[Size-1]<<endl;
			Size-=1;
		}
		else cout<<"error"<<endl;
	}
	void size(){
		cout<<Size<<endl;
	}
};
stek Stek;

int main()
{
	string command;
		cin>>command;
	if(command=="exit") Stek.s_exit();
	else if(command=="clear") Stek.clear();
	else if(command=="back") Stek.back();
	else if(command=="push") Stek.push();
	else if(command=="pop") Stek.pop();
	else if(command=="size") Stek.size();
	main();

	return 0;
}