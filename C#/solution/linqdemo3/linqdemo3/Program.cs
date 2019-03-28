using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqdemo3
{
    class Program //根据单词的长度分组，并将大写
    {

        static void Main(string[] args)
        {
            /* string sentence = "the quick brown fox jumps over the lazy dog";
             // Split the string into individual words to create a collection.  
             string[] words = sentence.Split(' ');

             // Using query expression syntax.  
             var query = from word in words
                         group word.ToUpper() by word.Length into gr
                         orderby gr.Key
                         select new { Length = gr.Key, Words = gr };
             Console.WriteLine(query);
             // Using method-based query syntax.  
             var query2 = words.
                 GroupBy(w => w.Length, w => w.ToUpper()).
                 Select(g => new { Length = g.Key, Words = g }).
                 OrderBy(o => o.Length);

             foreach (var obj in query)
             {
                 Console.WriteLine("Words of length {0}:", obj.Length);
                 foreach (string word in obj.Words)
                     Console.WriteLine(word);

             }
             Console.ReadKey();*/


            System.Collections.ArrayList fruits = new System.Collections.ArrayList();
            fruits.Add("mango");
            fruits.Add("apple");
            fruits.Add("lemon");

            IEnumerable<string> query =
               fruits.Cast<string>().OrderBy(fruit => fruit).Select(fruit => fruit);

            // The following code, without the cast, doesn't compile.
            //IEnumerable<string> query1 =
            //    fruits.OrderBy(fruit => fruit).Select(fruit => fruit);

            //IEnumerable<int> sequence = Enumerable.Range(0, 10);
            //var doubles = from int item in sequence
            //              select (double)item;
            //foreach (double fr in doubles)
            //{
            //    Console.Write(fr);
            //}
            foreach ( string fr in fruits)
            {
                Console.WriteLine(fr);
            }
            Console.ReadKey();
        }
    }
}
