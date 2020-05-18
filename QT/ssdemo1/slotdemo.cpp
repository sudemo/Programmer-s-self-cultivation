#include "slotdemo.h"
#include "QDebug"

slotdemo::slotdemo()
{

}
void slotdemo::slotfunc()
{
   qDebug()<<"chufa"<<endl;
}
void slotdemo::slotfunc(QString ss)
{
   qDebug()<<"chufa"<<ss;
}
