#ifndef LIBDEMOKIT1_H
#define LIBDEMOKIT1_H

#include "libdemokit1_global.h"
#include <QtPlugin>

class LIBDEMOKIT1_EXPORT Libdemokit1:QObject
{
Q_OBJECT
public:
    Libdemokit1();
    int add (int a ,int b);

};

#endif // LIBDEMOKIT1_H
