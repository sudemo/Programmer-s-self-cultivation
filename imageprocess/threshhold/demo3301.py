'''
@author: neo
@file: demo3301.py
@time: 2019/4/27 16:48
'''

import cv2
def fun1(arg):
    ad = "sd"
    arg = eval(arg)

    # print(a)
    def fun2():
        if arg is not str:
            for i in range (arg):
                s = i*i
                s += s
            return s
        else:
            print("a")
    def fun3():

        if arg:
            print('2')
        else:
            print(1)



        # return 1


        # if arg is str:
        #     ss =""
        #     # for i in arg:
        #     #     ss += i
        #     #
        #     return ss
        # else:
        #     break
            # print("error")


    return fun3()

def  add_end(L=[]):
    L.append('END') # 这里已经添加了一个END
    print(L)
    return L
def  add_end2(L=[]):
    if L is not None:
        L = []
    L.append('END') # 这里已经添加了一个END
    # print(L)
    # return L

if __name__ == "__main__":
    # print(fun1("ad"))
    # print( add_end())
    # print(add_end())
    # print(add_end2())
    # add_end2()
    # print(help(add_end().__doc__))
    # img = cv2.imread('c:\\用户\\Neo\\OneDrive\\图片\\11.bmp', 0)
    img=cv2.imread('11.bmp',0)

    if img is not None:
        # cv2.imshow('0',img)
        w,h = img.shape[:2]
        shrink=cv2.resize(img, (int(w*0.3), int(h*0.3)), interpolation=cv2.INTER_CUBIC)
        cv2.imshow('11',shrink)
        cv2.waitKey(0)
        exit(0)
    exit(2)