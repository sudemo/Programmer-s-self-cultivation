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
# print (x)
# print(x+y)
#################广播#######################
"""
广播是一种强大的机制，它允许numpy在执行算术运算时
使用不同形状的数组。通常，我们有一个较小的数组和一个较大的数组，
我们希望多次使用较小的数组来对较大的数组执行一些操作
"""
import numpy as np

# We will add the vector v to each row of the matrix x,
# storing the result in the matrix y
x = np.array([[1,2,3], [4,5,6], [7,8,9], [10, 11, 12]])
v = np.array([1, 0, 1])
# y = np.empty_like(x)   # Create an empty matrix with the same shape as x,全为零
# print(y)
# # Add the vector v to each row of the matrix x with an explicit loop
# for i in range(4):
#     y[i, :] = x[i, :] + v

# Now y is the following
# [[ 2  2  4]
#  [ 5  5  7]
#  [ 8  8 10]
#  [11 11 13]]
# print(y)
# print(x)
y =x+v
print(y)

"""
将两个数组一起广播遵循以下规则：

如果数组不具有相同的秩，则将较低等级数组的形状添加1，直到两个形状具有相同的长度。
如果两个数组在维度上具有相同的大小，或者如果其中一个数组在该维度中的大小为1，则称这两个数组在维度上是兼容的。
如果数组在所有维度上兼容，则可以一起广播。
广播之后，每个阵列的行为就好像它的形状等于两个输入数组的形状的元素最大值。
在一个数组的大小为1且另一个数组的大小大于1的任何维度中，第一个数组的行为就像沿着该维度复制一样
"""