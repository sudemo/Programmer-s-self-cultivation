using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTW
{
    class Program
    {
        static void Main(string[] args)
        {
            MTWFile al = new MTWFile("test");
            al.Write("this is a test");
        }
    }
}
