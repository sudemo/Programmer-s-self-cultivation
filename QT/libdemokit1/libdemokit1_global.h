#ifndef LIBDEMOKIT1_GLOBAL_H
#define LIBDEMOKIT1_GLOBAL_H

#include <QtCore/qglobal.h>

#if defined(LIBDEMOKIT1_LIBRARY)
#  define LIBDEMOKIT1_EXPORT Q_DECL_EXPORT
#else
#  define LIBDEMOKIT1_EXPORT Q_DECL_IMPORT
#endif

#endif // LIBDEMOKIT1_GLOBAL_H
