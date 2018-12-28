# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2018/12/28 15:20
Software: PyCharm Community Edition
'''
def quicksort(arr):
    if len(arr) <= 1:
        return arr
    pivot = arr[len(arr) // 2]
    left = [x for x in arr if x < pivot]
    middle = [x for x in arr if x == pivot]
    right = [x for x in arr if x > pivot]
    return quicksort(left) + middle + quicksort(right)

print(quicksort([3,6,8,10,9,9,1,2,1]))