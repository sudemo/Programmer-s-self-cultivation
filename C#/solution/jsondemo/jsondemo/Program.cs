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
        private static readonly string jspath = "d://Configuration//js.json";
        static void Main(string[] args)
        {
            demo1.ReadJson1();
            
            //sReadJson();
            //readjson();
        }
        
       
        public static void sReadJson()
        {
            

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
