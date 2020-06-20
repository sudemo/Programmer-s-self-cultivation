# from django.shortcuts import render
#
# # Create your views here.
from django.http import HttpResponse
from exam import models
from django.db import models
# import  json
# import models

def get_detail_fromdb():

    detail = models.TEqu01.objects.all()
    return HttpResponse(detail)



def get_name(arg):

    # ss = models.DataMember.objects.all()
    # return HttpResponse(arg, str(ss))
    ss = models.Student.objects.all()
    ulist = ["name:","nerd"]
    # print(ss, type(ss))
    # context = {
    #     'blog_index': ss,
    # }
    return  HttpResponse(ss)    # 注意这里是否要夹参数arg
    # return  HttpResponse(json.dumps(ulist))
