namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blog", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blog", "ImagePath", c => c.String(nullable: false));
        }
    }
}
