#include <QCoreApplication>
#include "signaldemo.h"
#include "slotdemo.h"

//#include <windows.h>
int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    //qDebug()<<"starting";
    signaldemo sd ;
    //    slotdemo st;
    //    void(slotdemo::*st)= &slotdemo::slotfunc;
    //    auto  *sd = new signaldemo();
    auto *st = new slotdemo();
    QObject::connect(&sd,&signaldemo::value_changed,st,&slotdemo::slotfunc);  //注意是否为信号和槽函数
    //    QObject::connect(&sd,&signaldemo::value_changed,&st,&slotdemo::slotfunc);
    //Sleep(1000);
    sd.senddd();
    return a.exec();
}
