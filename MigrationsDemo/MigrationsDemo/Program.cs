using MigrationsDemo.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SetInitializer();
            AddBook();
        }

        private static void SetInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BooksContext, Configuration>());
        }

        public static void AddBook()
        {
            using (var context = new BooksContext())
            {
                Book newBook = context.Books.Create();
                newBook.Title = "one";
                newBook.Publisher = "two";
                newBook.Isbn = "3848745";

                context.Books.Add(newBook);
                int changed = context.SaveChanges();
            }
        }
    }
}
