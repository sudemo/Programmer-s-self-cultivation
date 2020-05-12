#ifndef LIBKITDEMO2_H
#define LIBKITDEMO2_H

#include "libkitdemo2_global.h"

#include <libinterface.h>


class LIBKITDEMO2_EXPORT Libkitdemo2:public QObject, public LibInterFace
{
    Q_OBJECT
    Q_PLUGIN_METADATA(IID "thisismyLibInterFace")
    Q_INTERFACES(LibInterFace)
public:
    Libkitdemo2();
    ~Libkitdemo2();
    int fddd(int a,int c);
};

#endif // LIBKITDEMO2_H
