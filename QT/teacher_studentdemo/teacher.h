#ifndef TEACHER_H
#define TEACHER_H
#include <QObject>
#pragma execution_character_set("utf-8")
class teacher:public QObject

{
    Q_OBJECT
public:
    teacher();
    void trigger(QString food);
    void trigger();
signals:
    void hungry(QString arg);
    void hungry();
};

#endif // TEACHER_H
