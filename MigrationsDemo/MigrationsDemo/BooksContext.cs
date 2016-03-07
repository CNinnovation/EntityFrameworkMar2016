using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationsDemo
{
    public class BooksContext : DbContext
    {
        private const string ConnectionString=@"server=(localdb)\mssqllocaldb;trusted_connection=true;database=BooksMigrationDB;multipleactiveresultsets=true";
        public BooksContext()
            : base(ConnectionString)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().Property(a => a.FirstName).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.LastName).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Book>().Property(b => b.Isbn).HasMaxLength(20).IsOptional();

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .Map(t => t.ToTable("BooksAuthors").MapLeftKey("BookId").MapRightKey("AuthorId"));

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .Map(t => t.ToTable("BooksAuthors").MapLeftKey("BookId").MapRightKey("AuthorId"));



        }

    }
}
