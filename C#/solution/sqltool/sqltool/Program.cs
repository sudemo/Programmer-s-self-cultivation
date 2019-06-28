using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nsCommoner;
using System.Data.SQLite;
namespace sqltoolkit
{
    
    class Program
    {
       
        static void Main(string[] args)
        {
            //CSqliteWrapper._S_Init(path);
            //CSqliteWrapper._S_ExecuteSql("hello");

            sqlmethod a = new sqlmethod();
            //a.writesql();
            a.writesqlbytran();
            a.querysql();
        }
    }
}
