#include "signaldemo.h"

signaldemo::signaldemo()
{

}

void signaldemo::senddd()
{
    emit value_changed();

}
