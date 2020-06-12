from django.db import models

# Create your models here.
from django.db import models
import datetime
from django.utils import timezone

class Question(models.Model):
    question_text = models.CharField(max_length=200)
    pub_date =models.DateTimeField('data published')

    def was_published_recently(self):
        return self.pub_date >= timezone.now() - datetime.timedelta(days=1)

    def __str__(self):
        return self.question_text


class Choice(models.Model):
    # 每个 Choice 对象都关联到一个 Question 对象。Django
    # 支持所有常用的数据库关系：多对一、多对多和一对一。
    question = models.ForeignKey(Question, on_delete=models.CASCADE)
    choice_text = models.CharField(max_length=200)
    votes = models.IntegerField(default=0)




    def __str__(self):
        return self.choice_text