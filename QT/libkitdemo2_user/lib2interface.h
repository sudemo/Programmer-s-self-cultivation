#ifndef LIB2INTERFACE_H
#define LIB2INTERFACE_H

#include <QObject>
#include <opencv2/opencv.hpp>

class Lib2InterFace
{
public:

    Lib2InterFace () {}
    virtual ~Lib2InterFace() {}
    virtual void opencv_method(const cv::Mat &inputImage, cv::Mat &outputImage) =0;
};

#define LIB2INTERFACE_IID "thisismyLib2InterFace"
Q_DECLARE_INTERFACE(Lib2InterFace, LIB2INTERFACE_IID)


#endif // LIB2INTERFACE_H
