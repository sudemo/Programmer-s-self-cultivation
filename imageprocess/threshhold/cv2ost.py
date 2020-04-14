
# -*- coding: UTF-8 -*-
''''
author:neo
Created on: 2019/1/8 9:51
Software: PyCharm Community Edition
'''


import cv2
import PIL
from PIL import Image
import matplotlib.pyplot as plt
import  os
# s = 'd:/lena.jpg'
# img = Image.open(s)
# # img = img.convert('L')
# gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
# plt.imshow(gray, "gray")
# img.show()

path = "D:/pic/lenna.jpg"
if not os.path.exists(path):
    print('file not found')

image = cv2.imread(path)  # 小计 imread in bgr顺序，如果用plt.show显示，则会出现色差，变色

# print('长宽通道数', image.shape)   # (200, 200, 3)  长宽通道数，size 等于以上之积

# cv2.imshow('origin', image)
# cv2.waitKey(0)
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
cv2.imshow('gray,unfilter', gray)
# cv2.waitKey(0)


# plt.subplot(131), plt.imshow(image, "gray")
# plt.title("source image"), plt.xticks([]), plt.yticks([])
# plt.subplot(132), plt.hist(image.ravel(), 256)
# plt.title("Histogram"), plt.xticks([]), plt.yticks([])
# 双边滤波
# imgviewx = cv2.bilateralFilter(gray, 5, 250, 250)

# 中值滤波 ksize是奇数  # 3 的时候比较好，大于5后轮廓开始模糊 椒盐噪声有很好的去燥效果
# imgviewx = cv2.medianBlur(gray,3)
# 高斯滤波 ksize是tuple
imgviewx = cv2.GaussianBlur(gray,(3,3),1)
# 均值滤波 去随机噪声有很好的去燥效果
# imgviewx = cv2.blur(gray,(5,5))
cv2.imshow('filter',imgviewx)
# ret1, th1 = cv2.threshold(gray, 10, 200, cv2.THRESH_OTSU)  #方法选择为THRESH_OTSU
# ret2, th2 = cv2.threshold(imgviewx, 150, 255, cv2.THRESH_OTSU)
# ret2, th2 = cv2.threshold(imgviewx, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)

# 自适应阈值 只返回分割后的图片 最后两个参数是领域大下 和 减去多少
th2 = cv2.adaptiveThreshold(imgviewx,255,cv2.ADAPTIVE_THRESH_GAUSSIAN_C,cv2.THRESH_BINARY,231,1)
# th3 = cv2.adaptiveThreshold(gray,255,cv2.ADAPTIVE_THRESH_MEAN_C, cv2.THRESH_BINARY,11,2)


#显示文字
# 参数：图像，文字内容， 坐标( x , y ) ，字体，大小，颜色( B , G ,R )，字体厚度
# font = cv2.FONT_HERSHEY_PLAIN
# imgviewx = cv2.putText(imgviewx,"hello neo",(30, 100), font, 4, (112, 122, 123), 10)
print(th2)
cv2.imshow('th2',th2)
# cv2.imshow('th11',th1)
cv2.waitKey(0)
# plt.figure()
# plt.subplot(133),
# plt.imshow(ret1, "gray")
# plt.title("OTSU,threshold is " + str(ret1)), plt.xticks([]), plt.yticks([])
# image.show()


# re,th = cv2.threshold(gray,255, cv2.THRESH_OTSU)
