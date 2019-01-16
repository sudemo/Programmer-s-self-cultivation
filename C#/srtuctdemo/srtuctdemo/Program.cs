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
/*
结构和类的区别：

1、结构是值类型，它在栈中分配空间；而类是引用类型，它在堆中分配空间，栈中保存的只是引用。
2、结构类型直接存储成员数据，让其他类的数据位于对中，位于栈中的变量保存的是指向堆中数据对象的引用。
C# 中的简单类型，如int、double、bool等都是结构类型。如果需要的话，甚至可以使用结构类型结合运算符运算重载，再为 C# 语言创建出一种新的值类型来。

由于结构是值类型，并且直接存储数据，因此在一个对象的主要成员为数据且数据量不大的情况下，使用结构会带来更好的性能。

因为结构是值类型，因此在为结构分配内存，或者当结构超出了作用域被删除时，性能会非常好，因为他们将内联或者保存在堆栈中。当把一个结构类型的变量赋值给另一个结构时，对性能的影响取决于结构的大小，如果结构的数据成员非常多而且复杂，就会造成损失，接下来使用一段代码来说明这个问题。

结构和类的适用场合分析：

 1、当堆栈的空间很有限，且有大量的逻辑对象时，创建类要比创建结构好一些；
 2、对于点、矩形和颜色这样的轻量对象，假如要声明一个含有许多个颜色对象的数组，则CLR需要为每个对象分配内存，在这种情况下，使用结构的成本较低；
3、在表现抽象和多级别的对象层次时，类是最好的选择，因为结构不支持继承。
4、大多数情况下，目标类型只是含有一些数据，或者以数据为主。
*/
