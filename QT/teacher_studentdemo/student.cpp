#include "student.h"
#include <QDebug>

student::student()
{

}

void student::treat_teacher(QString foodname)
{
    qDebug()<<"treat teacher";
//    QString ss = ;
    qDebug()<<"老师想吃什么："<<foodname;
}
void student::treat_teacher()
{
    qDebug()<<"老师想吃什么？";
}
