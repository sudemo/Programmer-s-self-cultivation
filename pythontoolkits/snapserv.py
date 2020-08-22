'''
# @Time    : 2020/7/9 20:10
# @Author  : Neo
# @File    : snapserv.py
'''
from tkinter import *
# import snap7
#
# serv = snap7.server.Server()
# serv.start()
# while(1):
#     pass
def helloop():
    print("hello")
root = Tk()  # 创建窗口对象的背景色
# 创建两个列表
li = ['C', 'python', 'php', 'html', 'SQL', 'java']
movie = ['CSS', 'jQuery', 'Bootstrap']
listb = Listbox(root)  # 创建两个列表组件
listb2 = Listbox(root)
btn = Button(root, width=9, text="open",command = helloop)
for item in li:  # 第一个小部件插入数据
    listb.insert(0, item)

for item in movie:  # 第二个小部件插入数据
    listb2.insert(0, item)
listb.grid(row=1,column=1)
listb2.grid(row=1,column=2)
btn.grid(row=3,column=1)
# listb.pack()  # 将小部件放置到主窗口中
# listb2.pack()



root.mainloop()