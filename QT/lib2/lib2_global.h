#ifndef LIB2_GLOBAL_H
#define LIB2_GLOBAL_H

#include <QtCore/qglobal.h>

#if defined(LIB2_LIBRARY)
#  define LIB2_EXPORT Q_DECL_EXPORT
#else
#  define LIB2_EXPORT Q_DECL_IMPORT
#endif

#endif // LIB2_GLOBAL_H
