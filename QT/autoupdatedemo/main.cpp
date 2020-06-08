#include "mainwindow.h"
#include <string>
#include <QApplication>
#include <iostream>
#include <qobject.h>
#include <opencv2/opencv.hpp>
using namespace std;
using namespace cv;
int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    QString s = "ss";
    int aa = 10;
//    qDebug("output is %s",qPrintable(s));
//    qDebug("output is 2 %s",s.toStdString().data());
//    qDebug()<<"s"<< s<<endl;
    //qDebug("out is  %s",s);
    std::cout<<s.toStdString()<<endl;
    //connect(&MainWindow,&MainWindow::print_signal,&MainWindow,&MainWindow::my_print);
    QObject::connect(&w,&MainWindow::print_signal,&w,&MainWindow::my_print);





    w.show();
    return a.exec();
}
