'''
@author: neo
@file: siftdemo2.py
@time: 2019/4/20 17:05
'''
import cv2

path1 = "D:/debug/python/pytorchdemo/pic/train/j1/18-55-34.bmp"
path2 = "D:/debug/python/pytorchdemo/pic/train/j2/17-45-02.bmp"
img1 = cv2.imread(path1)
img2 = cv2.imread(path2)

if img1 is not None:

    im = cv2.resize(img1,(768,512))
    im2 = cv2.resize(img2, (768, 512))
    # cv2.imshow('0',im)
    # cv2.waitKey()
    gray=im
    gray2 =im2
    # 创建识别器
    detector = cv2.xfeatures2d.SIFT_create(200)
    detector1 = cv2.xfeatures2d.SIFT_create(200)
    keypoints,descriptors = detector.detectAndCompute(gray,None)
    keypoints2, descriptors2 = detector.detectAndCompute(gray2, None)
    img0 = cv2.drawKeypoints(gray, keypoints, im)
    img01 = cv2.drawKeypoints(gray2, keypoints2, im2)
    cv2.imshow('keypoints',img0)
    cv2.imshow('keypoints2',img01)
    v=cv2.waitKey(11000)
    print(v)

else:
    print('no pic')