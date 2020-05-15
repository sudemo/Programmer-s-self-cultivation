#ifndef SIGNALDEMO_H
#define SIGNALDEMO_H
#include <QDebug>
#include <QObject>

class signaldemo:public QObject
{
    Q_OBJECT
public:
    signaldemo();
    void senddd();
signals:
    void value_changed();

};

#endif // SIGNALDEMO_H
