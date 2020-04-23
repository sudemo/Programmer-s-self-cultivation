'''
# @Time    : 2020/4/23 20:27
# @Author  : Neo
# @File    : pyqtdemo1.py
'''

import sys
from PyQt5 import QtWidgets, QtCore

app = QtWidgets.QApplication(sys.argv)
widget = QtWidgets.QWidget()
widget.resize(400, 100)
widget.setWindowTitle("This is a demo for PyQt Widget.")
widget.show()
exit(app.exec_())
