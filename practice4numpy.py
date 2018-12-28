
''''
author: zwzhang
Created on: 2018/12/28 13:40
Software: PyCharm Community Edition
'''
import numpy as np
a = np.array([[11, 12, 13, 14, 15],
              [16, 17, 18, 19, 20],
              [21, 22, 23, 24, 25],
              [26, 27, 28, 29, 30],
              [31, 32, 33, 34, 35]])

print(a[0][:5])
print(a[2,4]) # 表示第二行第四列
print(a[0, 1:4]) # >>>[12 13 14]
print(a[1:4, 0]) # >>>[16 21 26]
print(a[::2,::2]) # >>>[[11 13 15]
                  #     [21 23 25]
                  #     [31 33 35]]
print(a[:, 1]) # >>>[12 17 22 27 32]
print(a)

print('type a:',type(a)) # >>><class 'numpy.ndarray'>
print(a.dtype) # >>>int64
print('size:',a.size) # >>>25
print(a.shape) # >>>(5, 5)
print(a.itemsize) # >>>8
print(a.ndim) # >>>2
print(a.nbytes) # >>>200
"""
item size属性是每个项占用的字节数。这个数组的数据类型是int 64，一个int 64中有64位，一个字节中有8位，除以64除以8，
你就可以得到它占用了多少字节，在本例中是8。

n dim 属性是数组的维数。这个有2个。例如，向量只有1。

n bytes 属性是数组中的所有数据消耗掉的字节数。你应该注意到，这并不计算数组的开销，因此数组占用的实际空间将稍微大一点。
"""