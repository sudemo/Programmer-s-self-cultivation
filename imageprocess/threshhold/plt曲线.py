# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/8 11:19
Software: PyCharm Community Edition
'''
from matplotlib import pyplot as plt
import numpy as np

# fig1 = plt.figure('绘图')#每个figure是不同的窗口 图片
fig1 = plt.figure(num='plt画图实列', figsize=(12, 8), dpi=75, facecolor='#ffffff', edgecolor='#ffffFF')
plt.subplot(231)
plt.plot([0,1],[1,0]) #连接（0，1），（1，0）
plt.title('line')
plt.xlabel('x值')
plt.ylabel('y')



# fig2 = plt.figure('折线')
x = [1,2,3,4,5]
y = [1,3,4.3,5.1,9]
plt.subplot(232)
plt.plot(x,y)

#
plt.subplot(233)
plt.scatter(x,y)
plt.title('散点')

plt.subplot(234)
# plt.pie(y)
plt.pie(x)


plt.subplot(235)
plt.bar(x,y)
plt.title('bar条形图')



#2d
d = 3
p = q =np.arange(-3.0,3.0,d)
P,Q =np.meshgrid(p,q)
R = P**2 + Q**2
plt.subplot(236)
plt.contour(P,Q,R)
plt.colorbar()
plt.title('contour')

"""
尽管函数式绘图很便利，但利用函数式编程会有以下缺点：

1) 增加了一层“函数”调用，降低了效率。

2) 隶属关系被函数掩盖。整个matplotlib包是由一系列有组织有隶属关系的对象构成的。函数掩盖了原有的隶属关系，将事情变得复杂。

3) 细节被函数掩盖。pyplot并不能完全复制对象体系的所有功能，图像的许多细节调中最终还要回到对象。

4) 每件事情都可以有至少两种方式完成，用户很容易混淆。


而对于开发者来说，了解对象是参与到Matplotlib项目的第一步。
先来看什么是Figure和Axes对象。在matplotlib中，整个图像为一个Figure对象。
在Figure对象中可以包含一个，或者多个Axes对象。
每个Axes对象都是一个拥有自己坐标系统的绘图区域。其逻辑关系如下：
"""

plt.show()

"""
然而，像素坐标不容易被纳入绘图逻辑。相同的程序，在不同的显示器上就要调整像素值，
以保证图像不变形。所以一般情况下，还会有图像坐标和数据坐标。

图像坐标将一张图的左下角视为原点，将图像的x方向和y方向总长度都看做1。
x方向的0.2就是指20%的图像在x方向的总长，y方向0.8的长度指80%的y方向总长。
(0.5, 0.5)是图像的中点，(1, 1)指图像的右上角。
"""