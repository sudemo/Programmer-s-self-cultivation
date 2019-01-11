# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/10 16:12
Software: PyCharm Community Edition
'''
import pandas as pd
from pandas import DataFrame
from matplotlib import pyplot as plt
from sklearn.model_selection import train_test_split
import numpy

X = [[0.0888, 0.5885],
     [0.1399, 0.8291],
     [0.0747, 0.4974],
     [0.0983, 0.5772],
     [0.1276, 0.5703],
     [0.1671, 0.5835],
     [0.1906, 0.5276],
     [0.1061, 0.5523],
     [0.2446, 0.4007],
     [0.1670, 0.4770],
     [0.2485, 0.4313],
     [0.1227, 0.4909],
     [0.1240, 0.5668],
     [0.1461, 0.5113],
     [0.2315, 0.3788],
     [0.0494, 0.5590],
     [0.1107, 0.4799],
     [0.2521, 0.5735],
     [0.1007, 0.6318],
     [0.1067, 0.4326],
     [0.1956, 0.4280]
     ]
x = DataFrame(X)
# print(type(X),type(x))
# print(x.iloc[0:2])
# print(x.iloc[:2,[0,1]])
# print(x.iloc[:,:]) #取所有行和列
# print(x.iloc[:,[1]])# 取所有行，1列
# 绘制散点图
plt.scatter(x.iloc[:,[0]],x.iloc[:,1])
plt.xlabel("x account")#设置X轴标签
plt.ylabel("y amount")#设置Y轴标签
# plt.show()
rdf = x.corr()
examDf = x
# print(rdf) #0.3-0.6 中等相关
# 拆分训练集和测试集（train_test_split是存在与sklearn中的函数）
X_train, X_test, Y_train, Y_test = train_test_split(examDf.iloc[:,0], examDf.iloc[:,1], train_size=0.5)
# train为训练数据,test为测试数据,examDf为源数据,train_size 规定了训练数据的占比

print("自变量---源数据:", examDf.iloc[:,0].shape, "；  训练集:", X_train.shape, "；  测试集:", X_test.shape)
print("因变量---源数据:", examDf.iloc[:,1].shape, "；  训练集:", Y_train.shape, "；  测试集:", Y_test.shape)

# 散点图
plt.scatter(X_train, Y_train, color="darkgreen", label="train data")  # 训练集为深绿色点
plt.scatter(X_test, Y_test, color="red", label="test data")  # 测试集为红色点

# 添加标签
plt.legend(loc=2)  # 图标位于左上角，即第2象限，类似的，1为右上角，3为左下角，4为右下角
plt.xlabel("The Connection amount of the average account")  # 添加 X 轴名称
plt.ylabel("The ratio of average return amount")  # 添加 Y 轴名称
plt.show()  # 显示散点图