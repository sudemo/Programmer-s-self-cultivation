'''
@author: neo
@file: siftdemo.py
@time: 2019/3/30 11:11
'''

import cv2
import numpy as np

imgname1 ="d:/lena.jpg"
imgname2 = "D:/debug/python/pytorchdemo/pic/train/j2/17-45-02.bmp"


im = cv2.imread(imgname2)
if im is not None:
    im = cv2.resize(im,(768,512))
    # cv2.imshow('0',im)
    # cv2.waitKey()
    gray=im
    # gray = cv2.cvtColor(im, cv2.COLOR_BGR2GRAY)
    #opencv 读取图片默认BGR
    # cv2.imshow('1',gray)
    # cv2.waitKey(0)
    sift = cv2.xfeatures2d.SIFT_create()
    keypoints,descriptors = sift.detectAndCompute(gray,None)
    img = cv2.drawKeypoints(gray,keypoints,im)
    cv2.imshow('keypoints',img)
    v=cv2.waitKey(11000)
    print(v)

else:
    print('no pic')