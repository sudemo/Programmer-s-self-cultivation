using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

class PipeClient

{
    public static NamedPipeClientStream pipeClient;
    static void Main(string[] args)
    {

        PipeClient1.Client();

        // NewMethod();
        Thread pipeThread = new Thread(new ThreadStart(SendData));
        pipeThread.IsBackground = true;
       // pipeThread.Start();

        
        #region th
        //Thread reth = new Thread(read);
        //Thread wrth = new Thread(write);
        //reth.Start();
        //wrth.Start(); 
        #endregion
       // Console.Read();
       
        #region task
        //using (NamedPipeClientStream pipeClient =
        //       new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut))
        //{
        //    Console.WriteLine("connecting");
        //    pipeClient.Connect();
        //    StreamReader sr = new StreamReader(pipeClient);
        //    StreamWriter sw = new StreamWriter(pipeClient);


        //    string ss = null;

        //    new Task(() =>
        //    {
        //        while (true)
        //        {
        //            sr.ReadToEnd();
        //        }
        //    }).Start();
        //    new Task(() =>
        //    {while (true)
        //        {
        //            Console.WriteLine("hello please input :");
        //            ss = Console.ReadLine();
        //            sw.Write(ss);
        //        }
        //    }
        //    ).Start();
        //    Console.ReadKey();
        //} 
        #endregion
    }

    private static void NewMethod()
    {
        pipeClient =
              new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut);
        Console.WriteLine("connecting");
        pipeClient.Connect();
        //pipeClient.Write();
        Console.WriteLine(pipeClient.IsConnected);
        StreamReader sr = new StreamReader(pipeClient);
        StreamWriter sw = new StreamWriter(pipeClient);
        Thread.Sleep(1000);
        //sw.WriteLine("this is client!!");
        // sw.AutoFlush = true;

        new Task(() =>
        {
            while (true)
            {
                sw.AutoFlush = true;
                Console.WriteLine("INPUT :");
                var s = Console.ReadLine();
                if (s != null)

                {
                    sw.WriteLine(s);
                }
            }
        }).Start();

        new Task(() =>
        {
            while (true)
            {
                string s;
                if ((s = sr.ReadLine()) != null)
                { Console.Write(s); }
            }
        }).Start();
    }

    public static void read()
    {
        while (true)
        {
            Thread.Sleep(100);
            StreamReader sr = new StreamReader(pipeClient);
            //var s = sr.ReadLine();
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
            StreamWriter sw = new StreamWriter(pipeClient);
            sw.AutoFlush = true;
            Console.WriteLine("client input please:");
            var ss = Console.ReadLine();
            sw.WriteLine(ss);
        }

    }


    public static void demo()
    {
        using (NamedPipeClientStream pipeClient =
            new NamedPipeClientStream(".", "testpipe", PipeDirection.In))
        {

            // Connect to the pipe or wait until the pipe is available.
            Console.Write("Attempting to connect to pipe...");
            pipeClient.Connect();

            Console.WriteLine("Connected to pipe.");
            Console.WriteLine("There are currently {0} pipe server instances open.",
               pipeClient.NumberOfServerInstances);
            using (StreamReader sr = new StreamReader(pipeClient))
            {
                // Display the read text to the console
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Received from server: {0}", temp);
                }
            }
        }
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }


    private static void SendData()
    {
        byte[] bt = new byte[1024];
        try
        {
            pipeClient = new NamedPipeClientStream(".", "closePipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);
            pipeClient.Connect();
            pipeClient.Read(bt,0,1024);
            pipeClient.ReadByte();
           /* StreamWriter sw = new StreamWriter(pipeClient);
            StreamReader sr = new StreamReader(pipeClient);
            //sw.Flush();
            Console.WriteLine(pipeClient.IsConnected);
            sw.AutoFlush = true;
            sw.WriteLine("hello");
            Console.WriteLine("input ");
            string s = Console.ReadLine();
            sw.WriteLine(s);
            Console.WriteLine(s);

            sw.Flush();
            Console.ReadKey();*/
            //while (true)
            //{
            //    try
            //    {
            //        //Console.WriteLine(sr.ReadLine());
            //        //Thread.Sleep(1000);
                   
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
               
            //    //sw.Close();
            //}
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            //Log.WriteLog(ex.Message);
        }
    }

}