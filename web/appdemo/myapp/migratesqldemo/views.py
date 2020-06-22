from django.shortcuts import render

# Create your views here.
from migratesqldemo import models
from django.http import HttpResponse


def get_datail(arg):

    detail_data = models.TEqu01.objects.all()
    return  HttpResponse(detail_data)
