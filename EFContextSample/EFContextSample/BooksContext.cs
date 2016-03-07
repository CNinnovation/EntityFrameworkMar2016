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

        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasMany<Author>(b => b.Authors)
                .WithMany(a => a.Books)
                .Map(t => t.ToTable("BooksAuthors").MapLeftKey("BookId").MapRightKey("AuthorId"));

            modelBuilder.Entity<Author>()
                .HasMany<Book>(a => a.Books)
                .WithMany(b => b.Authors)
                .Map(t => t.ToTable("BooksAuthors").MapLeftKey("BookId").MapRightKey("AuthorId"));
        }

    }
}
