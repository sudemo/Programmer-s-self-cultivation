'''
# @Time    : 2020/6/29 13:44
# @Author  : Neo
# @File    : urls.py
'''
from django.urls import path,re_path
from django.conf.urls import url, include
from rest_framework import routers
# from cup import views
from cup import views as cviews
# from cup import ip

router = routers.DefaultRouter()
router.register(r'cap', cviews.CapsuleViewSet)
router.register(r'groups', cviews.GroupViewSet)
router.register(r'user', cviews.UserViewSet)

urlpatterns = [
    # path('admin/', admin.site.urls),
    # path('',views.index),
    url(r'^', include(router.urls)),  #匹配字符串开头
    url(r'^api-auth/', include('rest_framework.urls', namespace='rest_framework')),
    re_path(r'.*', cviews.index),

]

