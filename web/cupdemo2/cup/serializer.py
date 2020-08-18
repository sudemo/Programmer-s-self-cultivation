'''
# @Time    : 2020/6/29 20:19
# @Author  : Neo
# @File    : serializer.py
'''
from django.contrib.auth.models import User,Group
from rest_framework import serializers
from .models import Capsules


class CapsulesSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = Capsules
        fields = ('id', 'line_number', 'inline_number', 'cup_type', 'cup_color', 'cup_status_ng_ok',
                  'NG_type', 'cup_channel', 'vendor','create_time','current_insert_time',)


class UserSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model = User
        fields = ('url', 'username', 'email', 'groups','password')


class GroupSerializer(serializers.HyperlinkedModelSerializer):

        class Meta:
            model = Group
            fields = ('url', 'name')