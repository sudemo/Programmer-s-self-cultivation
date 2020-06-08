#include "mainwindow.h"
#include <opencv2/opencv.hpp>
#include <QApplication>
using namespace cv;

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;
    w.show();
    float vals[] ={1, 2, 3,
                   4, 5, 6,
                   7, 8, 9};
 /*   Matx33f m(vals);
//    Matx33d m(1,2,3,
//              4,5,6,
//              7,8,9);
    //Mat m =cv::Mat::eye(2,2,CV_8UC1);
    FileStorage fs ;
    fs.open("ex.json",FileStorage::WRITE | FileStorage::FORMAT_JSON);
    fs.write("matvalue",Mat(m));//显示的转换一下matx 到matx
    fs.release();*/




    Mat srcImage = imread("D:/lena1.jpg");
        Mat srcGrayImage;
        if (srcImage.channels() == 3)
        {
            cvtColor(srcImage,srcGrayImage,0);
        }
        else
        {
            srcImage.copyTo(srcGrayImage);
        }
        vector<KeyPoint>detectKeyPoint;
        Mat keyPointImage;

        Ptr<AgastFeatureDetector> agast = AgastFeatureDetector::create();
        agast->detect(srcGrayImage,detectKeyPoint);
        drawKeypoints(srcImage,detectKeyPoint,keyPointImage,Scalar(0,0,255),DrawMatchesFlags::DEFAULT);

        imshow("src image",srcImage);
        imshow("keyPoint",keyPointImage);

        //waitKey(0);

    return a.exec();
}
