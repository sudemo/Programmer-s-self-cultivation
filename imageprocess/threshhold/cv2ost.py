
# -*- coding: UTF-8 -*-
''''
author:neo
Created on: 2019/1/8 9:51
Software: PyCharm Community Edition
'''

# import cv2
import cv2
import PIL
from PIL import Image
import matplotlib.pyplot as plt

# s = 'd:/lena.jpg'
# img = Image.open(s)
# # img = img.convert('L')
# gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
# plt.imshow(gray, "gray")
# img.show()

path = "D:/pic/lena.jpg"
image = cv2.imread(path)  # 小计
print(image.size)
# img = Image.open(path)
cv2.imshow('origin',image)
cv2.waitKey(0)
# gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
# print(type(gray))
# plt.imshow(gray)


# plt.subplot(131), plt.imshow(image, "gray")
# plt.title("source image"), plt.xticks([]), plt.yticks([])
# plt.subplot(132), plt.hist(image.ravel(), 256)
# plt.title("Histogram"), plt.xticks([]), plt.yticks([])
ret1, th1 = cv2.threshold(image, 0, 255, cv2.THRESH_OTSU)  #方法选择为THRESH_OTSU
# ret2, th2 = cv2.threshold(gray, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)

print(ret1,th1)
cv2.imshow('th2',th1)
cv2.waitKey(0)
# plt.figure()
# plt.subplot(133),
# plt.imshow(ret1, "gray")
# plt.title("OTSU,threshold is " + str(ret1)), plt.xticks([]), plt.yticks([])
# image.show()


# re,th = cv2.threshold(gray,255, cv2.THRESH_OTSU)
