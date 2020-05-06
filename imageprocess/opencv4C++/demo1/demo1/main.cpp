
#include "opencv2/highgui/highgui.hpp"
using namespace cv;
int main(int argc, char** argv)
{
	Mat img = imread("d:\\lena1.jpg", -1); //注意：路径里面用‘\\’,不是‘\’。
	if (img.empty()) return -1;
	namedWindow("测试图片", cv::WINDOW_AUTOSIZE);
	imshow("测试图片", img);
	waitKey(0);
	destroyWindow("测试图片");
}
