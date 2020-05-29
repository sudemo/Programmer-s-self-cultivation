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
//auto *np =new Newspaper();
//auto *mr = new myReader() ;
Newspaper np;
myReader mr;
//关于带参数的信号的问题
//void (Newspaper:: *newPaper_plus_new2)() = &Newspaper::newPaper_plus;
//void (Newspaper:: *newPaper_plus_new)(QString) = &Newspaper::newPaper_plus;
//void (myReader:: *nslot)(QString) = &myReader::receiveNewspaperWithparam;
//void (myReader:: *nslot2)() = &myReader::receiveNewspaperWithparam;
//connect(np,newPaper_plus_new,mr,nslot);
//void(SubWidget::*backSigna2)(QString) = &SubWidget::backSignal;
//void (Newspaper::newPaper_plus)() =&Newspaper::newPaper_plus;
//void (myReader:: *rece)(QString) = &myReader::receiveNewspaperWithparam;
//qobject 这句提示mr未声明，注意mr后面的逗号是中文格式的
QObject::connect(&np,&Newspaper::newpaper,&mr,&myReader::receive_new_paper);
//connect(np,&Newspaper::newpaper,mr,&myReader::receive_new_paper);
//下面的是带参数的 信号槽连接方式，当信号槽有重载的时候下面的失效(已经修改)
//connect(np,newPaper_plus_new,mr,rece);
//connect(np,static_cast<void (&Newspaper::*)(QString)>(&Newspaper::newPaper_plus),mr,&myReader::receiveNewspaperWithparam);
//np->send();
//np->send_plus();
np.send();
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
