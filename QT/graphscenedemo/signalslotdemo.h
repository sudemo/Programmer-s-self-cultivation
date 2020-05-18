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
    void send_plus();
signals:

    void newpaper();
    void newPaper_plus(const QString &name );
private:
    QString m_name;


};

class myReader:public QObject
{
    Q_OBJECT
public:

    void receiveNewspaperWithparam(const QString &name);
    void receive_new_paper();


};




#endif // SIGALSLOTDEMO_H
