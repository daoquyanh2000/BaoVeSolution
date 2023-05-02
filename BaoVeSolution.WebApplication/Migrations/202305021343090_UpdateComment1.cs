namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateComment1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comment", new[] { "ParentId" });
            AlterColumn("dbo.Comment", "ParentId", c => c.Int());
            CreateIndex("dbo.Comment", "ParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comment", new[] { "ParentId" });
            AlterColumn("dbo.Comment", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "ParentId");
        }
    }
}
