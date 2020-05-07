#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QWidget>
#include <QFileDialog>


#include <opencv2/core/core.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgcodecs/imgcodecs.hpp>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::on_pushButton_pressed()
{
    QString filename = QFileDialog::getOpenFileName(this,
                                                    "open file",
                                                    QDir::currentPath(),
                                                    "Image(*.jpg)");
//if (QFile::exists(filename))
//{
////    ui->inputLineEdit.setText(filename);
//    ui->lineEdit->setText(filename);

//}
    if (!filename.isEmpty())
    {
        ui->lineEdit->setText(filename);
        using namespace cv;
        Mat inputImg,outImg;
        inputImg = imread(ui->lineEdit->text().toStdString());
        if (ui->radioButton->isChecked())
            cv::medianBlur(inputImg,outImg,(5,5));
            cv::imshow("out",outImg);

    }



}

//void MainWindow::on_pushButton_clicked()
//{
//    ui->lineEdit->setText("clicked");

//}


