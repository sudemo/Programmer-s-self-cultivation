from django.db import models

# Create your models here.
from django.utils import timezone


class Capsules(models.Model):
    id = models.IntegerField(primary_key=True)
    line_number = models.CharField(max_length=45)   #整线编号
    inline_number = models.CharField(max_length=45)
    cup_type = models.CharField(max_length=45)
    cup_color = models.CharField(max_length=45)
    station = models.CharField(max_length=45)
    cup_status_ng_ok = models.CharField(max_length=45)  # Field renamed to remove unsuitable characters.
    NG_type = models.CharField(db_column='NG type', max_length=45)  # Field name made lowercase.
    cup_channel = models.IntegerField()
    create_time = models.DateTimeField()
    current_insert_time = models.DateTimeField(auto_now_add=True,null=True)
    vendor = models.CharField(max_length=45,default='DJHS')
    def __str__(self):
        return self.cup_status_ng_ok
    class Meta:
        # managed = False
        db_table = 'capsules'

class Person(models.Model):
    p_name = models.CharField(max_length=20, null=False, unique=True)
    p_age = models.IntegerField(default=10)
    p_sex = models.BooleanField(default=True)