#include "mainwindow.h"
#include <QApplication>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();

    cv::Mat image = cv::imread("d://2.jpg",1);
    cv::namedWindow("show");
    cv::imshow("show",image);

    return a.exec();
}
