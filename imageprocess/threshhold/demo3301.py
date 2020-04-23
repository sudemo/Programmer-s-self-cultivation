'''
@author: neo
@file: demo3301.py
@time: 2019/4/27 16:48
'''


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
    print(add_end2())
    add_end2()
    # print(help(add_end().__doc__))