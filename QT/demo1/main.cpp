#include "mainwindow.h"
#include <QApplication>
#include <QPushButton>
int main(int argc, char *argv[])
{
    QApplication a(argc, argv); //定义了一个 QApplication 类的实例 a，就是应用程序对象，只能有一个
    MainWindow w;   //定义了一个 MainWidow 类的对象变量or实例 w，
    w.show();
    QPushButton ab;
    ab.setText("ddd");
    ab.setParent(&w);
    ab.show();
    QPushButton abc(&w);
    abc.setText("ss");
    abc.show();



    return a.exec(); //启动应用程序的执行，开始应用程序的消息循环和事件处理，即等待用户操作，一直运行
}
