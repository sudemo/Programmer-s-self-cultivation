from django.test import TestCase

# Create your tests here.
from django.test import TestCase
from django.test.client import Client
# Create your tests here.
import pytest
import os
# os.environ.update({"DJANGO_SETTINGS_MODULE": "config.settings"})

def test_conn():
    c = Client()
    rep =c.get('')
    assert rep == ''
def test_func():
    assert 1 ==1

# def test_upper():
#     assert 'foo'.upper() == 'FOO1'
#
# class TestClass:
#     def test_one(self):
#         x = "this"
#         assert "h" in x
#
#     def test_two(self):
#         x = "hello"
#         with pytest.raises(TypeError):
#             x + []

