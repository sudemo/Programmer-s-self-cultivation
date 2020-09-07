'''
# @Time    : 2020/8/20 15:06
# @Author  : Neo
# @File    : S7demo1.py
'''
import json
# from datetime import time
import time
import snap7
from cmd import Cmd
import sys

# ip = "127.0.0.1"
ip = "192.168.0.10"
area = "0x84"
dbnum = 10
startaddr = 0
count = 1

jsoncmd='''
[
    {"name":"f1","doc":"fun1 is for 1","DB_Number":1011,"Start_address":"0","p_count":"2"},  
    {"name":"f2","doc":"fun2 is for 1","DB_Number":1011,"Start_address":"2","p_count":"2"},
    {"name":"f3","doc":"fun3 is for 1","DB_Number":1011,"Start_address":"4","p_count":"2"}
   
]
    '''

class UnivsersalPLC(Cmd):

    def __init__(self,**kwargs):
        Cmd.__init__(self, **kwargs)
        self.client = snap7.client.Client()
        self.prompt = "CLI>"
        self.intro = "Welcome to Use CLI! "

    def init_connect(self):
        '''
        init plc connect
        :return connect status
        '''
        # client = snap7.client.Client()
        try:
            self.client.connect(ip, 0, 1)
            if self.client.get_connected():
                return True
            else:
                return False
        except Exception as e:
            print(e)
            return False

    # read_area(area,dbnumber,start，size)

    # write（area,dbnumber,start，data）
    # def plc_connect():

    def read_byte_data(self):
        # self.client.read_area(area,dbnum,startaddr,count)
        return self.client.db_read(dbnum,startaddr,count)

    def do_RDB(self,dbnum,):
        # return 会使程序退出
        try:
            print(type(dbnum))

            print( self.client.db_read(eval(dbnum),0,1))
        except Exception as e:
            print(e)

    def analyze_data(self,arg):
        '''将字节串 转换为16进制 然后转换为10进制'''
        return int(arg.hex(), 16)

    def do_hello(self, name,NA):
        print("hello", name,NA)

    def do_exit(self, arg):
        print("exiting")
        sys.exit(0)

    def emptyline(self):
        print("empty line! please input sth")

    def default(self, line):
        print("unknow command", line)

    def do_script(self,args):
        """Run script file. Argument should be filename"""
        try:
            with open(sys.path[0] + '/' + args) as f:
                for line in f:
                    self.onecmd(line)
            return True
        except IOError:
            print("Script file not found!\n%s")
            sys.stdout.flush()
            return False

'''
    def preloop(self):
        """命令line解析之前被调用该方法"""
        print("before loop")

    def postloop(self):
        print("before after loop")

    def precmd(self, line):
        print("before cmd")
        return Cmd.precmd(self, line)


    def postcmd(self, stop, line):
        print("print this line after do a command")
        return Cmd.postcmd(self, stop, line)
'''


def make_fun_attr(name, doc, p_db_number, p_start_address, p_count):  # 定义参数
    def function(self, mode):
        try:
            __doc__ = doc  # name meiyong dao
            start_address = p_start_address
            db_Number = eval(p_db_number)
            count =eval(p_count)
            # 为了保留上一个函数的参数值二设置

            if mode == 'w':
                print('write  plc mode,please input param')
                p_count_array = bytearray(p_count, 'utf-8')
                self.client.db_write(p_db_number, start_address, p_count_array) # 在此模式下 p_count即为data in byte array

                return
            else:
                res = self.client.db_read(start_address, db_Number, count)
                print("read res :",res.hex(),(int(res.hex(), 16)))

        except Exception as e:
            print(e)

    # 一般而言，是对函数/方法/模块所实现功能的简单描述。
    # 但当指向具体对象时，会显示此对象从属的类型的构造函数的文档字符串。
    function.__doc__ = doc
    return function  # 产生一个动态函数


def main():
    ins = UnivsersalPLC()  # 创建instance
    res = ins.init_connect()
    if res:
        # res1 = ins.read_byte_data()
        # print("test reading",res1)
        # print(ins.analyze_data(res1))
        print("connected")
    j = json.loads(jsoncmd)

    for item in j:
        # 字符串比较，控制输出格式，将输入的字符串doc赋值给fname
        new_func_name = "do_%s" % item["name"]
        setattr(UnivsersalPLC, new_func_name, make_fun_attr(new_func_name, item["doc"], item["Start_address"], item["DB_Number"], item["p_count"]))
    # while 1:
    #     ins.do_script(str(1))
        # print('1')
        # time.sleep(1)
    ins.cmdloop()


if __name__=='__main__':
    # ins = UnivsersalPLC()  # 创建instance
    main()

