using System;
using System.Windows.Forms;

namespace PortControlDemo
{
    public partial class FrmPortControl : Form
    {
        #region 字段/属性
        int[] BaudRateArr = new int[] { 9600, 115200 };
        int[] DataBitArr = new int[] { 8 };
        int[] StopBitArr = new int[] { 1, 2};
        int[] TimeoutArr = new int[] { 500, 1000, 2000, 5000, 10000 };
        object[] CheckBitArr = new object[] { "None"};
        private bool ReceiveState = false;
        private PortControlHelper pchSend;
        private PortControlHelper pchReceive;
        #endregion

        #region 方法
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitView()
        {
            cb_portNameSend.DataSource = pchSend.PortNameArr;
            cb_portNameReceive.DataSource = pchReceive.PortNameArr;
            cb_baudRate.DataSource = BaudRateArr;
            cb_dataBit.DataSource = DataBitArr;
            cb_stopBit.DataSource = StopBitArr;
            cb_checkBit.DataSource = CheckBitArr;
            cb_timeout.DataSource = TimeoutArr;
            FreshBtnState(pchSend.PortState && pchReceive.PortState);
        }

        /// <summary>
        /// 刷新按钮状态
        /// </summary>
        /// <param name="state"></param>
        private void FreshBtnState(bool state)
        {
            if (state)
            {
                Btn_open.Text = "关闭发送接收串口";
                Btn_send.Enabled = true;
                Btn_receive.Enabled = true;
            }
            else
            {
                Btn_open.Text = "打开发送接收串口";
                Btn_send.Enabled = false;
                Btn_receive.Enabled = false;
            }
        }
        #endregion

        #region 事件
        public FrmPortControl()
        {
            InitializeComponent();
            pchSend = new PortControlHelper();
            pchReceive = new PortControlHelper();
            InitView();
        }

        /// <summary>
        /// 点击 发送数据 按钮，发送文本内数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_send_Click(object sender, EventArgs e)
        {
            pchSend.SendData(tb_send.Text);
        }

        /// <summary>
        /// 点击 开始接收 按钮，开始监听串口接收入口数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_receive_Click(object sender, EventArgs e)
        {
            if (ReceiveState)
            {
                pchReceive.OnComReceiveDataHandler -= new PortControlHelper.ComReceiveDataHandler(ComReceiveData);
                Btn_receive.Text = "开始接收";
                ReceiveState = false;
            }
            else
            {

                pchReceive.OnComReceiveDataHandler += new PortControlHelper.ComReceiveDataHandler(ComReceiveData);
                Btn_receive.Text = "停止接收";
                ReceiveState = true;
            }
        }

        /// <summary>
        /// 开启或关闭 两个通信的串口，刷新按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_open_Click(object sender, EventArgs e)
        {
            if (pchSend.PortState)
            {
                pchSend.ClosePort();
                pchReceive.ClosePort();
            }
            else
            {
                pchSend.OpenPort(cb_portNameSend.Text, int.Parse(cb_baudRate.Text),
                    int.Parse(cb_dataBit.Text), int.Parse(cb_stopBit.Text),
                    int.Parse(cb_timeout.Text));
                pchReceive.OpenPort(cb_portNameReceive.Text, int.Parse(cb_baudRate.Text),
                   int.Parse(cb_dataBit.Text), int.Parse(cb_stopBit.Text),
                   int.Parse(cb_timeout.Text));

            }
            FreshBtnState(pchSend.PortState && pchReceive.PortState);
            pchReceive.OnComReceiveDataHandler += new PortControlHelper.ComReceiveDataHandler(ComReceiveData);
            Btn_receive.Text = "停止接收";
            ReceiveState = true;
        }

        /// <summary>
        /// 接收到的数据，写入文本框内
        /// </summary>
        /// <param name="data"></param>
        private void ComReceiveData(string data)
        {
            this.Invoke(new EventHandler(delegate
            {
                tb_receive.AppendText($"接收：{data}\n");
            }));
        }
        #endregion

        
    }
}
