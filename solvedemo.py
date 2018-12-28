# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2018/12/28 17:11
Software: PyCharm Community Edition
'''
# import scipy
# import pillow
# from scipy.misc import imread,imsave
# from scipy
import imageio
import matplotlib.image as mpimg  # mpimg 用于读取图片
import matplotlib.pyplot as plt  # plt 用于显示图片
from PIL import Image  # PIL pakage name is Pillow

imag = Image.open('d:/2.jpg') #pil
im  =  imageio.imread('d:/2.jpg')
i = mpimg.imread('d:/2.jpg')
plt.imshow(i)
plt.show()
# imag.show() #显示图片
# ima = imag.convert('CMYK') # l,cmyk,p
# ima.show()