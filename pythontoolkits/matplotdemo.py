'''
# @Time    : 2020/3/19 14:00
# @Author  : Neo
# @File    : matplotdemo.py
'''
rng = np.random.RandomState(1)
x = 10 * rng.rand(50)
y = 2 * x - 5 + rng.randn(50)
plt.scatter(x, y)