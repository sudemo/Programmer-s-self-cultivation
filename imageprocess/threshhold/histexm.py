# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/8 12:42
Software: PyCharm Community Edition
'''
"""
hist函数可以直接绘制直方图

调用方式：

n, bins, patches = plt.hist(arr, bins=10, normed=0, facecolor='black', 
edgecolor='black',alpha=1，histtype='bar')

hist的参数非常多，但常用的就这六个，只有第一个是必须的，后面四个可选
arr: 需要计算直方图的一维数组
bins: 直方图的柱数，可选项，默认为10
normed: 是否将得到的直方图向量归一化。默认为0
facecolor: 直方图颜色
edgecolor: 直方图边框颜色
alpha: 透明度

histtype: 直方图类型，‘bar’, ‘barstacked’, ‘step’, ‘stepfilled’
--------------------- 
返回值 ：
n: 直方图向量，是否归一化由参数normed设定
bins: 返回各个bin的区间范围 //直方图的个数
patches: 返回每个bin里面包含的数据，是一个list
"""
# from PIL import
# from matplotlib import sk
# from skimage import data
import cv2
import matplotlib.pyplot as plt
import numpy as np



img= plt.imread('d:/lena.jpg')
# img = plt.imread("D:/debug/python/pytorchdemo/pic/val/j2/17-45-02.bmp")
# plt.figure("hist")
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY) #灰度变换
# arr=img.flatten()
# n, bins, patches = plt.hist(arr, bins=156, normed=1,edgecolor='None',facecolor='red')
# plt.subplot()
plt.hist(img.ravel(), 256)
plt.show()


