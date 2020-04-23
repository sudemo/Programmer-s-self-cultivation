'''
# @Time    : 2020/4/22 10:29
# @Author  : Neo
# @File    : 模板匹配.py
'''
import cv2
from matplotlib import pyplot as plt
import os

path1 = 'd:/pic/lena.jpg'
path2 = 'd:/pic/4lena.png'
if not os.path.exists(path1):
    print('file not exists')
    exit(2)
src = cv2.imread(path2, 0)
temp = cv2.imread(path1, 0)

w,h =temp.shape[::-1]

res  = cv2.matchTemplate(src,temp,cv2.TM_CCOEFF)
min_val ,max_val,min_loc,max_loc = cv2.minMaxLoc(res)
plt.subplot(131)
plt.plot(res)
plt.subplot(132)
plt.imshow(res,cmap='gray')
plt.subplot(133)
plt.imshow(src,cmap='gray')
plt.show()