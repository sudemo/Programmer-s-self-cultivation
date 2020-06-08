#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <iostream>
#include <qdebug.h>
using namespace std;

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    cv::Mat M(2,2, CV_8UC3, cv::Scalar(0,0,255));
cout <<"zhe 是中文"<<endl;
//qDebug()<<"中文";
    //cout<<M<<endl;
}

MainWindow::~MainWindow()
{
    delete ui;
}

