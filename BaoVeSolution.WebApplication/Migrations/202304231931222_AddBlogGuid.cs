namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "Guid", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blog", "Guid");
        }
    }
}
