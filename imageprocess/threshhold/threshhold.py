# -*- coding: UTF-8 -*-
''''
author:neo
Created on: 2019/1/3 11:50
Software: PyCharm Community Edition
'''
# 图片二值化
from PIL import Image

img = Image.open('C:/Users/zwzhang/Pictures/新建文件夹/1.png')

# 模式L”为灰色图像，它的每个像素用8个bit表示，0表示黑，255表示白，其他数字表示不同的灰度。
Img = img.convert('L')
Img.show()
# Img.save("d:/lena1.jpg")

# 自定义灰度界限，大于这个值为黑色，小于这个值为白色
threshold = 220

table = []
for i in range(256):
    if i < threshold:
        table.append(0)
    else:
        table.append(1)

# 图片二值化
photo = Img.point(table, '1')
photo.save("1.jpg")
photo.show()