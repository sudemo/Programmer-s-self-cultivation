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
lines1 = cv2.HoughLines(edge,1,np.pi/180, 118)  # mat 类型
print(type(lines1))

result = cut_img.copy()
# 表示能组成一条直线的最少点的数量，点数量不足的直线将被抛弃
minLineLength = 10  # height/32
# 表示能被认为在一条直线上的亮点的最大距离
maxLineGap = 10  # height/40
lines = cv2.HoughLinesP(edge, 1, np.pi / 180, 80, minLineLength, maxLineGap)

for x1, y1, x2, y2 in lines[0]:
    cv2.line(result, (x1, y1), (x2, y2), (0, 1, 255), 2)   # 颜色空间顺序为 BGR
# 新建一个figure 对象
# plt.figure()
# plt.show()
cv2.imshow('result', result)
cv2.waitKey(0)
cv2.destroyAllWindows()

