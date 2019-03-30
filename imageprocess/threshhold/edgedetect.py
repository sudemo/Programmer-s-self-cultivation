
'''
@author: neo
@file: edgedetect.py
@time: 2019/3/29 16:33
'''
import cv2
from matplotlib import pyplot as plt
import numpy as np


img1 = plt.imread("D:/debug/python/pytorchdemo/pic/val/j2/17-45-02.bmp")
img2 = plt.imread("D:/debug/python/pytorchdemo/pic/val/j1/18-57-23.bmp")
img = cv2.resize(img2,(768,512))
plt.hist(img.ravel(), 256)#huizhi直方图  plt.hist(src,pixels) 最大像素 分级
# plt.show()


def Gaussian_Blur(gray):
    # 高斯去噪
    blurred = cv2.GaussianBlur(gray, (9, 9), 0)


def Sobel_gradient(blurred):
    # 索比尔算子来计算x、y方向梯度
    gradX = cv2.Sobel(blurred, ddepth=cv2.CV_32F, dx=1, dy=0)
    gradY = cv2.Sobel(blurred, ddepth=cv2.CV_32F, dx=0, dy=1)

    gradient = cv2.subtract(gradX, gradY)
    gradient = cv2.convertScaleAbs(gradient)

    return gradX, gradY, gradient


def Thresh_and_blur(gradient):
    blurred = cv2.GaussianBlur(gradient, (3, 3), 0)
    (_, thresh) = cv2.threshold(blurred, 50, 155, cv2.THRESH_BINARY)

    return thresh


def image_morphology(thresh):
    # 建立一个椭圆核函数
    kernel = cv2.getStructuringElement(cv2.MORPH_ELLIPSE, (25, 25))
    # 执行图像形态学, 细节直接查文档，很简单
    closed = cv2.morphologyEx(thresh, cv2.MORPH_CLOSE, kernel)
    closed = cv2.erode(closed, None, iterations=4)
    closed = cv2.dilate(closed, None, iterations=4)

    return closed


def findcnts_and_box_point(closed):
    # 这里opencv3返回的是三个参数
    ( cnts, _) = cv2.findContours(closed.copy(),
                                    cv2.RETR_LIST,
                                    cv2.CHAIN_APPROX_SIMPLE)
    c = sorted(cnts, key=cv2.contourArea, reverse=True)[0]
    # compute the rotated bounding box of the largest contour
    rect = cv2.minAreaRect(c)
    box = np.int0(cv2.boxPoints(rect))

    return box


def drawcnts_and_cut(original_img, box):
    # 因为这个函数有极强的破坏性，所有需要在img.copy()上画
    # draw a bounding box arounded the detected barcode and display the image
    draw_img = cv2.drawContours(original_img.copy(), [box], -1, (0, 0, 255), 3)

    Xs = [i[0] for i in box]
    Ys = [i[1] for i in box]
    x1 = min(Xs)
    x2 = max(Xs)
    y1 = min(Ys)
    y2 = max(Ys)
    hight = y2 - y1
    width = x2 - x1
    crop_img = original_img[y1:y1 + hight, x1:x1 + width]

    return draw_img, crop_img


def walk():
    img_path = r'C:\Users\aixin\Desktop\chongzi.png'
    save_path = r'C:\Users\aixin\Desktop\chongzi_save.png'
    original_img, gray = get_image(img_path)
    blurred = Gaussian_Blur(gray)
    gradX, gradY, gradient = Sobel_gradient(blurred)
    thresh = Thresh_and_blur(gradient)
    closed = image_morphology(thresh)
    box = findcnts_and_box_point(closed)
    draw_img, crop_img = drawcnts_and_cut(original_img, box)


if __name__ == '__main__':
    # gray = Gaussian_Blur(img)
    # blurred = Gaussian_Blur(gray)
    gradX, gradY, gradient = Sobel_gradient(img)
    thresh = Thresh_and_blur(gradient)
    closed = image_morphology(thresh)
    box = findcnts_and_box_point(closed)
    draw_img, crop_img = drawcnts_and_cut(img, box)

    featureSum =0
    # detector = cv2.xfeatures2d.SIFT_create()
    # detector = cv2.xfeatures2d.SURF_create()
    # 找到关键点
    # kps, des = detector.detectAndCompute(thresh, None)
    # 绘制关键点
    # imag = cv2.drawKeypoints(thresh, kps, img)

    # 将特征点保存
    # np.savetxt(outputImgPath, des, fmt='%.2f')
    # featureSum += len(kps)
    # cv2.imshow('result', imag)
    # print('kps:' + str(featureSum))

    # 暴力一点，把它们都显示出来看看

    # cv2.imshow('original_img', img)
    # cv2.imshow('blurred', blurred)
    # cv2.imshow('gradX', gradX)
    # cv2.imshow('gradY', gradY)
    cv2.imshow('sobelfinal', gradient)
    cv2.imshow('thresh', thresh)
    cv2.imshow('closed', closed)
    cv2.imshow('draw_img', draw_img)
    cv2.imshow('crop_img', crop_img)
    cv2.waitKey()
    # cv2.imwrite(save_path, crop_img)
