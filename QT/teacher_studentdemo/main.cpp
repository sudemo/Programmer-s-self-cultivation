#include <QCoreApplication>
#include <teacher.h>
#include <student.h>
#include <QObject>

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    //    Q_OBJECT
    student st;
    teacher th;
    //用一个函数指针指向 无参的函数（信号槽）地址
    void(teacher::*phun)() = &teacher::hungry;
    void (student::*ptreat)()=&student::treat_teacher;

    //用一个函数指针指向 有参数的函数（信号槽）地址
    void(teacher::*phun1)(QString) = &teacher::hungry;
    void (student::*ptreat1)(QString)=&student::treat_teacher;
    //    QObject::connect(&th,&teacher::hungry,&st,&student::treat_teacher); //1
    //QObject::connect(&th,&teacher::hungry,&st,&student::treat_teacher);//2
    QObject::connect(&th,phun1,&st,ptreat1);
    QString s ="带参数的 羊肉串";
    th.trigger(s);

    QObject::connect(&th,phun,&st,ptreat);
    th.trigger();


    return a.exec();
}
