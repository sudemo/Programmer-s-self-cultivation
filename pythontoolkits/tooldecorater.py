'''
# @Time    : 2020/3/13 11:50
# @Author  : Neo
# @File    : tooldecorater.py
'''
# print_msg是外围函数
def print_msg():
    msg = "I'm closure11"

    # printer是嵌套函数
    def printer():
        print(msg)
    # 区分 return printer()
    return printer  # 延时调用printer()函数，并没有立刻执行其内容


# 这里获得的就是一个闭包
closure = print_msg()
# 输出 I'm closure
closure()