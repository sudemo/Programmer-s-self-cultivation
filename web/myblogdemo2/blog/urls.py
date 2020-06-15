'''
# @Time    : 2020/6/11 13:33
# @Author  : Neo
# @File    : urls.py
'''
from django.contrib import admin
from django.urls import path
from django.conf.urls import url
from . import views

app_name = 'blog'  # 命名空间，防止url重名

urlpatterns = [
    url('1/',views.index),
    url('12/',views.blog_index),
    # url('', views.detail),
    # url(r'^addUser/',views.add_user),
    # url(r'^show_index/',views.user),
    # url(r'^user_page/(?P<ids>[0-9]+)$',views.active_page,name='user_page'),  #ids匹配函数的参数 这样保证每个url都是可匹配到的
    path('<int:article_id>', views.detail, name='detail'),
    # path('<int:pk>/', views.detail, name='details'),
]