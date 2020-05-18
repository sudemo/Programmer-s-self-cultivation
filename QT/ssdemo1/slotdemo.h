#ifndef SLOTDEMO_H
#define SLOTDEMO_H

#include <QObject>

class slotdemo:public QObject
{
    Q_OBJECT
public:
    slotdemo();
public slots:
    void slotfunc();
    void slotfunc(QString);
};

#endif // SLOTDEMO_H
