#include "signalslotdemo.h"

//Newspaper::~Newspaper(){};

void Newspaper::send_plus()
{
    emit newPaper_plus(m_name);
}
void Newspaper::send()
{
    emit newpaper();
}

void myReader::receive_new_paper()
{
    qDebug()<<"news come";
}
void  myReader::receiveNewspaperWithparam(const QString &name)
{
    qDebug()<<"Receive new NewsPaper:"<<name;
}
