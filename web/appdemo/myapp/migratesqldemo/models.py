# This is an auto-generated Django model module.
# You'll have to do the following manually to clean this up:
#   * Rearrange models' order
#   * Make sure each model has one field with primary_key=True
#   * Make sure each ForeignKey and OneToOneField has `on_delete` set to the desired behavior
#   * Remove `managed = False` lines if you wish to allow Django to create, modify, and delete the table
# Feel free to rename the models, but don't rename db_table values or field names.
from django.db import models


class TEqu01(models.Model):
    tag = models.AutoField(primary_key=True)
    code = models.IntegerField(unique=True, blank=True, null=True)
    flag = models.SmallIntegerField(blank=True, null=True)
    flag_2 = models.SmallIntegerField(blank=True, null=True)
    comment = models.CharField(max_length=400)
    comment_en = models.CharField(max_length=400)
    createtime = models.DateTimeField(db_column='createTime', blank=True, null=True)  # Field name made lowercase.

    def __str__(self):
        return  self.comment
    class Meta:
        managed = False
        db_table = 'T_Equ01'


# class TEqu02(models.Model):
#     tag = models.AutoField(unique=True, blank=True, null=True)
#     code = models.IntegerField(unique=True, blank=True, null=True)
#     flag = models.SmallIntegerField(blank=True, null=True)
#     flag_2 = models.SmallIntegerField(blank=True, null=True)
#     comment = models.CharField(blank=True, null=True)
#     comment_en = models.CharField(blank=True, null=True)
#     createtime = models.DateTimeField(db_column='createTime', blank=True, null=True)  # Field name made lowercase.
#
#     class Meta:
#         managed = False
#         db_table = 'T_Equ02'
#
#
# class TEqu03(models.Model):
#     tag = models.AutoField(unique=True, blank=True, null=True)
#     code = models.IntegerField(unique=True, blank=True, null=True)
#     flag = models.SmallIntegerField(blank=True, null=True)
#     flag_2 = models.SmallIntegerField(blank=True, null=True)
#     comment = models.CharField(blank=True, null=True)
#     comment_en = models.CharField(blank=True, null=True)
#     createtime = models.DateTimeField(db_column='createTime', blank=True, null=True)  # Field name made lowercase.
#
#     class Meta:
#         managed = False
#         db_table = 'T_Equ03'
#
#
# class TEqu04(models.Model):
#     tag = models.AutoField(unique=True, blank=True, null=True)
#     code = models.IntegerField(unique=True, blank=True, null=True)
#     flag = models.SmallIntegerField(blank=True, null=True)
#     flag_2 = models.SmallIntegerField(blank=True, null=True)
#     comment = models.CharField(blank=True, null=True)
#     comment_en = models.CharField(blank=True, null=True)
#     createtime = models.DateTimeField(db_column='createTime', blank=True, null=True)  # Field name made lowercase.
#
#     class Meta:
#         managed = False
#         db_table = 'T_Equ04'
#
#
# class TVersion(models.Model):
#     version = models.CharField(blank=True, null=True)
#
#     class Meta:
#         managed = False
#         db_table = 'T_VERSION'
#
#
# class AuthGroup(models.Model):
#     name = models.CharField(unique=True, max_length=150)
#
#     class Meta:
#         managed = False
#         db_table = 'auth_group'
#
#
# class AuthGroupPermissions(models.Model):
#     group = models.ForeignKey(AuthGroup, models.DO_NOTHING)
#     permission = models.ForeignKey('AuthPermission', models.DO_NOTHING)
#
#     class Meta:
#         managed = False
#         db_table = 'auth_group_permissions'
#         unique_together = (('group', 'permission'),)
#
#
# class AuthPermission(models.Model):
#     content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING)
#     codename = models.CharField(max_length=100)
#     name = models.CharField(max_length=255)
#
#     class Meta:
#         managed = False
#         db_table = 'auth_permission'
#         unique_together = (('content_type', 'codename'),)
#
#
# class AuthUser(models.Model):
#     password = models.CharField(max_length=128)
#     last_login = models.DateTimeField(blank=True, null=True)
#     is_superuser = models.BooleanField()
#     username = models.CharField(unique=True, max_length=150)
#     first_name = models.CharField(max_length=30)
#     email = models.CharField(max_length=254)
#     is_staff = models.BooleanField()
#     is_active = models.BooleanField()
#     date_joined = models.DateTimeField()
#     last_name = models.CharField(max_length=150)
#
#     class Meta:
#         managed = False
#         db_table = 'auth_user'
#
#
# class AuthUserGroups(models.Model):
#     user = models.ForeignKey(AuthUser, models.DO_NOTHING)
#     group = models.ForeignKey(AuthGroup, models.DO_NOTHING)
#
#     class Meta:
#         managed = False
#         db_table = 'auth_user_groups'
#         unique_together = (('user', 'group'),)
#
#
# class AuthUserUserPermissions(models.Model):
#     user = models.ForeignKey(AuthUser, models.DO_NOTHING)
#     permission = models.ForeignKey(AuthPermission, models.DO_NOTHING)
#
#     class Meta:
#         managed = False
#         db_table = 'auth_user_user_permissions'
#         unique_together = (('user', 'permission'),)
#
#
# class DjangoAdminLog(models.Model):
#     action_time = models.DateTimeField()
#     object_id = models.TextField(blank=True, null=True)
#     object_repr = models.CharField(max_length=200)
#     change_message = models.TextField()
#     content_type = models.ForeignKey('DjangoContentType', models.DO_NOTHING, blank=True, null=True)
#     user = models.ForeignKey(AuthUser, models.DO_NOTHING)
#     action_flag = models.PositiveSmallIntegerField()
#
#     class Meta:
#         managed = False
#         db_table = 'django_admin_log'
#
#
# class DjangoContentType(models.Model):
#     app_label = models.CharField(max_length=100)
#     model = models.CharField(max_length=100)
#
#     class Meta:
#         managed = False
#         db_table = 'django_content_type'
#         unique_together = (('app_label', 'model'),)
#
#
# class DjangoMigrations(models.Model):
#     app = models.CharField(max_length=255)
#     name = models.CharField(max_length=255)
#     applied = models.DateTimeField()
#
#     class Meta:
#         managed = False
#         db_table = 'django_migrations'
#
#
# class DjangoSession(models.Model):
#     session_key = models.CharField(primary_key=True, max_length=40)
#     session_data = models.TextField()
#     expire_date = models.DateTimeField()
#
#     class Meta:
#         managed = False
#         db_table = 'django_session'
#
#
# class ExamDatamember(models.Model):
#     comment = models.CharField(max_length=40)
#
#     class Meta:
#         managed = False
#         db_table = 'exam_datamember'
#
#
# class ExamStudent(models.Model):
#     comment = models.CharField(max_length=40)
#
#     class Meta:
#         managed = False
#         db_table = 'exam_student'
#
#
# class PersonAuthor(models.Model):
#     name = models.CharField(max_length=50)
#     email = models.CharField(max_length=254)
#
#     class Meta:
#         managed = False
#         db_table = 'person_author'
#
#
# class PersonBlog(models.Model):
#     name = models.CharField(max_length=100)
#     tagline = models.TextField()
#
#     class Meta:
#         managed = False
#         db_table = 'person_blog'
#
#
# class PersonEntry(models.Model):
#     headline = models.CharField(max_length=255)
#     body_text = models.TextField()
#     pub_date = models.DateField()
#     mod_date = models.DateField()
#     n_comments = models.IntegerField()
#     n_pingbacks = models.IntegerField()
#     rating = models.IntegerField()
#     blog = models.ForeignKey(PersonBlog, models.DO_NOTHING)
#
#     class Meta:
#         managed = False
#         db_table = 'person_entry'
#
#
# class PersonEntryAuthors(models.Model):
#     entry = models.ForeignKey(PersonEntry, models.DO_NOTHING)
#     author = models.ForeignKey(PersonAuthor, models.DO_NOTHING)
#
#     class Meta:
#         managed = False
#         db_table = 'person_entry_authors'
#         unique_together = (('entry', 'author'),)
#
#
# class PersonPerson(models.Model):
#     name = models.CharField(max_length=40)
#     age = models.IntegerField()
#
#     class Meta:
#         managed = False
#         db_table = 'person_person'
