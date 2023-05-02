namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateComment2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "ParentId", "dbo.Comment");
            DropIndex("dbo.Comment", new[] { "ParentId" });
            AlterColumn("dbo.Comment", "ParentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comment", "ParentId", c => c.Int());
            CreateIndex("dbo.Comment", "ParentId");
            AddForeignKey("dbo.Comment", "ParentId", "dbo.Comment", "Id");
        }
    }
}
