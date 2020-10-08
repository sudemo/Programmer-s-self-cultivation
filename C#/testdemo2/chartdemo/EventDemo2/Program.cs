using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList path = new ArrayList() { "C:\\Users\\Neo\\Desktop\\bat" };
            //FileChange fc = new FileChange();
            while (true)
            {
                Thread.Sleep(3000);
                FileChange.Run(path);
                //Console.ReadKey();
            }
        }
    }

    public class FileChange
    {
       
        public static void Run(ArrayList path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            SlotMethods sm = new SlotMethods();
            foreach (string s in path)
            {

                watcher.Path = s;//@"d:DownLoads";//args[1];

                watcher.NotifyFilter = NotifyFilters.LastWrite;
                //| NotifyFilters.FileName | NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Changed += new FileSystemEventHandler(sm.OnChanged);
                watcher.Created += new FileSystemEventHandler(sm.OnCreated);
                watcher.Deleted += new FileSystemEventHandler(sm.OnDeleted);
                watcher.Renamed += new RenamedEventHandler(sm.OnChanged);

                // Begin watching.
                watcher.EnableRaisingEvents = true;

            }
        }
    }
    public class SlotMethods
    {
        public void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("changed "+e.ToString()+source.ToString());
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
       
       
    }
}
