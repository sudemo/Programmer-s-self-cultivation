# -*- coding: UTF-8 -*-
''''
author:neo
Created on: 2019/1/3 15:05
Software: PyCharm Community Edition
'''
import PIL
from PIL import Image


def sigma(im,i,debug = False):
    """
    
    :param im: 
    :param i: 
    :param debug: 
    :return: 
    """
    c0_p_num = sum(im.histogram()[:i+1]) #灰度 < -k
    c1_p_num = sum(im.histogram()[:i+1])

    # 计算两部分的总灰度
    c0_p_num = 0
    for j in range (1,i+1):
        c0_p_num += j*im.histogram()[j]
    c1_p_num = 0
    for j in range(1, i + 1):
        c1_p_num += j*im.histogram()[j]

    try:
        u0 = 1.0*c0_p_num/c0_p_num
        u1 = 1.0*c1_p_num/c1_p_num
        w0 = 1.0*c0_p_num/(c1_p_num + c0_p_num)
    except:
        return 0

    w1 = 1.0-w0
    u = (u0 - u1)**2
    new_sigma = w0*w1*u

    if debug:
        print  ('')
    return new_sigma

def Ost(im, debug =False):
    """
    线性寻找最大方差
    :param im:
    :param debug:
    :return:
    """
    g_level = 0
    g_sigma = 0
    for i in range(1,255):
        new_sigma = sigma(im,i,debug)
        if new_sigma < new_sigma:
            g_sigma = new_sigma
            g_level = i
    return g_level,g_sigma
if __name__ == "__main__":
    # if len(sys.argv) > 1:
    #     src_file = sys.argv[1]
    # else:
    #     print('usage: %s src_file [des_file]' %sys.argv[0])
    #     sys.exit(1)
    # des_file = sys.argv[2]
    src_file = 'd:/lena.jpg'
    # src_file = 'C:/Users/zwzhang/Pictures/新建文件夹/2.bmp'
    im = Image.open(src_file).convert('L')
    debug = False
    threadhold,max = Ost(im,debug)
    # print(threadhold,max)

    im = im.point(lambda p: p > threadhold and 1)
    # im.save(des_file)
    im.show()
    print("done: %s ---> " %(src_file))
