using System;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;
using ParentPipeServer;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

class PipeServer
{
    //public static NamedPipeServerStream pserv;
    static void Main()
    {
        //namepipe.methoda();
        DuplePipe.dupledemo();

        Thread th = new Thread(DuplePipe.ReadData);
        Thread th2 = new Thread(DuplePipe.SendData);
        th.Name = "read";
        th2.Name = "send";
        th.Start();
        //th2.Start();
       // DuplePipe.SendData();
        Console.ReadKey();
    }
}