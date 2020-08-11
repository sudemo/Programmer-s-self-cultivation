using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParentPipeServer
{
    class namepipe
    {
        public static NamedPipeServerStream pipeServer;
        public static void methoda()
        {
            pipeServer =
            new NamedPipeServerStream("testpipe", PipeDirection.InOut);

            Console.WriteLine("waiting 4 connecting");
            pipeServer.WaitForConnection();
            Console.WriteLine(pipeServer.IsConnected);
            StreamReader sr = new StreamReader(pipeServer);
            StreamWriter sw = new StreamWriter(pipeServer);
            string s;
            sw.AutoFlush = true;
            sw.WriteLine("hello this is serve");

            //new Task
            new Task(() =>
            {

                while (true)
                {
                    s = sr.ReadLine();
                    if (s != null)
                    {
                        Console.WriteLine(s);
                    }
                }

                //while ((s = sr.ReadLine()) != null)
                //{ Console.Write(s); }
            }
            ).Start();

            //Thread reth = new Thread(read);
            //Thread wrth = new Thread(write);
            //reth.Start();
            //reth.Name = "re";
            //wrth.Name ="wr";
            //wrth.Start();
            //string ss = null;
            Console.ReadLine();
            #region MyRegion
            /*

                            new Task(() =>
                            {
                                while (true)
                                {
                                    sr.ReadToEnd();
                                }
                            }).Start();
                            new Task(() =>
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("hello please input :");
                                            ss = Console.ReadLine();
                                            Console.Write(ss);
                                        }
                                    }
                                    ).Start();
            */
            #endregion
        }



        public static void ReceiveDataFromClient()
        {
            while (true)
            {
                try
                {
                    pipeServer = new NamedPipeServerStream("closePipe", PipeDirection.InOut, 2);
                    pipeServer.WaitForConnection(); //Waiting
                    StreamReader sr = new StreamReader(pipeServer);
                    StreamWriter sw = new StreamWriter(pipeServer);
                    while (true)
                    {
                        string s = Console.ReadLine();
                        var sb =System.Text.Encoding.Default.GetBytes(s);
                        foreach (var b in sb)
                        {
                            pipeServer.WriteByte(b);
                        }

                        string recData = sr.ReadLine();
                        if (recData != null)
                        { Console.WriteLine(recData); }
                        if (recData == "Exit")
                        {
                            //Log.WriteLog("Pipe Exit.", _logFile);

                            //ExitApplication();
                            break;
                        }
                        //Thread.Sleep(1000);
                       // Console.WriteLine("please input :");
                       // string s = Console.ReadLine();
                       // sw.WriteLine(s);
                    }
                    
                    //Console.WriteLine("out");
                    //sr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                   // Log.WriteLog(ex.Message, _logFile);
                }
            }
        }



        public static void read()
        {
            while (true)
            {

                Thread.Sleep(100);
                StreamReader sr = new StreamReader(pipeServer);
                string s;
                while ((s = sr.ReadLine()) != null)
                { Console.Write(s); }
            }
        }
        public static void write()
        {
            while (true)
            {
                Thread.Sleep(100);

                StreamWriter sw = new StreamWriter(pipeServer);
                sw.AutoFlush = true;
                Console.WriteLine("serve input please:");
                var ss = Console.ReadLine();
                sw.WriteLine(ss);
            }

        }
    }

}