#include "slotdemo.h"
#include "QDebug"

slotdemo::slotdemo()
{

}
void slotdemo::slotfunc()
{
  // qDebug()<<"槽函数"<<endl;
    QString str = QStringLiteral("你好");
    qDebug() << QString(QStringLiteral("就是这么嗲！%1")).arg(str).toUtf8().data();
}
//void slotdemo::slotfunc(QString ss)
//{
//   qDebug()<<"chufa"<<ss;
//}
