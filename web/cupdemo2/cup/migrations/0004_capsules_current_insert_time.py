# Generated by Django 3.0.6 on 2020-06-30 07:25

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('cup', '0003_capsules_vendor'),
    ]

    operations = [
        migrations.AddField(
            model_name='capsules',
            name='current_insert_time',
            field=models.DateTimeField(auto_now_add=True, null=True),
        ),
    ]