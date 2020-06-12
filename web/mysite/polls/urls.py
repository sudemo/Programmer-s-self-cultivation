'''
# @Time    : 2020/6/12 8:59
# @Author  : Neo
# @File    : urls.py
'''
from django.urls import path
from . import views


app_name = 'polls'  # 命名空间，防止url重名

urlpatterns = [
    path('', views.index, name='index'),  # name是为templates 所用
    path('<int:question_id>/', views.detail, name='detail'),
    path('<int:question_id>/results/', views.results, name='results'),
    path('<int:question_id>/vote/', views.vote, name='vote'),
]