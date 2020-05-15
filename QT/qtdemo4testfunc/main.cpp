#include <QCoreApplication>
#include <QDir>
#include <QFileInfoList>
#include<QDebug>
//#define PLUGINS_SUBFOLDER                   "/cvplugins/"
int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

    QDir pluginsDir(qApp->applicationDirPath());// 可执行程序路径
    QDir myDir(QDir::currentPath()); //pro文件路径
//    QFileInfoList pl = pluginsDir.entryInfoList()

    //列出dir(path)目录文件下所有文件和目录信息，存储到file_list容器
    QFileInfoList pluginFiles = pluginsDir.entryInfoList( QDir::NoDotAndDotDot|QDir::Files , QDir::Name); //check path

//    qDebug("asns %d",pluginFiles);
   /* QList<QString> list;
        list << "aa" << "bb" << "cc";
    for (int i=0;i<list.size();i++)
    {
        qDebug()<<list.at(i) ;
        qDebug()<<list.value(i);
        qDebug()<<list[i]; //对于数组 list 类型，其索引方式是等效的
    }*/
//    qDebug()<<"path"<< myDir.entryList()<<endl;
//     qDebug()<<"path"<< pluginsDir.entryList();
    return a.exec();
}
