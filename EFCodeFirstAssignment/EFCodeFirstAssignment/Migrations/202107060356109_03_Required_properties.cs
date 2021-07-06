namespace EFCodeFirstAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03_Required_properties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Book", "BookName", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Member", "MemberName", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "MemberName", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Book", "BookName", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
