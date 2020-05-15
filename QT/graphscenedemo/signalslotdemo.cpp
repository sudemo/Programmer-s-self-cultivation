#include "signalslotdemo.h"

//Newspaper::~Newspaper(){};

void Newspaper::send()
{
    emit newPaper(m_name);
}


void  myReader::receiveNewspaper(const QString &name)
{
    qDebug()<<"Receive new NewsPaper:"<<name;
}
