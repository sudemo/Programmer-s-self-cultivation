using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimensHelper
{
    class MainEntry
    {
        static void Main()
        {
            TCPIPClient tp = new TCPIPClient();
            tp.ConnectNet();
            byte[] msg =new byte[] { 0x03, 0x00, 0x00, 0x16, 0x11, 0xE0, 0x00, 0x00, 0x00, 0x01, 0x00, 0xC1, 0x02, 0x01, 0x00, 0xC2, 0x02, 0x01, 0x01, 0xC0, 0x01, 0x09 };
            try
            {
                tp.Client.Send(msg, msg.Length, System.Net.Sockets.SocketFlags.None);
            }
            catch (Exception re)
            {

              Console.WriteLine(re.Message);
            }
            
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
