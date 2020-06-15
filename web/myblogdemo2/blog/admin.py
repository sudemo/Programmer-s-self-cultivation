from django.contrib import admin

# Register your models here.
from django.contrib import admin
from blog.models import Blog

#register model

class BlogAdmin(admin.ModelAdmin):
    list_display = ['title']

admin.site.register(Blog,BlogAdmin)