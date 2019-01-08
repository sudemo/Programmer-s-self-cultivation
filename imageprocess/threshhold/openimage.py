# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/8 10:50
Software: PyCharm Community Edition
'''
import cv2
from matplotlib import pyplot as plt
import numpy as np
from PIL import Image
img=Image.open('d:/lena.jpg') # 加载图像
# img.show() # pil的显示方法 调用系统的图片浏览器 使用open打开，使用show显示图片

plt.figure("lena")
plt.imshow(img) #pyplot的显示方法，调用python自带方法打开图片
plt.show(img)
img.save('d:/lenna.jpg') #pil 自带方法有，save,show,open,y用pil打开并保存，用plt显示属性等