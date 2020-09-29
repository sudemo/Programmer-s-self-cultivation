using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventDemo1
{
    public partial class Form1 : Form
    {

        //public string DisplayString 
        public string DisplayString { get
                ; set; }
        public Form1()
        {
         //   Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //richTextBox1.Text = DisplayString;

            //timer1.Interval = 1000;//以毫秒为单位
            //timer1.Enabled = true;
            FileChange.Run("C:\\Users\\Neo\\Desktop\\bat");

        }



        public void OnChanged(object source, FileSystemEventArgs e)
        {
            
            Console.WriteLine("changed " + e.ToString() + source.ToString());
            this.richTextBox1.AppendText(DisplayString);
            //Program.MainForm.DisplayString = "changed";
            //Program.MainForm.richTextBox1.AppendText("changed");//onchanged 不在form中的时候的用法，会跨线程
            //Program.MainForm.Refresh();
            //文件改變後的代碼
        }

        public void OnCreated(object source, FileSystemEventArgs e)
        {
            //添加文件後的代碼
        }

        public void OnDeleted(object source, FileSystemEventArgs e)
        {
            //文件刪除後的代碼
        }

        public void OnRenamed(object source, RenamedEventArgs e)
        {
            //文件重命名後的代碼
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = DisplayString;
        }



        //timer1.Interval=3600000;//以毫秒为单位
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            //if (DisplayString != null)
            //{
            //    this.Invoke(new Action(() =>
            //    richTextBox1.AppendText("hhs")));
            //}
        }
    }

    public class FileChange
    {

        public static void Run(string  path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            //SlotMethods sm = new SlotMethods();
            
           
                watcher.Path = path;//@"d:DownLoads";//args[1];

                watcher.NotifyFilter = NotifyFilters.LastWrite;
                //| NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.txt";
            
                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(Program.MainForm.OnChanged);
                //watcher.Created += new FileSystemEventHandler(sm.OnCreated);
                //watcher.Deleted += new FileSystemEventHandler(sm.OnDeleted);
                //watcher.Renamed += new RenamedEventHandler(sm.OnChanged);

                // Begin watching.
                watcher.EnableRaisingEvents = true;

            
        }

        public static void Run(ArrayList path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            //SlotMethods sm = new SlotMethods();
            foreach (string s in path)
            {

                watcher.Path = s;//@"d:DownLoads";//args[1];

                watcher.NotifyFilter = NotifyFilters.LastWrite;
                //| NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.txt";

                // Add event handlers.
                //watcher.Changed += new FileSystemEventHandler(sm.OnChanged);
                //watcher.Created += new FileSystemEventHandler(sm.OnCreated);
                //watcher.Deleted += new FileSystemEventHandler(sm.OnDeleted);
                //watcher.Renamed += new RenamedEventHandler(sm.OnChanged);

                // Begin watching.
                watcher.EnableRaisingEvents = true;

            }
        }
    }
   
}
