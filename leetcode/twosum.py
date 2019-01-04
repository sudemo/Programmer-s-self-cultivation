# -*- coding: UTF-8 -*-
''''
author:neo
Created on: 2019/1/4 11:48
Software: PyCharm Community Edition
'''
class Solution:
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        for i in range(len(nums)):
            for j in range (i+1,len(nums)):
                if nums[i] + nums[j] == target:
                    return [i,j]
if __name__ =="__main__":
    s = Solution()
    print (s.twoSum([2,71,1,15],9))