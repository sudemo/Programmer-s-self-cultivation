#ifndef LIBINTERFACE_H
#define LIBINTERFACE_H


#include <QObject>
#include <QString>


class LibInterFace
{
public:
    virtual ~LibInterFace() {}
//     QString description() = 0;
    virtual int fddd(int,int) =0 ;//注意虚参数的参数列表

};

#define LIBINTERFACE_IID "thisismyLibInterFace"
Q_DECLARE_INTERFACE(LibInterFace, LIBINTERFACE_IID)

#endif // LIBINTERFACE_H
