from django.db import models

# Create your models here.
from django.db import models

class DataMember(models.Model):
    comment = models.CharField(max_length=40) #zifu
    id = models.IntegerField(primary_key=True)  # 整数


    def __str__(self):
        return  self.comment


class Student(models.Model):
    comment = models.CharField(max_length=40) #zifu
    id = models.IntegerField(primary_key=True)  # 整数

    def __str__(self):
        return self.comment

# class T_Eque01():
#     comment = models.CharField(max_length=40)  # zifu
#     id = models.IntegerField(primary_key=True)  # 整数
#
#     def __str__(self):
#         return self.comment
# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = True` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.


'''
class TEqu01(models.Model):
    tag = models.AutoField(unique=True, blank=True, null=True)
    code = models.IntegerField(unique=True, blank=True, null=True)
    flag = models.SmallIntegerField(blank=True, null=True)
    flag_2 = models.SmallIntegerField(blank=True, null=True)
    comment = models.CharField(blank=True, null=True)
    comment_en = models.CharField(blank=True, null=True)
    createtime = models.DateTimeField(db_column='createTime', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = True
        db_table = 'T_Equ01'


class TEqu02(models.Model):
    tag = models.AutoField(unique=True, blank=True, null=True)
    code = models.IntegerField(unique=True, blank=True, null=True)
    flag = models.SmallIntegerField(blank=True, null=True)
    flag_2 = models.SmallIntegerField(blank=True, null=True)
    comment = models.CharField(blank=True, null=True)
    comment_en = models.CharField(blank=True, null=True)
    createtime = models.DateTimeField(db_column='createTime', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = True
        db_table = 'T_Equ02'


class TEqu03(models.Model):
    tag = models.AutoField(unique=True, blank=True, null=True)
    code = models.IntegerField(unique=True, blank=True, null=True)
    flag = models.SmallIntegerField(blank=True, null=True)
    flag_2 = models.SmallIntegerField(blank=True, null=True)
    comment = models.CharField(blank=True, null=True)
    comment_en = models.CharField(blank=True, null=True)
    createtime = models.DateTimeField(db_column='createTime', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = True
        db_table = 'T_Equ03'


class TEqu04(models.Model):
    tag = models.AutoField(unique=True, blank=True, null=True)
    code = models.IntegerField(unique=True, blank=True, null=True)
    flag = models.SmallIntegerField(blank=True, null=True)
    flag_2 = models.SmallIntegerField(blank=True, null=True)
    comment = models.CharField(blank=True, null=True)
    comment_en = models.CharField(blank=True, null=True)
    createtime = models.DateTimeField(db_column='createTime', blank=True, null=True)  # Field name made lowercase.

    class Meta:
        managed = True
        db_table = 'T_Equ04'


class TVersion(models.Model):
    version = models.CharField(blank=True, null=True)

    class Meta:
        managed = True
        db_table = 'T_VERSION'
'''