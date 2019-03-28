'''
@author: neo
@file: ocrdemo3.py
@time: 2019/3/21 15:54
'''

import pytesseract
from PIL import Image
import cv2

# im = cv2.imread('452.jpg')
im =cv2.imread('1.bmp')
# im = cv2.Canny(im,0,250)
# im = cv2.cvtColor(im,cv2.COLOR_BGR2GRAY)
im1 = cv2.resize(im, (864, 648))
# im2 = cv2.bitwise_not(im1)
# b1 = cv2.Canny(im2,200,250)
cv2.imshow('1', im1)
cv2.waitKey()
# IM1, contours, hierarchy = cv2.findContours(b1,cv2.RECURS_FILTER,cv2.CHAIN_APPROX_SIMPLE)
# cv2.imshow('2', hierarchy)
# cv2.waitKey()


media = cv2.medianBlur(im,3)
gray=cv2.cvtColor(media,cv2.COLOR_BGR2GRAY)
ret,th1 = cv2.threshold(gray,220,255,cv2.THRESH_BINARY)
# # im = cv2.gray
# # ret,im_fixed=cv2.threshold(gray,50,255,cv2.THRESH_BINARY)
# # gray = im_fixed
# im1 = cv2.Canny(gray,200,250)
cv2.imshow('1',th1)
cv2.waitKey()
# cv2.imwrite('333.tif',th1)
print(pytesseract.image_to_string(th1,'eng1'))