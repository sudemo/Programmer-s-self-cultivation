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
    # aa= []
    #
    # s11 = []; s111 = []; s111 = []
    # s1=s2=s3=[]
    # b=s1=[1,2,3]
    # s1.insert(len(s1),11)
    # aa.extend(b)
    # aa.extend(aa)
    # aa.extend(aa)
    # print(s2,s1)
    import xlwings as xw
    import time
    from tqdm import tqdm
    # print(xw.__version__)
    filepath = "cupWeight2.xlsx"  # 与程序同目录下

    filepath2 = "C1.xlsx"
    # cupwb1 = xw.Book(filepath)
    # swb2 = xw.Book(filepath2)
    # cupwb1 = xw.App(visible=True, add_book=False).books.open(filepath)
    swb2 = xw.App(visible=True, add_book=False).books.open(filepath2)
    #
    try:
    #     # sum2sht = wb2.sheets("模板").range('A1').expand().value

        sum2sht = swb2.sheets["模板"]

    #     # num=wb2.sheets('模板').range(1, 1).expand().shape
    #     sht1= swb2.sheets['Sheet1']

        # cupsheet= cupwb1.sheets[1]
        # cupsheet.range('v2:e5').clear_contents()
        sum2sht.api.Copy(Before=sum2sht.api)
        sht1 = swb2.sheets['模板 (2)']
        sht1.name ='0402'
        sht12 =swb2.sheets['0402']
        sht12.range('v2').expand('table').clear_contents()
        pbar = tqdm(total=100)
        for i in range(10):
            pbar.update(1)
        time.sleep(0.1)
        pbar.close()


        swb2.save()

    except Exception as ex:
        print(ex)

        swb2.close()


