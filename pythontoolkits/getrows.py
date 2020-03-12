'''
# @Time    : 2020/3/12 15:17
# @Author  : Neo
# @File    : getrows.py
'''
import xlwings as xw

# myapp = xw.App(visible=False, add_book=False)
# wb=xw.books.open(r'D:\项目资料\example.xlsx') #两种打开表的方式
wb = xw.Book(r'D:\项目资料\example.xlsx')


sht = wb.sheets[1]
list23= sht.range('j2:j4').value
print(list23,type(list23))
list2 = [11,21,31]
# info = sht.used_range
# sht.range('j2').options(transpose=True).value = list2


