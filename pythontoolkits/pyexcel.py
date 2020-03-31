'''
# @Time    : 2020/3/12 9:14
# @Author  : Neo
# @File    : pyexcel.py
'''
import xlwings as xw;
import time
import datetime
# xlapp = xw.App(visible=True , add_book=False)
# filepath = "D:\项目资料\example.xlsx"
# def openexcel(filename):
filepath = "cupWeight.csv"  # 与程序同目录下
filepath2 = "称重数据汇总（含模板）-C1.xlsx"
# 打开一个表格
try:
    # 实例化一个book
    cupweight_wb = xw.App(visible=False, add_book=False).books.open(filepath)
    summary_wb = xw.App(visible=False, add_book=False).books.open(filepath2)
    # cupweight_wb = xlapp.books.open(filepath)
    # summary_wb = xlapp.books.open(filepath2)
except:

    print("找不到名为cupWeight/称重数据汇总（含模板）-C1 的文件")
# 显示打开的表格名字
# print(xlapp.books.active)


def creatnewsheet(sheet_name):
    # 创建新的sheet
    # c_alphabeta_list = [chr(i) for i in range(65, 65 + 26)]
    # l_alphabeta_list = [chr(i) for i in range(97, 97 + 26)]
    key =input("是否需要创建新的sheet y/n?")

    print(key)
    # time.sleep(0.1)

    if key == "y":

        try:
            ws = summary_wb.sheets.add()  # 新增数据表
            ws.name = sheet_name
            ws = summary_wb.sheets[sheet_name]
            # rg = ws.range('B1')
            # # rg.value = l_alphabeta_list
            # rg = ws.range('A2')
            # rg.value = [[chr(i)] for i in range(97, 97 + 26)]
            summary_wb.save()
            # summary_wb.close()
        except():
            print("添加sheet失败")
            summary_wb.close()
            cupweight_wb.close()
    else:
        print("cancle")
        pass

def copytonewsheet(arg):
    # raw_cup_data = cupweight_wb.Range ("A1:B3")
    # raw_sum_data = summary_wb.sheets[0]
    # raw_sum_data.value =

    '''raw_cup_data =cupweight_wb.sheets['cupWeight']  # 要复制的sheet
    # 重点是copy
    raw_cup_data.api.Copy(Before=raw_cup_data.api)
    raw_sum_data = summary_wb.sheets[arg]
    raw_sum_data.value = raw_cup_data
    # print(raw_cup_data,raw_sum_data)'''

    last_row_index = cupweight_wb.sheet[0].Range('A2').expand('table').last_cell.row  # 这表格最后一列

    print(last_row_index)

    rg = "A2:E" + str(last_row_index)  # 范围

    print(rg)

    work_detail = xw.Range(rg).value  # 选中范围的值



if __name__ == '__main__':
    print("starting")
    sheetname = datetime.datetime.now().strftime('%m-%d')
    '''
    # print(sheetname)
    creatnewsheet(sheetname)
    # raw_sum_data = summary_wb.sheets[sheetname]
    copytonewsheet(sheetname)
    summary_wb.save()'''


    try:
        cup_sheet = cupweight_wb.sheets[0]
        summary_wb.sheets.add(sheetname)
        sum_sheet = summary_wb.sheets[sheetname]
        # fuzhi
        #  cup_num
        line =cup_sheet.used_range.last_cell.row
        index = cup_sheet.range('A2').expand('down').value  # 整列
        # print(index)
        c = 1
        ss =[]
        for i in index:
            c = c + 1
            if i == 1 and c < 21:

                ss.append( cup_sheet.range('b'+str(c)+':'+'d'+str(c)).value)  # 提取1号空杯
                print(c)
        sum_sheet.range('v2:x2').options(transpose=True).value = ss


        # last_row_index = cupweight_wb.sheet[0].Range('A2').expand('table').last_cell.row  # 这表格最后一列
    except  Exception as ex:
        print("first error",ex)
        cupweight_wb.close()
        summary_wb.close()



    try:
        summary_wb.save()
        cupweight_wb.close()
        summary_wb.close()
    except Exception as es:
        print('last',es)
        cupweight_wb.close()
        summary_wb.close()


