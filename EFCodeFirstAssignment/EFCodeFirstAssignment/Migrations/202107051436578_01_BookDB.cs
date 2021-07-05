namespace EFCodeFirstAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01_BookDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        BookName = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false),
                        MemberName = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewID = c.Int(nullable: false),
                        ReviewText = c.String(maxLength: 50, unicode: false),
                        BookID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "MemberID", "dbo.Member");
            DropForeignKey("dbo.Review", "BookID", "dbo.Book");
            DropIndex("dbo.Review", new[] { "MemberID" });
            DropIndex("dbo.Review", new[] { "BookID" });
            DropTable("dbo.Review");
            DropTable("dbo.Member");
            DropTable("dbo.Book");
        }
    }
}
