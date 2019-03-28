'''
@author: neo
@file: ocrdemo1.py
@time: 2019/3/20 8:53
'''
import sys

import numpy as np
import cv2

im = cv2.imread('digit2.jpg')
# im = cv2.imread('452.jpg')
# cv2.imshow('1',im)
# cv2.waitKey()
# blur = cv2.GaussianBlur(im,(1,1),0)
# img = cv2.medianBlur(im,5)
# cv2.imshow('1',blur)
# cv2.waitKey()
# binaryImg = img
binaryImg = cv2.Canny(im,200,250)
cv2.imshow('2',binaryImg)
cv2.waitKey()
# gray = cv2.cvtColor(im,cv2.COLOR_BGR2GRAY)

# thresh = cv2.adaptiveThreshold(im,255,1,1,11,2)
# thresh =  cv2.adaptiveThreshold(im, 255, 1, 1, 11, 2)
# image = np.clip(im, 0, 255)# 归一化也行
# image1 = np.array(image,np.uint8)

# ret, th1 = cv2.threshold(img,127,255,cv2.THRESH_BINARY)
# print(ret,th1)
# thresh =th1

######### Now finding Contours #################

img,contours, hierarchy = cv2.findContours(binaryImg, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
print(contours)
thresh = img
samples = np.empty((0,100))
responses = []
keys = [i for i in range(48, 58)]

for cnt in contours:
    if cv2.contourArea(cnt) > 50:
        [x, y, w, h] = cv2.boundingRect(cnt)

        if h > 28:
            cv2.rectangle(im, (x, y), (x+w, y+h), (0, 0, 255), 2)
            roi = thresh[y:y+h, x:x+w]
            roismall = cv2.resize(roi, (10, 10))
            cv2.imshow('norm', im)
            key = cv2.waitKey(0)

            if key == 27:  # (escape to quit)
                sys.exit()
            elif key in keys:
                print(key)
                # responses.append(int(chr(key)))
                responses.append(int(chr(key)))
                sample = roismall.reshape((1,100))
                samples = np.append(samples,sample,0)
                print(responses, samples)
responses = np.array(responses,np.float32)
responses = responses.reshape((responses.size,1))
print ("training complete")

np.savetxt('generalsamples.data',samples)
np.savetxt('generalresponses.data',responses)