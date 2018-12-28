# -*- coding: UTF-8 -*-
''''
author: zwzhang
Created on: 2018/12/28 13:16
Software: PyCharm Community Edition
'''

import numpy as np
import matplotlib.pyplot as plt
import matplotlib as mpl


# def draw_pie(labels, quants):
#     # make a square figure
#     plt.figure(1, figsize=(6, 6))
#     # For China, make the piece explode a bit
#     expl = [0, 0.1, 0, 0, 0, 0, 0, 0, 0, 0]  # 第二块即China离开圆心0.1
#     # Colors used. Recycle if not enough.
#     colors = ["blue", "red", "coral", "green", "yellow", "orange"]  # 设置颜色（循环显示）
#     # Pie Plot
#     # autopct: format of "percent" string;百分数格式
#     plt.pie(quants, explode=expl, colors=colors, labels=labels, autopct='%1.1f%%', pctdistance=0.8, shadow=True)
#     plt.title('Top 10 GDP Countries', bbox={'facecolor': '0.8', 'pad': 5})
#     plt.show()
#     plt.savefig("pie.jpg")
#     plt.close()
#

# quants: GDP

# labels: country name
#
# labels = ['USA', 'China', 'India', 'Japan', 'Germany', 'Russia', 'Brazil', 'UK', 'France', 'Italy']
#
# quants = [15094025.0, 11299967.0, 4457784.0, 4440376.0, 3099080.0, 2383402.0, 2293954.0, 2260803.0, 2217900.0,
#           1846950.0]
#
# draw_pie(labels, quants)



# # 饼状图
# plot.figure(figsize=(8,8))
labels = [u'Canteen', u'Supermarket', u'Dorm', u'Others']
sizes = [73, 21, 4, 2]
colors = ['red', 'yellow', 'blue', 'green']

explode = (0.05, 0, 0, 0)

patches, l_text, p_text = plt.pie(sizes, explode=explode, labels=labels, colors=colors,
                                labeldistance = 1.1, autopct='%2.0f%%', shadow=False,
                                startangle =90, pctdistance=0.6)

# labeldistance，文本的位置离远点有多远，1.1指1.1倍半径的位置
# autopct，圆里面的文本格式，%3.1f%%表示小数有三位，整数有一位的浮点数
# shadow，饼是否有阴影
# startangle，起始角度，0，表示从0开始逆时针转，为第一块。一般选择从90度开始比较好看
# pctdistance，百分比的text离圆心的距离
# patches, l_texts, p_texts，为了得到饼图的返回值，p_texts饼图内部文本的，l_texts饼图外label的文本

# 改变文本的大小
# 方法是把每一个text遍历。调用set_size方法设置它的属性
for t in l_text:
    t.set_size = 30
for t in p_text:
    t.set_size = 20
# 设置x，y轴刻度一致，这样饼图才能是圆的
plt.axis('equal')
plt.legend(loc='upper left', bbox_to_anchor=(-0.1, 1))
# loc: 表示legend的位置，包括'upper right','upper left','lower right','lower left'等
# bbox_to_anchor: 表示legend距离图形之间的距离，当出现图形与legend重叠时，可使用bbox_to_anchor进行调整legend的位置
# 由两个参数决定，第一个参数为legend距离左边的距离，第二个参数为距离下面的距离
plt.grid()
plt.show()

