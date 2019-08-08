using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jsondemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReadJson("speed");
            readjson();
        }
        public static void ReadJson(string key)
        {
            //string jspath = "d://Configuration//Configuration.yaml";
            string jspath = "d://Configuration//js.json";
            StreamReader sr = new StreamReader(jspath);
            int a=sr.Read();
            //Console.WriteLine(a);
            //Newtonsoft.Json.JsonTextReader ss = new Newtonsoft.Json.JsonTextReader(sr);
            JsonTextReader reader = new JsonTextReader(sr);
            reader.Read();
            var s = reader.Value;
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader.TokenType + "\t" + reader.ValueType + "\t" + reader.Value);
            //}
            Console.WriteLine(reader.Value);
            Console.Read();
            //jt.Read();
            //var value = jt.Value;
            //return 
        }

        public static void readjson()
        {
            string jspath = "d://Configuration//js.json";
            
            try
            {
                StreamReader sr = new StreamReader(jspath);
                JsonTextReader jst = new JsonTextReader(sr);
                JObject m_readjson = (JObject)JToken.ReadFrom(jst);
                string res = m_readjson["employees"][1]["firstName"].ToString();
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            Console.ReadKey();
        }
    }

}
