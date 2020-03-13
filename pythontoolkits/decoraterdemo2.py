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


test("I'm a param")