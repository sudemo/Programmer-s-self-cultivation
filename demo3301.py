
# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2018/12/18 9:19
Software: PyCharm Community Edition
'''
import time


def IntToHex(nbits, number):
    '''
    a number is divided to two 2-byte hex
    '''
    return (((number + (1 << nbits)) % (1 << nbits) & 0xffff), ((number + (1 << nbits)) % (1 << nbits) >> 16))
# print IntToHex()
def degreeToPosition( degree=87, ratio=0.05, lead=10):

    degree = float(degree) / lead * 360
    return int(((degree * 10000) / 360) * ratio)

def re():
    arg = "ReadDI\r\n\r\nOK\r\n>"
    lst = arg.split('\r\n')
    if ((len(lst) == 5 or len(lst) == 4) and (lst[3] == "OK" or lst[2] == "OK")):
        return True, lst[2]
            # if lst[2] <> "OK" else lst[1]
    else:
        return False, arg



def analysisResultDI( result, index):
    try:
        num = -1
        binary = bin(int(result, 16))
        if len(binary) == 34:
            if index >= 24:
                num = (int(str(result), 16) >> index - 24 + 4 - 1) & 1
            else:
                num = (int(str(result), 16) >> index + 8 - 1) & 1
        else:
            num = (int(result, 16) >> index - 1) & 1
        return num
    except Exception, e:
        return str(e)


def split1(f=None):
    # a= filter(None, f)
    f=f.replace(" ","")
    n = f.split()
    # print n

def foo(s):
    n = int(s)
    assert n != 0, 'n is zero!'
    print (n)
#
# def main():
#     foo('0')

if __name__ == '__main__':
    foo(0)
    # l = list()
    # data =[0,1,11]
    # # if 1:
    #     if 2:
    #         while (data[0] != 9):
    #             # data = self.GetMoonsStatus(slave, 3)
    #             time.sleep(0.1)
    #             # print slave, ":", data
    #             if data[2] == 521:
    #                 break
    #             if data[2] == 18:
    #                 break
    #     return True
    # else:
    #     return False
    # a =8
    # if data[1]==1 :
    #
    #     if 1:
    #         while (a != 9):
    #             a = a+1
    #             time.sleep(0.1)
    #
    #             if data[2] == 521:
    #                 break
    #             if data[2] == 18:
    #                 break
    #     print 1
    #     # return True
    # else:
    #     # return False
    #     print 2
    # split1('[123, 12]')
    # pos1 = degreeToPosition(degree=131, ratio=1, lead=10)
    # pos = IntToHex(32, pos1)
    # print pos,list(pos)
    # print analysisResultDI('0x000e', 9)
    # a= degreeToPosition(750,0.05,10)
    # IntToHex(32,a)
    # b =degreeToPosition(0,1,10)
    # IntToHex(32,b)
    # ac = [1,2,3]
    # ac.set(1)
    # def extendList(val, list12=[]):
#     list12.append(val)
#     print list12
#     return list12
#
#
# list1 = extendList(10)
# list2 = extendList(123, [])
# list3 = extendList('a')
#
# print(list1)
# print(list2)
# print(list3)
# s= time.time()*1000
# def _Add(a):
#     print 'a',a
#     def add(b):
#         print 'b',b
#         return 'a+b', a + b
#
#     return add
# a=2
# # time.sleep(99.3)
# ad = _Add(a) # 是不是很像类的实例化
# # print(ad(1)) # out:2
# # print(ad(2)) # out:3
# # print(ad(3)) # out:4
# print ad(2)
#
#
# a = time.time()*1000
# time.sleep(1)
# print a
# print time.time()*1000 - a