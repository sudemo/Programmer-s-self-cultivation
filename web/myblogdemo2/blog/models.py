from django.db import models

# Create your models here.
from django.db import models


class Blog(models.Model):
    title = models.CharField(max_length=100)
    creat_date = models.DateTimeField()
    content = models.TextField()
    # substract = content[:20]

    def __str__(self):
        # return "标题：{} 字数： {}，时间：{}，概要： {} ; ".format(self.title,len(self.content),self.creat_date, self.content[:20])
        return  self.title
