using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dongle4Sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            qttongle qt = new qttongle();
            qt.callDongleInit('1');

        }
    }
}
