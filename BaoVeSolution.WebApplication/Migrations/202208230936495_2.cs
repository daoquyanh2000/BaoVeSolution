namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "UserModified", c => c.String());
            AlterColumn("dbo.Blog", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Blog", "DateModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blog", "DateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Blog", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Blog", "UserModified");
        }
    }
}
