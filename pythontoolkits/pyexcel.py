'''
# @Time    : 2020/3/12 9:14
# @Author  : Neo
# @File    : pyexcel.py
'''
import xlwings as xw;
import time

# import
app = xw.App(visible=True, add_book=False)

# myapp = xw.apps(visible=True, add_book=False)

filepath = "D:\项目资料\example.xlsx"
# 打开一个表格
wb = app.books.open(filepath)
# 显示打开的表格名字
print(app.books.active)

'''wb.save()
time.sleep(3)
app.quit()
'''
# wb.close()
sht = wb.sheets["Sheet1"]
# print(wb.sheets["Sheet1"].range("A1"))
# print(sht)
sht.range("A1").value="20191"
sht.range("j2").value=[1,2,222] # 写入数据

# 读取数据
v1=sht.range("A1").value

sht.range("A1:A3").value

sht.range("A1:B3").value

v2= xw.Range("A1").value
print(v1,v2)
