namespace MigrationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.BooksAuthors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorId, t.BookId })
                .ForeignKey("dbo.Books", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.BookId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.BookId);

            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BooksAuthors", "BookId", "dbo.Authors");
            DropForeignKey("dbo.BooksAuthors", "AuthorId", "dbo.Books");
            DropIndex("dbo.BooksAuthors", new[] { "BookId" });
            DropIndex("dbo.BooksAuthors", new[] { "AuthorId" });
            DropTable("dbo.BooksAuthors");
            DropTable("dbo.Authors");
        }
    }
}
