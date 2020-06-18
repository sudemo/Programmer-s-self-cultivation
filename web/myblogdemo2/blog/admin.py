from django.contrib import admin

# Register your models here.
from django.contrib import admin
from blog.models import Blog,Book

#register model

class BlogAdmin(admin.ModelAdmin):
    list_display = ['title','creat_date']

class BookAdmin(admin.ModelAdmin):
    list_display = ['book_name','author','publish_date' ]


admin.site.register(Blog,BlogAdmin)
admin.site.register(Book,)
