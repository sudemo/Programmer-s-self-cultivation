'''
@author: neo
@file: siftdemo2.py
@time: 2019/4/20 17:05
'''
import cv2
import numpy as np

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
    # cv2.imshow('keypoints',img0)
    # cv2.imshow('keypoints2',img01)

    # BFMatcher
    bf = cv2.BFMatcher()
    matchers = bf.knnMatch(descriptors, descriptors2, k=2)

    # 相似列表
    Match = []
    for m, n in matchers:
        if m.distance < 0.50 * n.distance:
            Match.append(m)
    height1, width1 = img1.shape[:2]
    height2, width2 = img2.shape[:2]
    # 像素调整
    vis = np.zeros((max(height1, height2), width1 + width2, 3), np.uint8)
    vis[:height1, :width1] = img1
    vis[:height2, width1:width1 + width2] = img2
    # 相似度
    # v=cv2.waitKey(11000)
    # print(v)
    cv2.namedWindow("match", cv2.WINDOW_NORMAL)
    cv2.imshow("match", vis)
    cv2.waitKey(0)
else:
    print('no pic')