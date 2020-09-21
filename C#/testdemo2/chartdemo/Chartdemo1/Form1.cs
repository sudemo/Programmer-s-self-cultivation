using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Chartdemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> x = new List<int>() { 1, 2, 3, 4 };
            List<int> y1 = new List<int>() { 10,20,60,31};
            List<int> y2 = new List<int>() { 20, 20, 30, 31 };
           
            //chart1.Series["示例1"].Points.DataBindXY(x, y1);
            chart1.Series["Series2"].Points.DataBindXY(x,y2);

           // chart1.Series.Add(new Series()); //添加一个图表序列
           // ct.Series[0].XValueType = ChartValueType.String; //设置X轴上的值类型
            chart1.Series[0].Label = "#VAL"; //设置显示X Y的值
            chart1.Series[0].ToolTip = "#VALX列\r#VAL"; //鼠标移动到对应点显示数值
            //chart1.Titles = "";
            //chart1.Series[0].ChartArea = chart1.ChartAreas[0].Name; //设置图表背景框ChartArea 
            //chart1.Series[0].ChartType = SeriesChartType.Line; //图类型(折线)
            //chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series[0].Points.DataBindXY(x, y1); //添加数据


            Series newSeries = new Series("SeriesDemo");
            newSeries.ChartType = SeriesChartType.Line;
            newSeries.BorderWidth = 2;
            newSeries.Color = Color.OrangeRed;
            newSeries.XValueType = ChartValueType.DateTime;
            chart1.Series.Add(newSeries);
            chart1.Series["SeriesDemo"].Points.DataBindXY(x, y2);
            chart1.Series[2].ChartType = SeriesChartType.Line;

        }
    }
}
