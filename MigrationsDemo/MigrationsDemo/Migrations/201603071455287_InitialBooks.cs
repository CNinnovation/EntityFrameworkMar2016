namespace MigrationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Publisher = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
