# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/8 13:28
Software: PyCharm Community Edition
'''
import cv2
import matplotlib.pyplot as plt
img= plt.imread('d:/lena.jpg')
plt.figure("thresh")
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
# ret1, th1 = cv2.threshold(gray, 127, 255, cv2.THRESH_BINARY|cv2.THRESH_OTSU)
ret1, th1 = cv2.threshold(gray,  0,255, cv2.THRESH_OTSU)  #方法选择为THRESH_OTSU

# plt.imshow(th1,'gray')
# plt.imshow(th1,'spring')
plt.imshow(th1,'autumn')
"""
关于imshow()
其中，X变量存储图像，可以是浮点型数组、unit8数组以及PIL图像，如果其为数组，则需满足一下形状：
    (1) M*N      此时数组必须为浮点型，其中值为该坐标的灰度；
    (2) M*N*3  RGB（浮点型或者unit8类型）
    (3) M*N*4  RGBA（浮点型或者unit8类型）


"""
plt.show()