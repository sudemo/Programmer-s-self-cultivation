"""myblogdemo2 URL Configuration

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
from django.conf.urls import url
from django.urls import path, include
from blog import views as mviews

urlpatterns = [
    path('admin/', admin.site.urls),
    path('1/', mviews.index),
    # path('', mviews.blog_index, name='blog_index'),
    # url(r'^blog/', include('blog.urls',namespace='blog')),
    # path(r'^active/(?P<active_id>[0-9]+)$',)
    # path('12/', mviews.blog_index),
    path('blog/', include('blog.urls')),
]
