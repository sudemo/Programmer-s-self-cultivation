using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xmlmodify
{
    class Program
    {
        // public void Create(string )
        static string xmlPath = @"D:\pdt_config\taskSet0304.xml";
        
        static  void Main()
        {
            XDocument xDoc = XDocument.Load(xmlPath);
            XElement root = xDoc.Root;
            //XElement ele = root.Element("setting");
            XElement root1 = new XElement("school");
            XElement book = new XElement("BOOK");
            book.SetElementValue("name", "高等数学");
            book.SetElementValue("name1", "大学英语");
            root.Add(root1);
            //获取name标签的值
            // XElement shuxing = ele.Element("name");
            //Console.WriteLine(shuxing.Value);
            //获取根元素下的所有子元素
           /* IEnumerable<XElement> enumerable = root.Elements();
            foreach (XElement item in enumerable)
            {
                foreach (XElement item1 in item.Elements())
                {
                    Console.WriteLine(item1.Name);   //输出 name  name1            
                }
                Console.WriteLine(item.Attribute("id").Value);  //输出
                
            }*/
            //Console.ReadKey();
            xDoc.Save(xmlPath);

        }
    }
}
