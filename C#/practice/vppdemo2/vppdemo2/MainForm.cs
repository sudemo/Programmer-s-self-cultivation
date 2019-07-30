using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vppdemo2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cogDisplay1_Enter(object sender, EventArgs e)
        {
            Form1 fm1 = new Form1();
            fm1.initForm1();
        }

        private void cogDisplay1_DoubleClick(object sender, EventArgs e)
        {
            MainForm.
            Form1 fm1 = new Form1();
            fm1.initForm1();
        }

        private void display_Click(object sender, EventArgs e)
        {
            if (-1 != m_curDragCogDisplay && (CogRecordDisplay)sender == m_cogDisPlayList[m_curDragCogDisplay])
            {
                if (clickTime < FileDirOP.Instance.m_dragListBMPFile.Count)
                {

                    showHandinputImgToUI(FileDirOP.Instance.m_dragListBMPFile[clickTime]);
                    clickTime++;
                }
                else if (FileDirOP.Instance.m_dragListBMPFile.Count != 0)
                {
                    MessageBox.Show("文件已全部遍历！！");
                    FileDirOP.Instance.m_dragListBMPFile.Clear();
                    clickTime = 0;
                }
            }
        }
    }
}
