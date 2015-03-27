#include <iostream>
#include <string>
#include <stack>
using namespace std;
int obr(char simb)
{
    switch (simb) {
        case ')': simb='('; break;
        case ']': simb='['; break;
        case '}': simb='{'; break;
    }
    return simb;
}
int main()
{
	stack <char> st;
	string str;
    cin>>str;
	int size=str.size();

	for(int i=0; i<size; ++i)
	{
		if(str[i]=='(' || str[i]=='[' || str[i]=='{')
		{
			st.push(str[i]);
		}
		else if(!(st.empty()) && st.top()==obr(str[i]))
		{
			st.pop();
		}
		else
		{
			st.push(str[i]);
			break;
		}
	}
    if(st.empty()) cout<<"yes"<<endl;
	else cout<<"no"<<endl;
	return 0;
}