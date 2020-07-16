using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asyncdemo
{
    public partial class Form1 : Form
    {
        int i;
        public Form1()
        {
            InitializeComponent();
        }
        bool status = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;//默认100毫秒
            //pictureBox1.Show();
            pictureBox2.Hide();

        }


        public void switchcolor(bool status)
        {
            if (status)
            {
               // button1.ForeColor = Color.Gray;
            }
        }

        public bool state = false;
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    state = !state;//这里先把它转为true实现功能。当再次按下button时候，转化一下状态，就停止啦~~~
        //    if (state)
        //    {
        //        i = 0;
        //        timer1.Enabled = true;//计时器开始启动
        //        button1.Text = "暂停";
        //    }
        //    else
        //    {
        //        timer1.Enabled = false;//计时器关闭
        //        button1.Text = "开启";
        //    }
        //}


      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = pictureBox1.Location;
            pictureBox1.Show();
            pictureBox2.Hide();

            MessageBox.Show("2");
            Console.WriteLine('1');
        }


        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("mess ok");
            //MessageBox.Show("1");
            pictureBox2.Location = pictureBox1.Location;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("the value of i {0}", i);
                Thread.Sleep(20);
            }



            pictureBox1.Hide();
            pictureBox2.Show();
            var task = callCount();
            var res = await task;
            Console.WriteLine(res);
        }

        static void count_method()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(200);
                Console.WriteLine("异步被调用方法 执行中count loop: " + i);
            }
        }

        static async Task<string> callCount()
        {
            Task t = new Task(count_method);
            t.Start();

            int ii = 0;
            await Task.Delay(100); 
            for (int i = 0; i < 300; i++)
            {
                System.Threading.Thread.Sleep(40);
                Console.WriteLine("异步工作内容,Writing from callCount loop: " + i);
            }
            //Console.WriteLine("just before await");
            return  "123";
           
            //Console.WriteLine("异步 马上结束callCount completed");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello");
        }
    }
}
