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


print(2+mycalc(12,1))
print(type(mycalc(11,2)))
print(mycalc(2, 3)) #mycalc()有返回值，但是不会直接显示
