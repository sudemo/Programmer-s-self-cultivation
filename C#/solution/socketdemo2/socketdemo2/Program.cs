using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class GetSocket
{
    private static Socket ConnectSocket(string server, int port)
    {
        Socket s = null;
        IPHostEntry hostEntry = null;

        // Get host related information.
        hostEntry = Dns.GetHostEntry(server); //获取本地主机ip

        // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
        // an exception that occurs when the host IP Address is not compatible with the address family
        // (typical in the IPv6 case).
        foreach (IPAddress address in hostEntry.AddressList)
        {
            IPEndPoint ipe = new IPEndPoint(address, 9091);
            Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                tempSocket.Connect(ipe);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("connect server failed, ip is {0}",ipe);

            }

            if (tempSocket.Connected)
            {
                s = tempSocket;
                Console.WriteLine("connect server ok, ip is {0}", ipe);
                break;
            }
            else
            {
                continue;
            }
        }
        return s;
    }

    // This method requests the home page content for the specified server.
    private static string SocketSendReceive(string server, int port)
    {
        string request = "GET / HTTP/1.1\r\nHost: " + server +  //"GET / HTTP/1.1\r\nHost: C-NS-BU5-USER07\r\nConnection: Close\r\n\r\n"
            "\r\nConnection: Close\r\n\r\n";
        Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
        Byte[] bytesReceived = new Byte[256];
        string page = "";

        // Create a socket connection with the specified server and port.
        using (Socket s = ConnectSocket(server, port))
        {

            if (s == null)
                return ("Connection failed");

            // Send request to the server.
            s.Send(bytesSent, bytesSent.Length, 0);

            // Receive the server home page content.
            int bytes = 0;
            page = "Default HTML page on " + server + ":\r\n";

            // The following will block until the page is transmitted.
            do
            {
                bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            }
            while (bytes > 0);
            
        }

        return page;
    }

    public static void Main(string[] args)
    {
        string host;
        int port = 9091;

        if (args.Length == 0)
            // If no server name is passed as argument to this program, 
            // use the current host name as the default.
            host = Dns.GetHostName(); //获取本地主机名
        else
            host = args[0];

        string result = SocketSendReceive(host, port);
        Console.WriteLine(result);
    }
}