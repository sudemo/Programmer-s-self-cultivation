from django.shortcuts import render

# Create your views here.
from django.shortcuts import render
from django.http import HttpResponse

def add(request):
    a = request.GET['a']  # 该方法类似与字典，更好的是采用Get.get('a',0),默认没有值的时候为0
    b = request.GET['b']
    c = int(a) + int(b)
    return HttpResponse(str(c))

def add2(arg ,a,b):
    c = int(a)+int(b)
    return HttpResponse(str(c))
