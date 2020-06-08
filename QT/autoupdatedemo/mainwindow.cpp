#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    //connect(&MainWindow,&MainWindow.print_signal,&MainWindow,&MainWindow.my_print);
    //注意格式 ::，发送接收者的指针
    //QObject::connect(this,&MainWindow::print_signal,this,&MainWindow::my_print);
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_spinBox_valueChanged(int arg1)
{
    emit print_signal();
}

void MainWindow::my_print()
{
    qDebug("it's ok ,triggered");
}


