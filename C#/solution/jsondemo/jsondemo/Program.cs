using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace jsondemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadJson("speed");
        }
        public static void ReadJson(string key)
        {
            //string jspath = "d://Configuration//Configuration.yaml";
            string jspath = "d://Configuration//js.json";
            StreamReader sr = new StreamReader(jspath);
            int a=sr.Read();
            Console.WriteLine(a);
            //Newtonsoft.Json.JsonTextReader ss = new Newtonsoft.Json.JsonTextReader(sr);
            JsonTextReader reader = new JsonTextReader(sr);
            while (reader.Read())
            {
                Console.WriteLine(reader.TokenType + "\t" + reader.ValueType + "\t" + reader.Value);
            }
            Console.Read();
            //jt.Read();
            //var value = jt.Value;
            //return 
        }
    }

}
