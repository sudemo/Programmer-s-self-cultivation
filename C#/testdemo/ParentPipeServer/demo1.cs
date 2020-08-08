using System;
using System.Dynamic;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class PipeServer1
{

    public static readonly NamedPipeServerStream SpipeServer;
    public static StreamWriter sw;
    public static StreamReader sr;
    
    static object locker = new object();
    public static NamedPipeServerStream getins()
    {

        if (SpipeServer == null)
            lock (locker)
            {
                if (SpipeServer == null)
                { 
                    return new NamedPipeServerStream("testpipe", PipeDirection.InOut,2);
                }
            }

         return SpipeServer;

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


    public static void SendTH()
    {
        var pserv = getins();
        Console.WriteLine("NamedPipeServerStream object created.");
        // Wait for a client to connect
        Console.Write("Waiting for client connection...");
        pserv.WaitForConnection();
        Console.WriteLine("Client connected.");
        sw = new StreamWriter(pserv);
        //sr = new StreamReader(pipeServer);

        while (true)
        {
            Thread.Sleep(100);
            try
            {
                // Read user input and send that to the client process.


               // sw.AutoFlush = true;
               // Console.Write("Enter text: ");
                sw.WriteLine("hllllleo");
                sw.Flush();
                //string s = sr.ReadLine();
                //if (s != null)
                //{
                //    Console.WriteLine("receive from client:" + s);
                //}
            
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
                pserv.Close();
                sw.Close();
                pserv.Dispose();
                break;
            }
        }

    }

    public static void RexTH()
    {

        var pserv = getins();

        Console.WriteLine("NamedPipeServerStream object created.");
        // Wait for a client to connect
        Console.Write("Waiting for client connection...");
        pserv.WaitForConnection();
        Console.WriteLine("Client connected.");
       // sw = new StreamWriter(pipeServer);
        sr = new StreamReader(pserv);

        while (true)
        {
            try
            {
                // Read user input and send that to the client process.


             //   sw.AutoFlush = true;
             //   Console.Write("Enter text: ");
             //   sw.WriteLine(Console.ReadLine());
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
}