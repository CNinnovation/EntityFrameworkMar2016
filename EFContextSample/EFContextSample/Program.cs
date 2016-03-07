﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static System.Console;


namespace EFContextSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // WriteToDB();
            // ReadDemo();
            // FindById();
            LocalData();
            WriteLine("Main end");
            ReadLine();

        }

        private static void LocalData()
        {
            using (var context = new BooksContext())
            {
                WriteLine($"number of objects in context: {context.Books.Local.Count}");
                // Book b = context.Books.Find(1);
                context.Books.Load();
                // WriteLine($"found book: {b.Title} {b.Publisher}");
                WriteLine($"number of objects in context: {context.Books.Local.Count}");

            }
        }

        private static void FindById()
        {
            using (var context = new BooksContext())
            {
                Book b = context.Books.Find(1);
                WriteLine($"found book: {b.Title} {b.Publisher}");
            }
        }

        private static void WriteToDB()
        {
            using (var context = new BooksContext())
            {
                Book theBook = context.Books.Create();
                theBook.Title = "Professional C# 6";
                theBook.Publisher = "Wrox Press";
                context.Books.Add(theBook);
                int changed = context.SaveChanges();
                WriteLine($"changed {changed} records");
            }
        }

        private static void ReadDemo()
        {
            using (var context = new BooksContext())
            {
                var q = from b in context.Books
                        select b;

                foreach (var book in q)
                {
                    WriteLine($"{book.Title} {book.Publisher}");
                }
            }
        }
    }
}
