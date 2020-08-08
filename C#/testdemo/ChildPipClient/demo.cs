using System;
using System.IO;
using System.IO.Pipes;

class PipeClient1
{
    public static void client()
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
            while (true)
            {
                try
                {
                    StreamReader sr = new StreamReader(pipeClient);
                    StreamWriter sw = new StreamWriter(pipeClient);
                    // Display the read text to the console
                    string temp;
                    while ((temp = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("Received from server: {0}", temp);
                        sw.WriteLine(temp);

                        sw.Flush();
                    }
                }
               
                
                 catch (Exception)
                {

                    break;
                }
            }
        }
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }
}