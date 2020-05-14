#include <QCoreApplication>
#include <libinterface.h>
#include <lib2interface.h>
#include <QDebug>
#include <qpluginloader.h>
#include <QPluginLoader>
#include <opencv2/opencv.hpp>

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
//    QString filepath = qApp->applicationDirPath()+"/libkitdemo2.dll";
    QString filepath = qApp->applicationDirPath()+"/lib2.dll";
    QString file = "d:/lena.jpg";
    cv::Mat src = cv::imread(file.toStdString());
    qDebug()<<filepath;
    QPluginLoader loader(filepath);
    QObject *plugin_instance = loader.instance();
    if (plugin_instance != NULL)
    { /*auto *s = qobject_cast<LibInterFace*>(plugin_instance);
                int a=s->fddd(123,12);*/
      auto *s = qobject_cast<Lib2InterFace*>(plugin_instance);
      cv::Mat out ;
      s->opencv_method(src,out);
      cv::imshow("out",out);
      cv::waitKey(0);
        qDebug()<<"value is ";
    }
    else
    {
        qDebug()<<"error loading";
    }
                  return a.exec();
    }

