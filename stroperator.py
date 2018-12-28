# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2018/12/28 16:02
Software: PyCharm Community Edition
'''
import numpy as np
a = 'hello nerd           '
# print(a.capitalize())
# print(a.upper())
# print(a.rjust(4))
# print(a.replace('l','p'))
# print(a.strip())
# print(a.strip('d'))

animals = ['cat', 'dog', 'monkey']
# for idx, animal in enumerate(animals):
    # print('##$%d: %s' % (idx + 1, animal))
d = {(x-1, x + 1): x for x in range(10)}
# print(d)
# t = (4,6)
# print(d[t]) #可以用来反向求值
# f= np.eye(4)  # identity matrix 单位矩阵
# print (f)
x = np.array([[1,2],[3,4]])
y = np.array([[5,6],[7,8]])
print (x)
print(x+y)