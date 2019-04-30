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

if __name__ == "__main__":
    print(fun1("ad"))