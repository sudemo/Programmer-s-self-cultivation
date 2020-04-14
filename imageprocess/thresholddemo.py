'''
# @Time    : 2020/4/10 10:05
# @Author  : Neo
# @File    : thresholddemo.py
'''
import cv2
import numpy as np
from matplotlib import pyplot as plt
path = "D:/pic/2.jpg"
# img = cv2.imread(path,0) # 直接转换为灰度图
img = cv2.imread(path,0)
print(img.shape)
img = cv2.medianBlur(img,5)
# gray = cv2.cvtColor(img,cv2.COLOR_BGR2GRAY)
# print(gray.shape)
hret = cv2.calcHist([img], [0], None, [255], [0, 256]) # 直方图统计
'''
img.ravel()将原图像的array数组转成一维的数组
hitsizes为直方图的灰度级数
ranges为灰度范围[0,255]
color是参数，需要使用color=''来指定颜色
'''
# plt.hist(img.ravel(), 256, [0, 256],color='r')
# plt.show()
# plt.plot(hret)
img1 = cv2.equalizeHist(img)

# img2 = cv2.calcHist([img1], [0], None, [255], [0, 256])
cv2.imshow('eq',img1)

cv2.waitKey(0)
# plt.plot(img)
#
# plt.show()
ret,th1 = cv2.threshold(img, 111, 255, cv2.THRESH_BINARY)  # thresh_binary 是x>T的赋值为maxval,x<t ==0
th2 = cv2.adaptiveThreshold(img,255,cv2.ADAPTIVE_THRESH_MEAN_C,\
            cv2.THRESH_BINARY,13,2)
th3 = cv2.adaptiveThreshold(img,255,cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY,15,2)
titles = ['Original Image', 'Global Thresholding (v = 127)',
            'Adaptive Mean Thresholding', 'Adaptive Gaussian Thresholding']
images = [img, th1, th2, th3]
for i in range(4):
    plt.subplot(2,2,i+1),plt.imshow(images[i],'gray')
    plt.title(titles[i])
    plt.xticks([]),plt.yticks([])
plt.show()
