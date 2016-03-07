using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFContextSample
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BooksDB;trusted_connection=true;MultipleActiveResultSets=true";
        public BooksContext()
            : base(ConnectionString)
        {

        }
        public DbSet<Book> Books { get; set; }

    }
}
