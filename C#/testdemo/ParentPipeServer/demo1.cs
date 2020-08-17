using System;
using System.Dynamic;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class PipeServer1
{

    public static NamedPipeServerStream ParentPipeServer;
    public static NamedPipeClientStream ParentPipeClient;

    public static StreamWriter sw;
    public static StreamReader sr;

    static object locker = new object();
    public static NamedPipeServerStream getins()
    {

        if (ParentPipeServer == null)
            lock (locker)
            {
                if (ParentPipeServer == null)
                {
                    return new NamedPipeServerStream("pip1", PipeDirection.Out);
                }
            }

        return ParentPipeServer;

    }




    public static void officaldemo()
    {
        NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("testpipe", PipeDirection.InOut);
        Console.WriteLine("NamedPipeServerStream object created.");

        // Wait for a client to connect
        Console.Write("Waiting for client connection...");
        pipeServer.WaitForConnection();

        Console.WriteLine("Client connected.");
        StreamWriter sw = new StreamWriter(pipeServer);
        StreamReader sr = new StreamReader(pipeServer);
        while (true)
        {
            try
            {
                // Read user input and send that to the client process.


                sw.AutoFlush = true;
                Console.Write("Enter text: ");
                sw.WriteLine(Console.ReadLine());



                string s = sr.ReadLine();
                if (s != null)
                {
                    Console.WriteLine("receive from client:" + s);
                }
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
                break;
            }
        }

    }


    public static void SendTH(object p)
    {
        var pserv = p as NamedPipeServerStream;
        Console.WriteLine("enter send thread");

        sw = new StreamWriter(pserv);

        while (true)
        {
            Thread.Sleep(1000);
            try
            {

                //Console.Write("Rec text: ");
                //sw.WriteLine("hllllleo");
                for (int i = 0; i < 20; i++)

                {
                    sw.WriteLine(i);
                    sw.Flush();
                    pserv.WaitForPipeDrain();

                }

            }

            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
                pserv.Close();
                //sw.Close();
                pserv.Dispose();
                break;
            }
        }

    }

    public static void RexTH(object p)
    {
        //var pserv = p as NamedPipeServerStream;
        var pcl = p as NamedPipeClientStream;
        Console.WriteLine("enter receive thread");


        // sw = new StreamWriter(pipeServer);
        sr = new StreamReader(pcl);


        while (true)
        {
            try
            {

                //Thread.Sleep(1000);
                string s = sr.ReadLine();
                if (s != null)
                {

                    Console.WriteLine(" rec {0} ", s);

                }

            }

            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            //catch (IOException e)
            //{
            //    Console.WriteLine("ERROR: {0}", e.Message);
            //    break;
            //}
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
                break;
            }
        }
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }

}

class DuplePipe
{

    public static NamedPipeServerStream nps;
    public static NamedPipeClientStream npc;

    public static StreamWriter nsw;
    public static StreamReader nsr;
    public static void dupledemo()
    {
         npc = new NamedPipeClientStream(".", "np2", PipeDirection.In);
         nps = new NamedPipeServerStream("np1", PipeDirection.Out);
         nsr = new StreamReader(npc);
         nsw = new StreamWriter(nps);
        nps.WaitForConnection();
        npc.Connect();
        
        Console.WriteLine(npc.IsConnected.ToString()+ nps.IsConnected.ToString());
    }

    public static void  ReadData()
    {
        //Console.WriteLine
        //while (true)
        //{
        //    Thread.Sleep(100);
        //    string ss = nsr.ReadLine();
        //    if(ss!=null) { Console.WriteLine(ss);  }
        //    //Console.WriteLine("waiting..");
        //    continue;
        //}
        string temp;
        while ((temp = nsr.ReadLine()) != null)
        { Console.WriteLine(temp); }

    }
    public static void SendData()
    {
        nsw.AutoFlush = true;
        //Console.WriteLine
        //while (true)
        //{
        //    Thread.Sleep(100);
        //    string ss = nsr.ReadLine();
        //    if (ss != null) { Console.WriteLine(ss); }
        //}
        for (int i = 0; i < 10; i++)  
        {
            string tr = "hello" + i.ToString();
            nsw.WriteLine(tr);
            nps.WaitForPipeDrain();
        }

    }

}