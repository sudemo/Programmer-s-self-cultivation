'''
# @Time    : 2020/9/3 11:23
# @Author  : Neo
# @File    : opcclientdemo1.py
'''
from opcua import Client
from opcua import ua
import time
#
# #By Weloveut:Python访问OPCUA服务器，展示get变量的方法和注册逢变触发的回调函数
# #自定义回调函数
#
# class SubHandler(object):
# 	def data_change(self, handle, node, val, attr):
# 		print("Python: New data change event", handle, node, val, attr)
# # 创建UA的客户端，包含IP地址和端口号
#
# client = Client("opc.tcp://localhost:4840/freeopcua/server/")
# #  建立到服务器连接
# client.connect()
# #  获取object对象
# objects = client.get_objects_node()
# #  获取根对象
# root = client.get_root_node()
# #  依据变量地址创建变量对象
# myvar = client.get_node('ns=3;s="clocl0.5hz"."tags"[0]')
# #  获取变量当前值
# valuetmp=myvar.get_value()
# print(valuetmp)
#
# #  注册到服务器的变量订阅，变量逢变触发
# handler = SubHandler()
# sub = client.create_subscription(500, handler)
# sub.subscribe_data_change(myvar)
# time.sleep(100000)
# client.disconnect()

client = Client("opc.tcp://localhost:4840/freeopcua/server/")
# client = Client("opc.tcp://127.0.0.1:4840/freeopcua/server/")
# client = Client("opc.tcp://admin@localhost:4840/freeopcua/server/") #connect using a user

try:
	res = client.connect()

	# Client has a few methods to get proxy to UA nodes that should always be in address space such as Root or Objects
	root = client.get_root_node()
	print("Objects node is: ", root)

	# Node objects have methods to read and write node attributes as well as browse or populate address space
	print("Children of root are: ", root.get_children())

	# get a specific node knowing its node id
	# var = client.get_node(ua.NodeId(1002, 2))
	# var = client.get_node("ns=3;i=2002")
	# print(var)
	# var.get_data_value() # get value of node as a DataValue object
	# var.get_value() # get value of node as a python builtin
	# var.set_value(ua.Variant([23], ua.VariantType.Int64)) #set node value using explicit data type
	# var.set_value(3.9) # set node value using implicit data type

	# Now getting a variable node using its browse path
	while (1):
		myvar = root.get_child(["0:Objects", "2:MyObject", "2:MyVariable"])
		obj = root.get_child(["0:Objects", "2:MyObject"])
		print("myvar is: ", myvar)
		print("myobj is: ", obj)

		# Stacked myvar access
		print("myvar is: ", root.get_children()[0].get_children()[1].get_variables()[0].get_value())
		time.sleep(2)

finally:
	client.disconnect()