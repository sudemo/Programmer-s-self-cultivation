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
    b=[1,2,3]

    aa.extend(b)
    aa.extend(aa)
    aa.extend(aa)
    print(aa)


