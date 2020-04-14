'''
# @Time    : 2020/4/14 17:00
# @Author  : Neo
# @File    : findlinedemo.py
'''

import cv2
import os
import numpy as np
import matplotlib.pyplot as plt

path = "D:/pic/lenna.jpg"
if not os.path.exists(path):
    print('file not found')
img = cv2.imread(path, 0)
cv2.imshow('original gray',img)
cv2.waitKey(0)
edge = cv2.Canny(img, 50, 150)
lines = cv2.HoughLines(edge,1,np.pi/180, 118)  # mat 类型
print(type(lines))
# cv2.imshow('1',lines)

# cv2.waitKey(0)
plt.imshow(lines)
plt.show()
