'''
# @Time    : 2020/3/13 13:25
# @Author  : Neo
# @File    : decoraterdemo2.py
'''
import functools


def log(func):
    @functools.wraps(func)
    def wrapper(*args, **kwargs):
        print('call %s():' % func.__name__)
        print('args = {}'.format(*args))
        return func(*args, **kwargs)

    return wrapper


@log
def test(p):
    print(test.__name__ + " param: " + p)

def mycalc(a1,b1):

    def myadd():
        # print("this is debug")
        c= a1+b1
        return c
    return myadd()

'''
print(2+mycalc(12,1))
print(type(mycalc(11,2)))
print(mycalc(2, 3)) #mycalc()有返回值，但是不会直接显示
'''

def make_filter(keep):
    def the_filter(file_name):
        file = open(file_name)
        lines = file.readlines()
        file.close()
        filter_doc = [i for i in lines if keep in i]
        return filter_doc
    return the_filter

def foo():
    a = 1
    def bar():
        # 声明a不是局部变量，先找外部变量
        nonlocal a
        a += 1
        return a
    return bar

c= foo()
# print(c())
# print(c())
# print(c())


def count():
    fs = []
    for i in range(1, 4):
        def f():
             return i*i
        fs.append(f)
    return fs



def count1():
    def f(arg ):
        def g():
            return 3.14*arg*arg
        return g
    fs = []
    for i in range(1, 4):
        fs.append(f(i)) # f(i)立刻被执行，因此i的当前值被传入f()
    print(type(fs))
    return fs #返回的是数组，其值为函数，函数数组

f1, f2, f3 = count1()
print(f2(),type(f1))