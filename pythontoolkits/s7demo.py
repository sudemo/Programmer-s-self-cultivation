'''
# @Time    : 2020/7/9 19:43
# @Author  : Neo
# @File    : s7demo.py
'''
import snap7
from snap7.util import *

mclient = snap7.client.Client()
try:
    mclient.connect('127.0.0.1',0,0)
except Exception as e:
    print(e)
if mclient.get_connected():
    print('ok')
    area = snap7.snap7types.areas.DB
    dbnum = 100
    amount = 10
    start = 0
    # data = bytearray([1, 2, 3])
    # print('原始', data)
    # wr = mclient.db_write(dbnum, start, data)
    # rr = mclient.db_read(dbnum, start, amount)
    size = 4
    start = 0
    db = 1
    data = bytearray([5])
    mclient.db_write(db_number=db, start=start, data=data)
    result = mclient.db_read(db_number=db, start=start, size=size)
    # mclient.assertEqual(data, result)
    print(result)
else :
    print('no')


# while(1):
#     pass