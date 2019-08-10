using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsondemo
{
    class demo1
    {
        private static readonly string jspath1 = "d://Configuration//js.json";
        public static void ReadJson()
        {
            try
            {
                StreamReader sr = new StreamReader(jspath1);
                JsonTextReader jst = new JsonTextReader(sr);
                JObject m_readjson = (JObject)JToken.ReadFrom(jst);
                string res = m_readjson["employees"][0]["firstName"].ToString();
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            Console.ReadKey();     
        }
        public static void ReadJson1()
        {

            using (StreamReader sr1 = new StreamReader(jspath1))
            {
                using (JsonTextReader jst1 = new JsonTextReader(sr1))
                {
                    //JObject m_readjson1 = (JObject)JToken.ReadFrom(jst1);
                    //string res = m_readjson1["empolyees"][0]["firstName"].ToString();
                    //Console.WriteLine(res);
                   
                    JObject m_readjson1 = (JObject)JToken.ReadFrom(jst1);
                    try
                    {
                        string res = m_readjson1["employeess"][0]["firstName"].ToString();
                        Console.WriteLine(res);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("error, plz check the json key value");
                        //throw;
                    }
                   
                   
                }
                Console.ReadKey();
            }
        }
    }
}
