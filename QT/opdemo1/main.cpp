#include <QCoreApplication>
#include <QDebug>

#include <opencv2/core/core.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/imgcodecs/imgcodecs.hpp>


int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);

//    cv::Mat image = cv::imread("d:/lena.jpg", 0);
//        if (image.empty())
//            printf("读取图片错误！");
//        // create image window named "My Image"
//        cv::namedWindow("My Image", 0);
//        // show the image on window
//        cv::imshow("My Image", image);
//        cv::waitKey(0);
    cv::Mat image = cv::imread("d://2.jpg",0);
    if (image.empty())

    cv::namedWindow("show",0);
    cv::imshow("show",image);
    cv::waitKey(0);
    return a.exec();
}
