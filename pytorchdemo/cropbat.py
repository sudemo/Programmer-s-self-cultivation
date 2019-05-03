'''
@author: neo
@file: cropbat.py
@time: 2019/5/3 14:58
'''
import cv2
import os

# path = "D:/Gitrepository/github/Programmer's self-cultivation/pytorchdemo/pic/train/j1/"
# 此处有bug，无法区分' 导致地址错误
path = "d:/pic/j2"
lis = os.listdir(path)
for i in range(len(lis)):
    img_path = os.path.join(path,lis[i])
    img_path.split()
    # img_path = path + lis[i]
    if os.path.isfile(img_path):
        img = cv2.imread(img_path)
        print(img.shape)
        cropprd = img[200:1610,1500:1900]
        cv2.imshow('d:/pic/1.jpg', cropprd)
        cv2.waitKey(100)
        cv2.imwrite("d:/pic/j2" + str(i) + ".jpg",cropprd)
# cv2.imwrite(path,cropprd)
# cv2.waitKey()