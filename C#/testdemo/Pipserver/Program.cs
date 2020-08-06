﻿using System;
using System.IO;
using System.IO.Pipes;

namespace NamePipedSample_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut, 4);

            StreamReader sr = new StreamReader(pipeServer);
            StreamWriter sw = new StreamWriter(pipeServer);

            do
            {
                try
                {
                    pipeServer.WaitForConnection();
                    string test;
                    sw.WriteLine("Waiting");
                    sw.Flush();
                    pipeServer.WaitForPipeDrain();
                    test = sr.ReadLine();
                    Console.WriteLine(test);
                }

                catch (Exception ex) { throw ex; }

                finally
                {
                    pipeServer.WaitForPipeDrain();
                    if (pipeServer.IsConnected) { pipeServer.Disconnect(); }
                }
            } while (true);
        }
    }

}