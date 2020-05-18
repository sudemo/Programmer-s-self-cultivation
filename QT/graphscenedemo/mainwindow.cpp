#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <signalslotdemo.h>
#include <QObject>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
ui->graphicsView->setScene(&scene);
scene.addEllipse(120,120,150,150,QPen(QBrush(Qt::Dense7Pattern),3));//画圆
scene.addLine(22.22,120,420,120,QPen(QBrush(Qt::SolidPattern),2));
scene.addRect(-100,100,120,123);
/*QPixmap six = (100,100,100,100);
scene.addPixmap(six);
QPushButton *button = new QPushButton(this);
button->setText("hello");
button->setVisible(true);
connect(QPushButton,SIGNAL(pressed()),this,SLOT(onAction()));*/

//my signal slot
QString ss ="new paper";
//Newspaper np (ss);
auto *np =new Newspaper(ss);
auto *mr = new myReader() ;
//QObject::connect(np,&Newspaper::newPaper,mr，&myReader::receiveNewspaper);
//connect(np,&Newspaper::newpaper,mr,&myReader::receive_new_paper);
connect(np,&Newspaper::newPaper_plus,mr,&myReader::receiveNewspaperWithparam);
//np->send();
np->send_plus();
}



MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_pushButton_pressed()
{
    qDebug()<<"this is a slot";
    ui->pushButton->setText("welcome!");
}
