#include "teacher.h"
#include <QDebug>

teacher::teacher()
{

}

void teacher::trigger(QString food)
{
    emit hungry(food);
}
void teacher::trigger()
{
    emit hungry();
}
