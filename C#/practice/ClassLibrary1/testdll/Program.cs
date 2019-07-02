using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
namespace testdll
{
    class Program
    {
        static void Main()
        {
            Mat src1 = Cv2.ImRead("d:/2.jpg", ImreadModes.Grayscale);
            Mat dst = new Mat();
            /* 
data:  需要自动聚类的数据，一般是一个Mat。浮点型的矩阵，每行为一个样本。
k: 取成几类，比较关键的一个参数。
bestLabels:  返回的类别标记,整型数字。
criteria: 算法结束的标准，获取期望精度的迭代最大次数
attempts:  判断某个样本为某个类的最少聚类次数，比如值为3时，则某个样本聚类3次都为同一个类，则确定下来。
flags:  确定簇心的计算方式。有三个值可选：KMEANS_RANDOM_CENTERS 表示随机初始化簇心。KMEANS_PP_CENTERS 表示用kmeans++算法来初始化簇心（没用过），KMEANS_USE_INITIAL_LABELS 表示第一次聚类时用用户给定的值初始化聚类，后面几次的聚类，则自动确定簇心。
centers: 用来初始化簇心的。与前一个flags参数的选择有关。如果选择KMEANS_RANDOM_CENTERS随机初始化簇心，则这个参数可省略。
             */
            //Mat getLabels() { return labels; };
           
            Mat samples = new Mat(new IntPtr (MatType.CV_64F));
            Cv2.Kmeans(src1, k: 2,bestLabels:samples, criteria:new TermCriteria(CriteriaType.MaxIter, 10, 0.1), attempts: 2, flags:KMeansFlags.RandomCenters);
            //Cv2.Canny(src1, dst, 30, 30);
            //using (new Window("src image", src))
           Cv2.ImShow("dst image", dst);           
                Cv2.WaitKey();
            
        }
    }
}
