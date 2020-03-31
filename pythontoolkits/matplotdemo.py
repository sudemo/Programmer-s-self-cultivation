'''
# @Time    : 2020/3/19 14:00
# @Author  : Neo
# @File    : matplotdemo.py
'''
from matplotlib import  pyplot as plt
import  numpy as np
# plt.switch_backend('agg')
'''
rng = np.random.RandomState(1)
x = 10 * rng.rand(50)
y = 2 * x - 5 + rng.randn(50)

print(plt.get_backend())
plt.scatter(x, y)
plt.show()'''
if __name__=='__main__':
    aa= []

    s11 = []; s111 = []; s111 = []
    s1=s2=s3=[]
    b=s1=[1,2,3]
    s1.insert(len(s1),11)
    # aa.extend(b)
    # aa.extend(aa)
    # aa.extend(aa)
    # print(s2,s1)
    import xlwings as xw
    filepath = "cupWeight2.csv"  # 与程序同目录下

    filepath2 = "C1.xlsx"
    cupwb1 = xw.Book(filepath)
    swb2 =xw.Book(filepath2)
    cupwb1 = xw.App(visible=False, add_book=False).books.open(filepath)
    swb2 = xw.App(visible=False, add_book=False).books.open(filepath2)
    try:
        # sum2sht = wb2.sheets("模板").range('A1').expand().value
        sum2sht = swb2.sheets("模板")
        # num=wb2.sheets('模板').range(1, 1).expand().shape
        sheet1= cupwb1.sheets[0]
        # sheet1.range('a1').expand('down').value = rng
        '''
        批量复制整个
        '''
        my_values = swb2.sheets['模板'].range('A1:am11').options(ndim=2).value
        cupwb1.sheets[0].range('A1:am11').value = my_values
        cupsht = cupwb1.sheets[0]
        wb1.app.calculate('automatic')
        # cupsht.api.Copy(Before = sum2sht.api)

        # print(cupsht)
        # cell_index = str(rng.rows.count+1)
        # range1 = wb2.sheets("Sheet1").range('A'+cell_index)
        # range1.value = wb1.sheets("Sheet1").range('A1').expand('table').value
        cupwb1.save()
        cupwb1.close()
        swb2.close()
    except Exception as ex:
        print(ex)
        cupwb1.close()
        swb2.close()
        # xw.apps.quit()



    # xw.apps.quit()