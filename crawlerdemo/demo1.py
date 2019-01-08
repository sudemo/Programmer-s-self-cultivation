
''''
author:neo
Created on: 2019/1/4 16:09
Software: PyCharm Community Edition
'''
import requests
from bs4 import BeautifulSoup
import time
import lxml
# url = 'https://neo3301.wordpress.com/2018/12/29/%E8%B1%86%E6%A3%9A%E7%93%9C%E6%9E%B6%E9%9B%A8%E5%A6%82%E4%B8%9D%EF%BC%8C%E6%96%99%E5%BA%94%E5%8E%8C%E4%BD%9C%E4%BA%BA%E9%97%B4%E8%AF%AD%EF%BC%8C%E7%88%B1%E5%90%AC%E7%A7%8B%E5%9D%9F%E9%AC%BC%E5%94%B1/'
# url = 'http://baidu.com'
# url = 'https://www.biqukan.com/1_1094/5403177.html'
# while 1:
#     time.sleep(0.1)

url = 'https://blog.csdn.net/u012422524/article/details/86065085'
data = requests.get(url)
# data.status_code
# print(data.text)


html1 = data.text
bf = BeautifulSoup(html1,"lxml")
texts = bf.find_all('main',class_ ='read-count')
# print(texts)

# # -*- coding: utf-8 -*-
# import os
#
# import requests
# from lxml import html
#
# headers = {
#     'Host': 'www.zhihu.com',
#     'Accept-Language': 'zh-CN,zh;q=0.8,en;q=0.6',
#     # 2017.12 经网友提醒，知乎更新后启用了网页压缩，所以不能再采用该压缩头部
#     # !!!注意, 请求头部里使用gzip, 响应的网页内容不一定被压缩，这得看目标网站是否压缩网页
#     'Accept-Encoding': 'gzip, deflate, sdch, br',
#     'Connection': 'keep-alive',
#     'Pragma': 'no-cache',
#     'Cache-Control': 'no-cache',
#     'Upgrade-Insecure-Requests': '1',
#     'Accept': 'text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8',
#     'User-Agent': 'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_4) '
#                   'AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36',
# }
#
#
# def save(text, filename='temp', path='download'):
#     fpath = os.path.join(path, filename)
#     with open(fpath, 'w') as  f:
#         print('output:', fpath)
#         f.write(text)
#
#
# def save_image(image_url):
#     resp = requests.get(image_url)
#     page = resp.content
#     filename = image_url.split('zhimg.com/')[-1]
#     save(page, filename)
#
#
# def crawl(url):
#     resp = requests.get(url, headers=headers)
#     page = resp.content
#     root = html.fromstring(page)
#     image_urls = root.xpath('//img[@data-original]/@data-original')
#     if image_urls:
#         for image_url in image_urls:
#             save_image(image_url)
#     else:
#         print('nth')
#
# if __name__ == '__main__':
#     # 注意在运行之前，先确保该文件的同路径下存在一个download的文件夹, 用于存放爬虫下载的图片
#     url = 'https://www.zhihu.com/question/27364360'
#     crawl(url)
