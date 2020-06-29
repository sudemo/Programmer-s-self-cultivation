"""myblogdemo URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/3.0/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.contrib import admin
from django.urls import path,re_path
from myblog import views as myblogviews

from django.conf.urls import url, include
from rest_framework import routers
# from myblog import views

router = routers.DefaultRouter()
router.register(r'users', myblogviews.UserViewSet)
router.register(r'groups', myblogviews.GroupViewSet)

# 使用自动URL路由连接我们的API。
# 另外，我们还包括支持浏览器浏览API的登录URL。
urlpatterns = [
    path('admin/', admin.site.urls),
    path('myblog/', myblogviews.index),
    url(r'^', include(router.urls)), #匹配字符串开头
    url(r'^api-auth/', include('rest_framework.urls', namespace='rest_framework')),  # 匹配其结尾
    re_path(r'.*',myblogviews.index ),
]
