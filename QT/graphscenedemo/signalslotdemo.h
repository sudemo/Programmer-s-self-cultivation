#ifndef SIGALSLOTDEMO_H
#define SIGALSLOTDEMO_H
#include <QObject>
#include<QDebug>

class Newspaper : public QObject
{
    Q_OBJECT
public:
    Newspaper(const QString & name):m_name(name){}//初始化参数 name

    void send();

signals:
    void newPaper(const QString &name );
private:
    QString m_name;


};

class myReader:public QObject
{
    Q_OBJECT
public:
//    myReader(){}
    void receiveNewspaper(const QString &name);

    myReader *rd ;

};




#endif // SIGALSLOTDEMO_H
