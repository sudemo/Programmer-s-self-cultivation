'''
# @Time    : 2020/7/7 16:24
# @Author  : Neo
# @File    : rowcoltest.py
'''
import datetime
import time
LEN = 10000
# bytearray[][]
# arr = new
# int[LEN][LEN];
ii = 1000
s1 = time.process_time_ns()
aa = [[],[]]


multilist = [[0 for col in range(1000)] for row in range(1000)] # 推荐
# 先列后行
# for j in range(1000):
#     for i in range(1000):
#         multilist[j][i] = 1
# 先行再列  从左到右到下
for i in range(1000):
    for j in range(1000):
        multilist[i][j] = 1

s2 = time.process_time_ns()-s1
print(s2)

#  结果一致