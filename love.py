# -*- coding: UTF-8 -*-
''''
author:neo
Created on: 2018/12/31 9:24
Software: PyCharm Community Edition
'''

# print('\n'.join([''.join([('ilovephverymuch'[(x-y)%len('ilovephverymuch')]if((x*0.05)**2+(y*0.1)**2-1)**3-(x*0.05)**2*(y*0.1)**3<=0 else' ')for x in range(-30,30)])for y in range(15,-15,-1)]))

print('\n'.join([''.join([('Love'[( x -y) % len('love')] if ((x*0.05)**2+(y*0.1)**2-1)**3-(x*0.05)**2*(y*0.1)**3 <= 0 else ' ') for x in range(-30, 30)]) for y in range(30, -30, -1)]))

