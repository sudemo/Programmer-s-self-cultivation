using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
struct Books
{
    public string title;
    public string author;
    public string subject;
    public int  book_id;

    public void disp()
    {
        Console.WriteLine("title:{0}",title);
        Console.WriteLine("author:{0}",author);

    }

};

    public class Program
    {
        static void Main(string[] args)
        {
        //结构的实例用法
        //类是引用类型，结构是值类型。
        //结构不支持继承。
        //结构不能声明默认的构造函数。
        Books Book1;
        Books Book2;
        Books book3 = new Books();
        Book1.title = "c primmer";
        Book1.author = "demo";
        Book1.book_id = 32;
        Book1.subject = "program";

        Book2.title = "a";
        Book2.author = "demo";
        Book2.subject = "c#";
        Book2.book_id = 1213;
        Console.WriteLine("plz input");
        string title = Console.ReadLine();
        string author = Console.ReadLine();
        book3.author =  author;
        book3.title = title;

        book3.disp();
        //打印信息
        Console.WriteLine("{0};{1};{2}",Book1.book_id,Book1.title,Book1.subject);
        Console.WriteLine("{0},{1}",Book2.title,Book2.author);
        Console.ReadKey();

        }
    }

