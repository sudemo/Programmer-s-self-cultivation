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
        # line =cup_sheet.used_range.last_cell.row
        head = ['序号','空杯1',	'满杯1','净重1',	'空杯2','满杯2',	'净重2','空杯3',	'满杯3',
                '净重3','空杯4', '满杯4','净重4','空杯5','满杯5','净重5',	'空杯6','满杯6',	'净重6']
        sum_sheet.range('u1:am1').value = head

        index = cup_sheet.range('A2').expand('down').value  # 整列
        # print(index)
        c = 1
        s1 = []; s11 = []; s111 = []  # 1满杯 11空杯 111净重
        s2 = []; s22 = []; s222 = []
        s3 = []; s33 = []; s333 = []
        s4 = []; s44 = []; s444 = []
        s5 = []; s55 = []; s555 = []
        s6 = []; s66 = []; s666 = []
        for i in index:
            c = c + 1
            # if i == 1 and c < 21:
            if i == 1:
                s1.insert(len(s1),cup_sheet.range('b'+str(c)).value)  # 提取1号空杯
                # print(s1)
                s11.insert(len(s11),cup_sheet.range('c'+str(c)).value)  # 提取号满杯
                s111.insert(len(s111),cup_sheet.range('d'+str(c)).value)  # 提取1号净重
                # print(c)
            if i == 2:
                s2.insert(len(s2), cup_sheet.range('b' + str(c)).value)
                # print(s1)
                s22.insert(len(s22), cup_sheet.range('c' + str(c)).value)
                s222.insert(len(s222), cup_sheet.range('d' + str(c)).value)
            if i == 3:
                s3.insert(len(s3), cup_sheet.range('b' + str(c)).value)
                s33.insert(len(s33), cup_sheet.range('c' + str(c)).value)
                s333.insert(len(s333), cup_sheet.range('d' + str(c)).value)
            if i == 4:
                s4.insert(len(s4), cup_sheet.range('b' + str(c)).value)
                # print(s1)
                s44.insert(len(s44), cup_sheet.range('c' + str(c)).value)
                s444.insert(len(s444), cup_sheet.range('d' + str(c)).value)
            if i == 5:
                s5.insert(len(s5), cup_sheet.range('b' + str(c)).value)
                # print(s1)
                s55.insert(len(s55), cup_sheet.range('c' + str(c)).value)
                s555.insert(len(s555), cup_sheet.range('d' + str(c)).value)
            if i == 6:
                s6.insert(len(s6), cup_sheet.range('b' + str(c)).value)
                # print(i)
                s66.insert(len(s66), cup_sheet.range('c' + str(c)).value)
                s666.insert(len(s666), cup_sheet.range('d' + str(c)).value)

        sum_sheet.range('v2').options(transpose=True).value = s1
        sum_sheet.range('w2').options(transpose=True).value = s11
        sum_sheet.range('x2').options(transpose=True).value = s111

        sum_sheet.range('y2').options(transpose=True).value = s2
        sum_sheet.range('z2').options(transpose=True).value = s22
        sum_sheet.range('AA2').options(transpose=True).value = s222

        sum_sheet.range('AB2').options(transpose=True).value = s3
        sum_sheet.range('AC2').options(transpose=True).value = s33
        sum_sheet.range('AD2').options(transpose=True).value = s333

        sum_sheet.range('AE2').options(transpose=True).value = s4
        sum_sheet.range('AF2').options(transpose=True).value = s44
        sum_sheet.range('AG2').options(transpose=True).value = s444

        sum_sheet.range('AH2').options(transpose=True).value = s5
        sum_sheet.range('AI2').options(transpose=True).value = s55
        sum_sheet.range('AJ2').options(transpose=True).value = s555

        sum_sheet.range('AK2').options(transpose=True).value = s6
        sum_sheet.range('AL2').options(transpose=True).value = s66
        sum_sheet.range('AM2').options(transpose=True).value = s666


        print('ok')

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


