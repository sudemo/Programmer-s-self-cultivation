#include <QCoreApplication>
#include <libinterface.h>
#include <QDebug>
#include <qpluginloader.h>
#include <QPluginLoader>
int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    QString filepath = qApp->applicationDirPath()+"/libkitdemo2.dll";
    qDebug()<<filepath;
    QPluginLoader loader(filepath);
    QObject *plugin_instance = loader.instance();
    if (plugin_instance != NULL)
    { auto *s = qobject_cast<LibInterFace*>(plugin_instance);
                int a=s->fddd(123,12);
        qDebug()<<"value is "<<a;
    }
    else
    {
        qDebug()<<"error loading";
    }
                  return a.exec();
    }

