# -*- coding: UTF-8 -*-
''''
author: zwzhang
email: zwzhang@colibri.com.cn
Created on: 2018/10/18 15:47
Software: PyCharm Community Edition
'''
from cmd import Cmd
import serial
import threading
import sys
import yaml
import logging
import Queue
import os

confpath = sys.path[0] + "/IO.yaml"


#TODO: 增加log部分

class MyPrompt(Cmd):
    def __init__(self, configfile):
        Cmd.__init__(self)
        self.init(configfile)
        self.start_time = int(time.time() * 1000)
        self.postcmd(None,None)
        self.thread = None
        self.log_file = None
        self.thread_start_block = threading.Event()
        self._queue = Queue.Queue()
        self.start()

    def init(self,configfile):
        with open(configfile, 'r') as conf:
            items = yaml.load(conf)
            for cmdk, cmdv in items["commands"].items():
                function_name = "do_%s" % cmdk
                args = cmdv
                setattr(self,function_name,
                        self.make_function(function_name, args))
            self.master = serial.Serial(port=items["serial"]["port"],
                                        baudrate=items["serial"]["baudrate"],
                                        parity=items["serial"]["parity"],
                                        stopbits=items["serial"]["stopbits"],
                                        bytesize=items["serial"]["bytesize"],
                                        timeout=items["serial"]["timeout"]
                                        )

    def make_function(self,pcommands, pargs):
        def function(f=None):
            __doc__ = pcommands
            io_args = pargs
            if len(io_args) == 0:
                print "Error excepted on input arguments"
                return
            self.send_msg(io_args)
        function.__doc__ = pcommands
        return function

    def do_closeSerial(self,args):
        if self.master.isOpen():
            self.master.close()

    def do_setLogFile(self,arg):
        #TODO:NEED TO TEST
        """Send the state logs to dump to a file"""
        try:
            self.log_file = open(os.path.expanduser(arg), 'a')
        except Exception, e:
            print False, "Exception%s" % (e)

    def do_sleep(self, args):
        """Sleep for <delay>"""
        time.sleep(int(args))

    def do_echo(self, *args):
        """Echo a string to the console"""
        print(" ".join(args))

    def do_exit(self,arg=None):
       print 'Quitting.'
       sys.exit(0)

    def do_script(self,args):
        """Run script file. Argument should be filename"""
        try:
            with open(args) as f:
                for line in f:
                    self.onecmd(line)
        except IOError:
            print "Script file not found!"

    def emptyline(self):
        pass

    def postcmd(self, stop, line):
        self.prompt = "%s > " % int((time.time()*1000) - self.start_time)

    def sync_callback(self,msg):
        """Drop msg onto return queue"""
        self._queue.put(msg)

    def async_callback(self,msg):
        #TODO: WRITE LOG
        pass

    def start(self):
        self.thread = threading.Thread(target=self.thread_function)
        self.thread.daemon = True
        self.thread.start()
        # wait for thread to start 阻塞
        self.thread_start_block.wait()

    def thread_function(self):
        self.thread_start_block.set()
        while True:
            try:
                recv = ""
                recv = self.master.read_all()
                self.master.flush()
                if recv == "" or None:
                    continue
                self._queue.put(recv)
            except serial.SerialException:
                time.sleep(0.1)

    def send_msg(self,ioargs):
        command = ""
        try:
            if self.master.isOpen():
                self.master.flushInput()
                for i in ioargs:
                    command += i
                self.master.write(bytes(command))
                self.master.flushOutput() #
                time.sleep(0.15)
                try:
                    print self._queue.get(timeout=1)
                except Queue.Empty:
                    print("Timeout waiting for response")
                    return False
            else:
                return False, 'offline'
        except Exception, e:
            print '1' ,False, str(e)

    def __del__(self):
        if self.master.isOpen():
            self.master.close()

def main():
    iocli = MyPrompt(confpath)
    if len(sys.argv) == 2:
        iocli.do_script(sys.argv[1])
        iocli.cmdloop()
    else:
        iocli.cmdloop()

if __name__ == '__main__':
    print "------IOCLI Start--------"
    import datetime, time
    print datetime.datetime.now()
    main()

