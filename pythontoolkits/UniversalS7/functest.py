'''
# @Time    : 2020/8/21 9:06
# @Author  : Neo
# @File    : functest.py
'''
import struct


def make_function(arg1,arg2):
    def sub_func(arg3):
        p1 = arg1
        p2 = arg2
        print("arg3 is ",arg3)
    return sub_func # 返回了一个函数

f= make_function(12,1)
# print(f)  #<function make_function.<locals>.sub_func at 0x000001DBC0363828>
# print(f(19))
# f(12)

data = '16'
print(int("12"))
d = int(data,16)
# ss = int(d, 10)
ar_data = bytearray()   # bytearray(n) 初始化一个这么大的数组
ss = struct.pack('!HH', int(data),12)  # 大端
print(ss)
print(int(ss.hex(), 16))
# print(ar_data)