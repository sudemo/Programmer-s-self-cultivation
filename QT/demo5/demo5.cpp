#include <iostream>
#include<vector>
#include <stack>
#include<algorithm>

using namespace std;

stack<int> intCover(int x)
{
    stack<int> intStack;
    while (x > 0)
    {
        intStack.push(x % 2);
        x /= 2;
    }
    int y = 8 - intStack.size();
    for (int i = 0; i < y; i++)
    {
        intStack.push(0);
    }
    return intStack;
}

void main()
{
    int c, b, a[10];
    int e, f, g, h;
    vector<int> intVector;
    for (int i = 0; i < 50; i++)
    {
        intVector.push_back(0);
    }
    cin >> c >> b >> a[0] >> a[1] >> a[2] >> a[3] >> a[4] >> a[5] >> a[6] >> a[7] >> a[8] >> a[9];
    for (int i = 0; i < 10; i++)
    {
        stack<int> intStack = intCover(a[i]);
        e = intStack.top();
        intStack.pop();
        e = 2 * e + intStack.top();
        intStack.pop();
        f = intStack.top();
        intStack.pop();
        f = 2 * f + intStack.top();
        intStack.pop();
        g = intStack.top();
        intStack.pop();
        g = 2 * g + intStack.top();
        intStack.pop();
        h = intStack.top();
        intStack.pop();
        h = 2 * h + intStack.top();
        intStack.pop();
        if (((e + f + g + h) % b) < c)
        {
            intVector[(e + f + g + h) % b] += 1;
        }
    }
    sort(intVector.begin(), intVector.end());
    cout << intVector[intVector.size() - 1] << endl;
    system("pause");
    return;
}