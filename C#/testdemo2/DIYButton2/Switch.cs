using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIYButton2
{
    public delegate void StatusChangeDelegate1();//委托
    public partial class Switch : UserControl
    {
        public StatusChangeDelegate1 OnStatusChangedDel2;//委托变量

        public static Class4DelegateDeclare c4d ;

        //private bool isCheck = true;

        //public bool IsCheckChanged
        //{
        //    get { return isCheck; }

        //    set
        //    {
        //        if (value !=isCheck)
        //        {
        //            ChangeTrigered();
        //        }
        //         //isCheck =value;
        //    }
        //}

        public Switch()
        {
            InitializeComponent();
            //InitDelegate();


        }


       //protected override void OnPaint(PaintEventArgs e)
       //{

       //     //true is green color ,false is grey
       //     pictureBox1.Image = isCheck ? Properties.Resources.kaiguanguan_1 : Properties.Resources.soff;
       // }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{
        //    //isCheck = !isCheck;
        //    //this.Refresh();
        //    //IsCheckChanged = !isCheck;
        //}

        public void InitDelegate()
        {
            //Class4DelegateDeclare c4d = new Class4DelegateDeclare();
            //OnStatusChangedDel2 += SlotMethod;

        }
        
        /// <summary>
        /// 在此次，配置新按钮点击的事件
        /// </summary>
        public void SlotMethod()
        {
            MessageBox.Show("1W");
        }


        //触发函数
        public void ChangeTrigered()
        {
            if (OnStatusChangedDel2 != null)
            {
                OnStatusChangedDel2();
            }
            else { MessageBox.Show("Test");}
           // c4d.OnStatusChangedDel?.Invoke();
        }

    }
}
