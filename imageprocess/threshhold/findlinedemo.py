'''
# @Time    : 2020/4/14 17:00
# @Author  : Neo
# @File    : findlinedemo.py
'''

import cv2
import os
import numpy as np
import matplotlib.pyplot as plt

path = "D:/pic/line.png"
if not os.path.exists(path):
    print('file not found')
img1 = cv2.imread(path)
img = cv2.cvtColor(img1,cv2.COLOR_BGR2GRAY)
cut_img =img1
# cv2.imshow('original gray',img)
# cv2.waitKey(0)
edge = cv2.Canny(img, 50, 150)
# lines1 = cv2.HoughLines(edge,1,np.pi/180, 118)  # mat 类型
# print(type(lines1))

result = cut_img.copy()

# rho参数表示参数极径 r 以像素值为单位的分辨率，这里一般使用 1 像素。
# theta参数表示参数极角 \theta 以弧度为单位的分辨率，这里使用 1度。
# threshold 表示示检测一条直线所需最少的曲线交点
# 表示能组成一条直线的最少点的数量，点数量不足的直线将被抛弃
minLineLength = 5  # height/32
# 表示能被认为在一条直线上的亮点的最大距离
maxLineGap = 20  # height/40

lines = cv2.HoughLinesP(edge, 1, np.pi/2, 10,minLineLength, maxLineGap)
i = 0
for l in lines:
    for x1, y1, x2, y2 in lines[i]:
        cv2.line(result, (x1, y1), (x2, y2), (0, 1, 255), 1)   # 颜色空间顺序为 BGR
    i = i+1
# 新建一个figure 对象
# plt.figure()
# plt.show()
cv2.imshow('result', result)
cv2.waitKey(0)
cv2.destroyAllWindows()

