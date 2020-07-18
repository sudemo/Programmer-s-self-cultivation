//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace asyncdemo
//{
//    class autoconfirm
//    {
//    }
//}
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

class autoconfirm
{
    [DllImport("User32.dll", EntryPoint = "SendMessage")]
    private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    private static extern int GetForegroundWindow();
    const int WM_CLOSE = 0x10;
    Thread thread;
    private void button1_Click(object sender, EventArgs e)
    {
        thread = new Thread(new ThreadStart(CloseMessageBox));
        thread.Start();
        MessageBox.Show("Hello World");
    }
    void CloseMessageBox()
    {
        Thread.Sleep(500);
        int handle = GetForegroundWindow();
        Thread.Sleep(2500);
        SendMessage(handle, WM_CLOSE, 0, 0);
        thread.Abort();
    }
}