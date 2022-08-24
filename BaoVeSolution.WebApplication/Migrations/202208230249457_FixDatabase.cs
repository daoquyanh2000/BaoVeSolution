namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.User", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.User", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Blog", "Info");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blog", "Info", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "PhoneNumber", c => c.String());
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "UserName", c => c.String());
            DropColumn("dbo.Blog", "Content");
        }
    }
}
