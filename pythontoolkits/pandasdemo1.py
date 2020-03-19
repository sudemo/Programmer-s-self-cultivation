'''
# @Time    : 2020/3/19 10:48
# @Author  : Neo
# @File    : pandasdemo1.py
'''
import pandas as pd
import  numpy as np
# print(pd.__version__)
data = pd.Series([0.3, 0.4, 0.7, 1])
# print(data,type(data),data.index)
population_dict = {'California': 38332521, 'Texas': 26448193, 'New York': 19651127, 'Florida': 19552860,
                   'Illinois': 12882135}
pop1 =pd.Series(population_dict)
# print(pop["Illinois"])
'''
和 Series 对象一样，DataFrame
既可以作为一个通用型 NumPy 数组，也可以看作特殊的 Python 字典
和 Series 对象一样，DataFrame 也有一个 index 属性可以获取索引标签：

'''
# print(pd.DataFrame(pop1, columns=["pop num"]))
area = pd.Series({'California': 423967, 'Texas': 695662, 'New York': 141297, 'Florida': 170312, 'Illinois': 149995})
pop = pd.Series(
    {'California': 38332521, 'Texas': 26448193, 'New York': 19651127, 'Florida': 19552860, 'Illinois': 12882135})
data2 = pd.DataFrame({'area': area, 'pop': pop})
print(data2)
# data2['density'] = pop/area
data2['density']= data2['area']/data2['pop']
print(data2)