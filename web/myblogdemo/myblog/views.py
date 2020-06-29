# Create your views here.

from django.http import HttpResponse
from django.contrib.auth.models import User, Group
from rest_framework import viewsets,views
from myblog.serializers import UserSerializer, GroupSerializer
from myblog import models
from django.views.decorators.csrf import csrf_exempt



def index(request):
    return HttpResponse("Good moring Neo，what's the focus today? ")
    # ss = models.Article.objects.values()
    # ss = models.Article.objects.values_list()
    # print(ss,type(ss))
    # return HttpResponse(ss)

# @csrf_exempt
class UserViewSet(viewsets.ModelViewSet):
    """
    允许用户查看或编辑的API路径。
    """
    queryset = User.objects.all().order_by('-date_joined')
    serializer_class = UserSerializer

# @csrf_exempt
class GroupViewSet(viewsets.ModelViewSet):
    """
    允许组查看或编辑的API路径。
    """
    queryset = Group.objects.all()
    serializer_class = GroupSerializer
