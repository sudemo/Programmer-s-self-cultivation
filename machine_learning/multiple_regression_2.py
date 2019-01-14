# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/10 16:12
Software: PyCharm Community Edition
'''
import pandas as pd
from pandas import DataFrame,Series
from matplotlib import pyplot as plt
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
import numpy
import seaborn as sns


# import seaborn as sns
from sklearn.linear_model import LinearRegression

X = [[0.0888, 0.5885,2.1],
     [0.1399, 0.8291,2.71],
     [0.0747, 0.4974,2.61],
     [0.0983, 0.5772,2.1],
     [0.1276, 0.5703,2.41],
     [0.1671, 0.5835,2.1],
     [0.1906, 0.5276,2.31],
     [0.1061, 0.5523,2.81],
     [0.2446, 0.4007,2.1],
     [0.1670, 0.4770,2.31],
     [0.2485, 0.4313,2.31],
     [0.1227, 0.4909,2.1],
     [0.1240, 0.5668,2.15],
     [0.1461, 0.5113,2.3]

     ]
x = DataFrame(X)
# print(type(X),type(x))
# print(x.iloc[0:2])
# print(x.iloc[:2,[0,1]])
# print(x.iloc[:,:]) #取所有行和列
# print(x.iloc[:,[1]])# 取所有行，1列
# 绘制散点图
plt.scatter(x.iloc[:, [0]], x.iloc[:, 1])
plt.xlabel("x account")  # 设置X轴标签
plt.ylabel("y amount")  # 设置Y轴标签
# plt.show()
rdf = x.corr()
examDf = x
# print(rdf) #0.3-0.6 中等相关
# 拆分训练集和测试集（train_test_split是存在与sklearn中的函数）
X_train, X_test, Y_train, Y_test = train_test_split(examDf.iloc[:, :1], examDf.iloc[:, 1:2], train_size=0.5)
# train为训练数据,test为测试数据,examDf为源数据,train_size 规定了训练数据的占比

print("自变量---源数据:", examDf.iloc[:, 1].shape, "；  训练集:", X_train.shape, "；  测试集:", X_test.shape)
print("因变量---源数据:", examDf.iloc[:, 1:2].shape, "；  训练集:", Y_train.shape, "；  测试集:", Y_test.shape)

# 散点图
# plt.scatter(X_train, Y_train, color="darkgreen", label="train data")  # 训练集为深绿色点
# plt.scatter(X_test, Y_test, color="red", label="test data")  # 测试集为红色点

# 添加标签
# plt.legend(loc=2)  # 图标位于左上角，即第2象限，类似的，1为右上角，3为左下角，4为右下角
# plt.xlabel("The Connection amount of the average account")  # 添加 X 轴名称
# plt.ylabel("The ratio of average return amount")  # 添加 Y 轴名称
# plt.show()  # 显示散点图

model = LinearRegression()

# 线性回归训练
model.fit(X_train, Y_train)  # 调用线性回归包

a = model.intercept_  # 截距
b = model.coef_  # 回归系数

# 训练数据的预测值
y_train_pred = model.predict(X_train)
# 绘制最佳拟合线：标签用的是训练数据的预测值y_train_pred
plt.plot(X_train, y_train_pred, color='blue', linewidth=2, label="best line")

# 测试数据散点图
plt.scatter(X_train, Y_train, color='darkgreen', label="train data")
plt.scatter(X_test, Y_test, color='red', label="test data")

# 添加图标标签
plt.legend(loc=2)  # 图标位于左上角，即第2象限，类似的，1为右上角，3为左下角，4为右下角
plt.xlabel("The Connection amount of the average account")  # 添加 X 轴名称
plt.ylabel("The ratio of average return amount")  # 添加 Y 轴名称
# plt.show()  # 显示图像

print("拟合参数:截距", a, ",回归系数：", b)
# print("最佳拟合线: Y = ", round(a, 2), "+", round(b[0], 2), "* X")  # 显示线性方程，并限制参数的小数位为两位

# 数据检验（判断是否可以做线性回归）
# 多变量线性回归


# 读取文件
# datafile = u'E:\\pythondata\\dhdhdh.xlsx'  # 文件所在位置，u为防止路径中有中文名称，此处没有，可以省略
# data = pd.read_excel(datafile)  # datafile是excel文件，所以用read_excel,如果是csv文件则用read_csv
# examDf = DataFrame(data)

# 数据清洗,比如第一列有可能是日期，这样的话我们就只需要从第二列开始的数据，
# 这个情况下，把下面中括号中的0改为1就好，要哪些列取哪些列
new_examDf = examDf.ix[:, 0:]

# 检验数据
print(new_examDf.describe())  # 数据描述，会显示最值，平均数等信息，可以简单判断数据中是否有异常值
print(new_examDf[new_examDf.isnull() == True].count())  # 检验缺失值，若输出为0，说明该列没有缺失值

# 输出相关系数，判断是否值得做线性回归模型
print(new_examDf.corr())  # 0-0.3弱相关；0.3-0.6中相关；0.6-1强相关；

# 通过seaborn添加一条最佳拟合直线和95%的置信带，直观判断相关关系
sns.pairplot(x, examDf.iloc[:, :1], examDf.iloc[:, 1:2], size=7, aspect=0.8,kind='reg')
plt.show()
l
