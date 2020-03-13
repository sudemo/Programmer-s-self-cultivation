'''
# @Time    : 2020/3/13 13:40
# @Author  : Neo
# @File    : globallocal.py
'''
a_string = "This is a global variable"

def foo():
    a_string = "test" # 1
    print (locals())

'This is a global variable'

lst = []

def foo1():
    lst.append(233)
    s= 1
    print(globals())
    print (locals())
foo1() # 3
