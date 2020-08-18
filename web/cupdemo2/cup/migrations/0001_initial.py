# Generated by Django 3.0.6 on 2020-06-29 06:41

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Capsules',
            fields=[
                ('id', models.IntegerField(primary_key=True, serialize=False)),
                ('line_number', models.CharField(max_length=45)),
                ('inline_number', models.CharField(max_length=45)),
                ('cup_type', models.CharField(max_length=45)),
                ('cup_color', models.IntegerField()),
                ('station', models.CharField(max_length=45)),
                ('cup_status_ng_ok', models.IntegerField(db_column='cup status ng/ok')),
                ('NG_type', models.CharField(db_column='NG type', max_length=45)),
                ('cup_channel', models.IntegerField()),
                ('create_time', models.DateTimeField()),
            ],
            options={
                'db_table': 'capsules',
            },
        ),
        migrations.CreateModel(
            name='Person',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('p_name', models.CharField(max_length=20, unique=True)),
                ('p_age', models.IntegerField(default=10)),
                ('p_sex', models.BooleanField(default=True)),
            ],
        ),
    ]
