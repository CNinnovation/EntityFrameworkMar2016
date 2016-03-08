using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static System.Console;
using System.Data.Entity.Infrastructure;

namespace EFContextSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // WriteToDB();
            // ReadDemo();
            // FindById();
            // LocalData();
            // LinqQuery();
            // UseRelation();
            // LazyLoading();
            // EagerLoading();
            // ExplicitLoading();
            /// AddBooks();
            // ModifyBook();
            // TrackingDemo();
            ModifyBookWithConcurrencyCheck();
            WriteLine("Main end");
            ReadLine();

        }

        private static void ModifyBookWithConcurrencyCheck()
        {

            using (var context = new BooksContext())
            {
                try {
                    context.Database.Log = Console.WriteLine;


                    var b1 = context.Books.Where(b => b.Title.StartsWith("Universal")).FirstOrDefault();
                    DbEntityEntry entryB1 = context.Entry<Book>(b1);
                    if (b1 != null)
                    {
                        b1.Title = "Programming Universal Apps";
                    }
                    int changed = context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void TrackingDemo()
        {
            using (var context = new BooksContext())
            {
                var b1 = context.Books.Where(b => b.Title.StartsWith("Universal")).AsNoTracking().FirstOrDefault();
                var b2 = context.Books.Where(b => b.Title == "Universal Apps").AsNoTracking().FirstOrDefault();

                if (object.ReferenceEquals(b1, b2))
                {
                    Console.WriteLine("the same object");
                }
                else
                {
                    Console.WriteLine("not the same");
                }
            }
        }

        private static void ModifyBook()
        {
            using (var context = new BooksContext())
            {
                context.Database.Log = Console.WriteLine;


                var b1 = context.Books.Where(b => b.Title.StartsWith("Universal")).FirstOrDefault();
                DbEntityEntry entryB1 = context.Entry<Book>(b1);
                if (b1 != null)
                {
                    b1.Title = "Programming Universal Apps";
                }
                // WriteLine($"state of b1: {context.Entry<Book>(b1).State}");
                WriteLine($"state of b1: {entryB1.State}");
                context.ChangeTracker.DetectChanges();
                WriteLine($"state of b1 after DetectChanges: {entryB1.State}");
                int changed = context.SaveChanges();
            }
        }

        private static void AddBooks()
        {
            using (var context = new BooksContext())
            {
                var b1 = new Book { Title = "Universal Apps", Publisher = "Self" };
                var b2 = new Book { Title = "C# 6", Publisher = "Self" };
                List<Book> books = new List<Book>()
                {
                   b1,
                   b2
                };
                context.Books.AddRange(books);



                WriteLine($"state of b1: {context.Entry<Book>(b1).State}");

                WriteLine($"state of b2: {context.Entry<Book>(b2).State}");

                var b3 = context.Books.Create();
                b3.Title = "Some title";
                b3.Publisher = "some publisher";

                context.Books.Add(b3);
                int changed = context.SaveChanges();
            }
        }

        private static void ExplicitLoading()
        {
            using (var context = new BooksContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Configuration.LazyLoadingEnabled = false;

                var q = from b in context.Books
                        where b.Publisher == "Wrox Press"
                        select b;

                foreach (var b in q)
                {
                    Console.WriteLine($"{b.Title}");

                    DbEntityEntry entry = context.Entry<Book>(b);
                    if (!entry.Collection("Authors").IsLoaded)
                    {
                        entry.Collection("Authors").Load();
                    }
                    foreach (var author in b.Authors)
                    {
                        Console.WriteLine($"\t{author.FirstName} {author.LastName}");
                    }
                }
            }
        }

        private static void EagerLoading()
        {
            using (var context = new BooksContext())
            {
                context.Database.Log = Console.WriteLine;

                var q = from b in context.Books.Include(b => b.Authors)
                        where b.Publisher == "Wrox Press"
                        select b;

                foreach (var b in q)
                {
                    Console.WriteLine($"{b.Title}");

                    foreach (var author in b.Authors)
                    {
                        Console.WriteLine($"\t{author.FirstName} {author.LastName}");
                    }
                }
            }
        }

        private static void LazyLoading()
        {
            using (var context = new BooksContext())
            {
                context.Database.Log = Console.WriteLine;

                var q = from b in context.Books
                        where b.Publisher == "Wrox Press"
                        select b;

                foreach (var b in q)
                {
                    Console.WriteLine($"{b.Title}");

                    foreach (var author in b.Authors)
                    {
                        Console.WriteLine($"\t{author.FirstName} {author.LastName}");
                    }
                }
            }
        }

        private static void UseRelation()
        {
            using (var context = new BooksContext())
            {
                var q = from b in context.Books
                        where b.Publisher == "Wrox Press"
                        select b;

                foreach (var b in q)
                {
                    Console.WriteLine($"{b.Title}");

                    foreach (var author in b.Authors)
                    {
                        Console.WriteLine($"\t{author.FirstName} {author.LastName}");
                    }
                }
            }
        }

        private static void LinqQuery()
        {
            using (var context = new BooksContext())
            {
                var q = context.Books.Where(b => b.Publisher == "Wrox Press").OrderBy(b => b.Title).Skip(3).Take(3);
                foreach (var b in q)
                {
                    Console.WriteLine($"{b.Title} {b.Publisher}");
                }
            }
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
