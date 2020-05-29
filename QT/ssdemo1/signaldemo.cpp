#include "signaldemo.h"

signaldemo::signaldemo()
{
qDebug()<<'a';
}

void signaldemo::senddd()
{
    emit value_changed();
    
}

