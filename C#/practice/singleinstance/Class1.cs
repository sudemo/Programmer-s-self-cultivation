using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleinstance
{
    public class program
    {
        public string Firstname { get; set; } 
       
    }
    class pl
    {
        
        
        public static void Main()
        {
            program op = new program();
            string ss = op.Firstname;
            Console.WriteLine(ss);

        }
    }
}
