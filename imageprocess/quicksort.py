# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2018/12/28 15:20
Software: PyCharm Community Edition
'''
import numpy as np
def quicksort(arr):
    """ O(nlog n) 期望时间，O(n^2) 最坏情况； 对于大的、乱数列表一般相信是最快的已知排序"""
    if len(arr) <= 1:
        return arr
    pivot = arr[len(arr) // 2]
    left = [x for x in arr if x < pivot] #列表推导式
    middle = [x for x in arr if x == pivot]
    right = [x for x in arr if x > pivot]
    return quicksort(left) + middle + quicksort(right)

# print(quicksort([3,6,8,10,9,9,1,2,1]))
a = np.random.rand(10)
print(quicksort(a))