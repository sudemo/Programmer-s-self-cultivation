'''
# @Time    : 2020/8/25 13:21
# @Author  : Neo
# @File    : demo1.py
'''

import os
import sys

def Add(a,b):
    return a+b

if __name__=='__main__':
    try:
        #代码行
        a = int(sys.argv[1])
        b = int(sys.argv[2])
        c = Add(a,b)
    except Exception as err:
        #捕捉异常
        str1 = 'default:' + str(err)
    else:
        # 代码运行正常
        str1 = c
    print(str1)