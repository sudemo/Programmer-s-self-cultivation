#ifndef STUDENT_H
#define STUDENT_H
#pragma execution_character_set("utf-8")
#include <QObject>

class student:public QObject
{
    Q_OBJECT
public:
    student();

public slots:
    void treat_teacher(QString foodname);
    void treat_teacher();
};

#endif // STUDENT_H
