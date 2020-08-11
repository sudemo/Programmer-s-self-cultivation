using System;
using System.IO;
using System.IO.Pipes;
using System.Windows.Forms;

namespace NamePipedSample_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            clientdemo();
            //clientdemo1();

            Console.ReadKey();
        }

        private static void clientdemo1()
        {
            var pipeClient = new NamedPipeClientStream(".",
                        "testpipe", PipeDirection.InOut, PipeOptions.None);

            if (pipeClient.IsConnected != true) { pipeClient.Connect(); }

            StreamReader sr = new StreamReader(pipeClient);
            StreamWriter sw = new StreamWriter(pipeClient);

            string temp;
            temp = sr.ReadLine();

            if (temp == "Waiting")
            {
                try
                {
                    sw.WriteLine("Test Message");
                    sw.Flush();
                    // pipeClient.Close();
                }
                catch (Exception ex) { throw ex; }
            }
        }
        private static void clientdemo()
        {
            using (NamedPipeClientStream pipeClient =
                        new NamedPipeClientStream(".", "nps", PipeDirection.In))
            {
                pipeClient.Connect();

                using (StreamReader sr = new StreamReader(pipeClient))
                {
                    string temp;
                    while ((temp = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(temp);
                        //MessageBox.Show(string.Format("Received from server: {0}", temp));
                    }
                }
            }
        }
    }
}
