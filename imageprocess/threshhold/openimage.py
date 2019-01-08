# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/8 10:50
Software: PyCharm Community Edition
'''
'''
使用 matplotlib库集成好的函数去直接加载和显示图像
（来自matplotlib的image.imread 或 PIL的Image.open）效果更好
采用 matplotlib.image 读入图片数组
注意: 
这里读入的数组是 float32 型的，范围是 0-1;
PIL.Image 数据是 uinit8 型的，范围是0-255，所以要进行转换;
'''
import cv2
from matplotlib import pyplot as plt
from matplotlib import image
import numpy as np
from PIL import Image

img=Image.open('d:/lena.jpg') # 加载图像
print(type(img))
matimage = image.imread('d:/lena.jpg')
print(type(matimage))
plt.imshow(matimage)
plt.show()
# img.show() # pil的显示方法 调用系统的图片浏览器 使用open打开，使用show显示图片

plt.figure("lena")
# plt.imshow(img) #pyplot的显示方法，调用python自带方法打开图片
# plt.show(img)
# img.save('d:/lenna.jpg') #pil 自带方法有，save,show,open,y用pil打开并保存，用plt显示属性等
