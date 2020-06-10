#define _CRT_SECURE_NO_DEPRECATE
#include <iostream>
#include <algorithm>

using namespace std;
const int g_MaxNumberLength = 10;

int compare(const void* strNumber1, const void* strNumber2)
{
    char* g_StrCombine1 = new char[g_MaxNumberLength * 2 + 1];
    char* g_StrCombine2 = new char[g_MaxNumberLength * 2 + 1];

    strcpy(g_StrCombine1, *(const char**)strNumber1);
    strcat(g_StrCombine1, *(const char**)strNumber2);

    strcpy(g_StrCombine2, *(const char**)strNumber2);
    strcat(g_StrCombine2, *(const char**)strNumber1);

    int ret = strcmp(g_StrCombine1, g_StrCombine2);

    delete[] g_StrCombine1;
    g_StrCombine1 = nullptr;
    delete[] g_StrCombine2;
    g_StrCombine2 = nullptr;
    return ret;
}

void PrintMinNumber(int* numbers, int length)
{
    char abc123[90];
    if (numbers == nullptr || length <= 0)
    {
        return;
    }

    char** strNumbers = (char**)(new int[length]);
    for (int i = 0; i < length; ++i)
    {
        strNumbers[i] = new char[g_MaxNumberLength + 1];
        memset(strNumbers[i], 0, g_MaxNumberLength + 1);
        sprintf(strNumbers[i], "%d", numbers[i]);
    }

    qsort(strNumbers, length, sizeof(char*), compare);

    for (int i = 0; i < length; ++i)
    {
        printf("%s", strNumbers[i]);
    }
    printf("\n");

    for (int i = 0; i < length; ++i)
    {
        delete[] strNumbers[i];
        cout << i << endl;
    }
    delete[] strNumbers;
}
int main()
{
    int list529[] = { 3, 32, 321 };
    PrintMinNumber(list529, 3);
    return 0;
}