# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models


class Capsule(models.Model):
    id = models.IntegerField(primary_key=True)
    整线编号 = models.CharField(max_length=45)
    线内编号 = models.CharField(max_length=45)
    杯子类型 = models.CharField(max_length=45)
    杯子颜色 = models.IntegerField()
    工站 = models.CharField(max_length=45)
    杯子状态ng_ok = models.IntegerField(db_column='杯子状态ng/ok')  # Field renamed to remove unsuitable characters.
    ng类型 = models.CharField(db_column='NG类型', max_length=45)  # Field name made lowercase.
    杯道 = models.IntegerField()
    时间 = models.DateTimeField()

    class Meta:
        managed = False
        db_table = 'capsule'
