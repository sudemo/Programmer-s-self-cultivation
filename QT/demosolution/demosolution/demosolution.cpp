// demosolution.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
using namespace std;

int main()

{
	vector<int> v1 = { 1, 2, 3, 4, 5, 6 };
	int even_count = 0;

		
    cout << "The number of even is " << even_count << endl;
	
	
		int i = 1024, j = 2048;

		cout << "outside i value:" << i << " addr:" << &i << endl;

		auto fun1 = [i] {
			cout << "inside  i value:" << i << " addr:" << &i << endl;
			// cout << j << endl; // j δ����

		};
		fun1();
		int a = 1, b = 2, c = 3;
		auto lam2 = [&, a]() { cout << "ans is "<<a << b << c << endl; };
		lam2();

	
		vector<string> address{ "111","222",",333",".org","wwwtest.org" };
		for_each(address.begin(), address.end(), [](string& address) {std::cout << &address << endl; }); //��Ȼǰ��ȡ�� address�����ã����Ǻ���cout �����ʱ�򲻹���ʲô��ʽ���õģ�ֱ�������address��ֵ 

		
		
		
		
		
		//return 0;
	cin.get();
}

