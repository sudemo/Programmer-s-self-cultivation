#include "signalslotdemo.h"

//Newspaper::~Newspaper(){};

//void Newspaper::send_plus()
//{
//    emit newPaper_plus(m_name);
//}
void Newspaper::send()
{
    emit newpaper();
}

//this is slot
myReader::myReader()
{
    qDebug()<<"this is constructor";
}
void myReader::receive_new_paper()
{
    qDebug()<<"news come";
}
//void  myReader::receiveNewspaperWithparam(QString name)
//{
//    qDebug()<<"Receive new NewsPaper:"<<name;
//}
//void  myReader::receiveNewspaperWithparam()
//{
//    qDebug()<<"Receive new NewsPaper:None"<<endl;
//}
