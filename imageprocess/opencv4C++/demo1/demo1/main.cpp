
#include "opencv2/highgui/highgui.hpp"
using namespace cv;
int main(int argc, char** argv)
{
	Mat img = imread("d:\\lena1.jpg", -1); //ע�⣺·�������á�\\��,���ǡ�\����
	if (img.empty()) return -1;
	namedWindow("����ͼƬ", cv::WINDOW_AUTOSIZE);
	imshow("����ͼƬ", img);
	waitKey(0);
	destroyWindow("����ͼƬ");
}
