using BooksOdataClient.BooksReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksOdataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
            Console.ReadLine();
        }

        private static void Run()
        {
            Container container = new Container(new Uri("http://localhost:4065/odata/"));
            var q = from b in container.BooksOdata
                    where b.Publisher == "Wrox Press"
                    select b;

            foreach (var b in q)
            {
                Console.WriteLine($"{b.Title} {b.Publisher}");
            }
        }
    }
}
