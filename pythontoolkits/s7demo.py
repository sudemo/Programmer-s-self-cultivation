'''
# @Time    : 2020/7/9 19:43
# @Author  : Neo
# @File    : s7demo.py
'''
import snap7
from snap7.util import *

mclient = snap7.client.Client()
try:
    # mclient.connect('127.0.0.1',0,0)
    mclient.connect('192.168.0.10',0,0)

except Exception as e:
    print(e)
if mclient.get_connected():
    print('ok')
    try:

        dbnum = 1000
        amount = 2
        start = 0
        data = bytearray([1, 2])
        # count = len(data) / 2
        # integers = struct.unpack('H' * count, data)
        # print('原始', data)
        # int_values = [x for x in data]
        # print(int_values)
        # wr = mclient.db_write(dbnum, start, data)
        rr = mclient.db_read(dbnum, start, amount)  #16进制 字节
        print(rr,[x for x in rr])
        # print(rr.hex())
        r10= int(rr.hex(), 16)  # 转换为10进制
        print(r10)
        mclient.disconnect()
    except Exception as e:
        print(e)
#     size = 4
#     start = 0
#     db = 1
#     data = bytearray([5])
#     # mclient.db_write(db_number=db, start=start, data=data)
#     result = mclient.db_read(db_number=db, start=start, size=size)
#     # mclient.assertEqual(data, result)
#     print(result)
# else :
#     print('no')


# while(1):
#     pass