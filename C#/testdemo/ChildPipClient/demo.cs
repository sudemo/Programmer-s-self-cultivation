using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class PipeClient1
{
    public static void Client()
    {

        using (NamedPipeClientStream pipeClient =
            new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut))
        {

            // Connect to the pipe or wait until the pipe is available.
            Console.Write("Attempting to connect to pipe...");
            pipeClient.Connect();

            Console.WriteLine("Connected to pipe.");
            Console.WriteLine("There are currently {0} pipe server instances open.",
               pipeClient.NumberOfServerInstances);
            StreamReader sr = new StreamReader(pipeClient);
            StreamWriter sw = new StreamWriter(pipeClient);
            sw.AutoFlush = true;
            while (true)
            {
               
                try
                {
                    
                    // Display the read text to the console
                    

                    sw.WriteLine("-----start-----");
                    //sw.Flush();
                    Thread.Sleep(100);
                    //string temp;
                    //while ((temp = sr.ReadLine()) != null)  //在管道中使用注意fifo 会被堵塞住
                    //{
                    //    Console.WriteLine("Received from server: {0}", temp);
                    //    //sw.WriteLine(temp);

                    //    //    //sw.Flush();
                    //    }
                    }



                 catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
        }
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }



}