# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2018/12/31 9:56
Software: PyCharm Community Edition
'''
f=lambda l:l[0]*(abs(eval(l[0])-24)<1e-6)if(len(l)<2)else([r for i in range(len(l))for j in(range(0,i) + range(i+1,len(l)))for c in["+","-","*"]+["/"]*(eval(l[j])!=0)for r in[f([v for k,v in enumerate(l)if k!=i and k!=j]+["("+l[i]+c+l[j]+")"])]if r]+[0])[0]

print(f(["10.0", "10.0", "4.0", "4.0"]))