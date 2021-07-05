namespace EFCodeFirstAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02_Book_Publisher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherID = c.Int(nullable: false),
                        PublisherName = c.String(maxLength: 20, unicode: false),
                        Country = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.PublisherID);
            
            AddColumn("dbo.Book", "PublisherID", c => c.Int(nullable: false));
            CreateIndex("dbo.Book", "PublisherID");
            AddForeignKey("dbo.Book", "PublisherID", "dbo.Publisher", "PublisherID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "PublisherID", "dbo.Publisher");
            DropIndex("dbo.Book", new[] { "PublisherID" });
            DropColumn("dbo.Book", "PublisherID");
            DropTable("dbo.Publisher");
        }
    }
}
