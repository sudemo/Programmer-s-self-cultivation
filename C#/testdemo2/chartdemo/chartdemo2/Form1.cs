using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Threading;

namespace chartdemo2
{


    public partial class Form1 : Form
    {

        private Thread addDataRunnerThread;
        private Random rand = new Random();
        //private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public delegate void AddDataDelegate(); //定义一个委托
        public AddDataDelegate addDataDel;   //定义一个委托变量
        public Form1()
        {
            InitializeComponent();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //    List<int> x = new List<int>() { 1, 2, 3, 4 };
        //    List<int> y1 = new List<int>() { 100, 20, 60, 31 };
        //    List<int> y2 = new List<int>() { 200, 20, 30, 31 };

        //    //chart1.Series["示例1"].Points.DataBindXY(x, y1);
        //    //chart1.Series[0].Points.DataBindXY(x, y2);
            
        //}

    

    


    private void Form1_Load(object sender, System.EventArgs e)
    {

        // create the Adding Data Thread but do not start until start button clicked
        ThreadStart addDataThreadStart = new ThreadStart(AddDataThreadLoop);
        addDataRunnerThread = new Thread(addDataThreadStart);
        addDataRunnerThread.IsBackground = true; //后台
                                                 // create a delegate for adding data
        //addDataDel += new AddDataDelegate(AddData);  //注册一个方法，初始化一个委托变量
        addDataDel += AddData;//另一种初始化方法
    }

    private void startTrending_Click(object sender, System.EventArgs e)
    {
        // Disable all controls on the form
        startTrendingButton.Enabled = false;
        // and only Enable the Stop button
        StopButton.Enabled = true;

        // Predefine the viewing area of the chart
        var  minValue = DateTime.Now;
        var  maxValue = minValue.AddSeconds(120);

        chart1.ChartAreas[0].AxisX.Minimum = minValue.ToOADate();
        chart1.ChartAreas[0].AxisX.Maximum = maxValue.ToOADate();

        // Reset number of series in the chart.
        chart1.Series.Clear();

        // create a line chart series
        Series newSeries = new Series("Series1");
        newSeries.ChartType = SeriesChartType.Line;
        newSeries.BorderWidth = 2;
        newSeries.Color = Color.OrangeRed;
        newSeries.XValueType = ChartValueType.DateTime;
        chart1.Series.Add(newSeries);


        // start worker threads.
        if (addDataRunnerThread.IsAlive == true)
        {
            addDataRunnerThread.Resume();
        }
        else
        {
            addDataRunnerThread.Start();
        }

    }

        [Obsolete]  // shawanyi 
        private void stopTrending_Click(object sender, System.EventArgs e)
    {
        if (addDataRunnerThread.IsAlive == true)
        {
            addDataRunnerThread.Suspend();
        }

            // Enable all controls on the form
            startTrendingButton.Enabled = true;
            // and only Disable the Stop button
            StopButton.Enabled = false;
    }

    /// Main loop for the thread that adds data to the chart.
    /// The main purpose of this function is to Invoke AddData
    /// function every 1000ms (1 second).
    private void AddDataThreadLoop()
    {
        while (true)
        {
            chart1.Invoke(addDataDel);

            Thread.Sleep(100);
        }
    }

    public void AddData()
    {
        DateTime timeStamp = DateTime.Now;

        foreach (Series ptSeries in chart1.Series)
        {
            AddNewPoint(timeStamp, ptSeries);
        }
    }

    /// The AddNewPoint function is called for each series in the chart when
    /// new points need to be added.  The new point will be placed at specified
    /// X axis (Date/Time) position with a Y value in a range +/- 1 from the previous
    /// data point's Y value, and not smaller than zero.
    public void AddNewPoint(DateTime timeStamp, System.Windows.Forms.DataVisualization.Charting.Series ptSeries)
    {
        double newVal = 0;

        if (ptSeries.Points.Count > 0)
        {
            newVal = ptSeries.Points[ptSeries.Points.Count - 1].YValues[0] + ((rand.NextDouble() * 2) - 1);
        }

        if (newVal < 0)
            newVal = 0;

        // Add new data point to its series.
        ptSeries.Points.AddXY(timeStamp.ToOADate(), rand.Next(10, 20));

        // remove all points from the source series older than 1.5 minutes.
        double removeBefore = timeStamp.AddSeconds((double)(90) * (-1)).ToOADate();
        //remove oldest values to maintain a constant number of data points
        while (ptSeries.Points[0].XValue < removeBefore)
        {
            ptSeries.Points.RemoveAt(0);
        }

        chart1.ChartAreas[0].AxisX.Minimum = ptSeries.Points[0].XValue;
        chart1.ChartAreas[0].AxisX.Maximum = DateTime.FromOADate(ptSeries.Points[0].XValue).AddMinutes(2).ToOADate();

        chart1.Invalidate();
    }
       

    }
}
