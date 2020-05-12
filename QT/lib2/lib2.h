#ifndef LIB2_H
#define LIB2_H
#include "lib2interface.h"
#include "lib2_global.h"
#include <opencv2/opencv.hpp>

class LIB2_EXPORT Lib2:public QObject,public Lib2InterFace
{
    Q_OBJECT
    Q_PLUGIN_METADATA(IID "thisismyLib2InterFace")
    Q_INTERFACES(Lib2InterFace)
public:
    Lib2();
    ~Lib2();
    void opencv_method(const cv::Mat &inputImage, cv::Mat &outputImage);
};

#endif // LIB2_H
