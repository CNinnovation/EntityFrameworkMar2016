using DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    static class StringExtensions
    {
        public static void Foo(this string s, int x)
        {
            Console.WriteLine($"s: {s}, x: {x}");
        }
    }

    static class CollectionExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Where1<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // LinqQuery();
            // LinqMethodSyntax();
            // GroupingSample();
            // UseMyExtensionMethod();

            // ExpressionSample();
            CompoundFrom();

            string s = "sample";
            s.Foo(42);
        }

        private static void CompoundFrom()
        {
            var q = from r in Formula1.GetChampions()
                    from c in r.Cars
                    where c == "Ferrari"
                    select r;


            foreach (var r in q)
            {
                Console.WriteLine($"{r.FirstName} {r.LastName}");
            }
        }

        private static void ExpressionSample()
        {
            var niki = Formula1.GetChampions().Where(r => r.FirstName == "Niki").FirstOrDefault();

            Expression<Func<Racer, bool>> racerFromAustria = r => r.Country == "Austria";
            bool result = racerFromAustria.Compile()(niki);
        }

        private static void UseMyExtensionMethod()
        {
            var austrianRacers = Formula1.GetChampions().Filter(r => r.Country == "Austria");

            foreach (var racer in austrianRacers)
            {
                Console.WriteLine($"{racer.FirstName} {racer.LastName}");
            }
        }

        private static void GroupingSample()
        {
            var q = (from r in Formula1.GetChampions()
                    group r by r.Country into g
                    let count = g.Count()
                    orderby count descending, g.Key
                    select new 
                    {
                        Country = g.Key,
                        Count = count
                    }).Take(5);

            foreach (var item in q)
            {
                Console.WriteLine($"{item.Country} {item.Count}");
            }

        }

        private static void LinqMethodSyntax()
        {
            var q = Formula1.GetChampions()
                .Where(r => r.Country == "Brazil")
                .OrderByDescending(r => r.Wins)
                .Select(r => r);

            foreach (var r in q)
            {
                Console.WriteLine($"{r.FirstName} {r.LastName} {r.Wins}");
            }
        }

        private static void LinqQuery()
        {
            var q = from r in Formula1.GetChampions()
                    where r.Country == "Brazil"
                    orderby r.Wins descending
                    select r;

            foreach (var r in q)
            {
                Console.WriteLine($"{r.FirstName} {r.LastName} {r.Wins}");
            }
        }
    }
}
