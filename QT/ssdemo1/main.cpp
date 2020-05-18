#include <QCoreApplication>
#include "signaldemo.h"
#include "slotdemo.h"
#include <QObject>
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
    void(signaldemo:: *vcp)() = &(signaldemo::value_changed);
    void(signaldemo:: *vcp2)(QString) = &(signaldemo::value_changed);
    void(slotdemo:: *nslot2)(QString) = &(slotdemo::slotfunc);
    void(slotdemo:: *nslot1)() = &(slotdemo::slotfunc);
//    QObject::connect(&sd,&signaldemo::value_changed,st,&slotdemo::slotfunc);  //注意是否为信号和槽函数
    QObject::connect(&sd,vcp2,st,nslot2);
    QObject::connect(&sd,vcp,st,nslot1);
    //    QObject::connect(&sd,&signaldemo::value_changed,&st,&slotdemo::slotfunc);
    //Sleep(1000);
    sd.senddd();
    return a.exec();
}
