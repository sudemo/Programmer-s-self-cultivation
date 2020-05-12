#include "lib2.h"
#include <QDebug>
#include<opencv2/opencv.hpp>

Lib2::Lib2()
{
   qDebug()<<"this is the constructor of lib2";
}
Lib2::~Lib2(){}

void Lib2::opencv_method(const cv::Mat &inputImage, cv::Mat &outputImage)
{
    cv::cvtColor(inputImage,outputImage,cv::COLOR_BGR2GRAY);
}
