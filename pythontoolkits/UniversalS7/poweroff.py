'''
# @Time    : 2020/8/21 16:23
# @Author  : Neo
# @File    : poweroff.py
'''

import snap7
import time

myclient = snap7.client.Client()
myclient.connect("192.168.0.10", 0, 0)
print(myclient.get_connected())
while True:
    time.sleep(1)
    try:
        res = myclient.db_read(1011, 4, 2)
        print(int(res.hex(), 16))

    except Exception as e:
        print(e)
        continue
