
''''
author: neo
Created on: 2018/12/28 13:40
Software: PyCharm Community Edition
'''
import numpy as np
a = np.array([[11, 12, 13, 14, 15],
              [16, 17, 18, 19, 20],
              [21, 22, 23, 24, 25],
              [26, 27, 28, 29, 30],
              [31, 32, 33, 34, 35]])

# print(a[0][:5])
# print(a[2,4]) # 表示第二行第四列
# print(a[0, 1:4]) # >>>[12 13 14]
# print(a[1:4, 0]) # >>>[16 21 26]
# print(a[::2,::2]) # >>>[[11 13 15]
#                   #     [21 23 25]
#                   #     [31 33 35]]
# print(a[:, 1]) # >>>[12 17 22 27 32]
# print(a)
#
# print('type a:',type(a)) # >>><class 'numpy.ndarray'>
# print(a.dtype) # >>>int64
# print('size:',a.size) # >>>25
# print(a.shape) # >>>(5, 5)
# print(a.itemsize) # >>>8
# print(a.ndim) # >>>2
# print(a.nbytes) # >>>200
"""
item size属性是每个项占用的字节数。这个数组的数据类型是int 64，一个int 64中有64位，一个字节中有8位，除以64除以8，
你就可以得到它占用了多少字节，在本例中是8。
n dim 属性是数组的维数。这个有2个。例如，向量只有1。
n bytes 属性是数组中的所有数据消耗掉的字节数。你应该注意到，这并不计算数组的开销，因此数组占用的实际空间将稍微大一点。
"""

a1 = np.arange(25) # 从0 到25 5*5
a1 = a1.reshape((5, 5))

b = np.array([10, 62, 1, 14, 2, 56, 79, 2, 1, 45,
              4, 92, 5, 55, 63, 43, 35, 6, 53, 24,
              56, 3, 56, 44, 78])
# print (b)
# b = b.reshape((5,5))
# print (a1)
# print (b)
# # print(a1 + b)
# # print(a1 - b)
# # print(a1 * b)
# # print(a1 / b)
# # print(a1 ** 2)
# # print(a1 < b)
# # print(a1 > b)
# print (a1.dot(b))
# print(type(a1.dot(b))) # numpy.ndarray
# # 它将像sum()这样的每个元素相加，但是它首先将第一个元素和第二个元素相加，
# # 并将计算结果存储在一个列表中，然后将该结果添加到第三个元素中，然后再将该结果存储在一个列表中。
# # 这将对数组中的所有元素执行此操作，并返回作为列表的数组之和的运行总数。
# print(a1.cumsum()) # >>>[ 0  1  3  6 10 15 21 28 36 45]
################缺省索引#######################
#不完全索引是从多维数组的第一个维度获取索引或切片的一种方便方法
# a2 = np.arange(0, 100, 10) #起始终点，步长
# b2 = a2[:5]
# c2 = a2[a2 >= 50]
# print(a2)
# print('b2:',b2) # >>>[ 0 10 20 30 40]
# print('c2:',c2) # >>>[50 60 70 80 90]

##############where###########
# where() 函数是另外一个可以根据条件返回数组的索引的函数方法。
# 只需要把条件传递给它，它就会返回一个使得条件为真的元素的列表
# a3 = np.arange(1,100,10)
# b3 = np.where(a3 < 50)
# c3 = np.where(a3>60)[0]
# print('a3:',a3)
# print('b3:',b3)
# print('c3:',c3)
# ########bool masking##############
import matplotlib.pyplot as plt
a4 = np.linspace(0,2*np.pi) # a4取值范围是0-2Π，选取样本点数默认为50个，
# Number of samples to generate. Default is 50.
# Must be non-negative.
# 默认50，生成start和stop之间50个等差间隔的元素
# a4 = 1
b4 = np.cos(a4)
c4 = np.cos(a4,b4)
# plt.plot(a4,b4)
plt.plot(b4)
# plt.plot(c4)
# mask = b >=                                                                                           0
# plt.plot(a4[mask],b4[mask],'bool'
# plt.plot
plt.show()


