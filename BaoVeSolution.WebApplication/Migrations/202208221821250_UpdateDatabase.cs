namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "UserCreated", c => c.String());
            AddColumn("dbo.Category", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Description");
            DropColumn("dbo.Blog", "UserCreated");
        }
    }
}
