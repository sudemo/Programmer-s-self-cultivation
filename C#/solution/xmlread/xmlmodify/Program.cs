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
        public void Create(string xmlPath)
        {
            XDocument xDoc = XDocument.Load(xmlPath);
            XElement xElement = xDoc.Element("BookStore");
            xElement.Add(new XElement("Test", new XAttribute("Name", "Zery")));
            xDoc.Save(xmlPath);
        }
        static void Main(string[] args)
        {
        }
    }
}
