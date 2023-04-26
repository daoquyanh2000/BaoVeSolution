namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blog", "Category_Id", "dbo.Category");
            DropIndex("dbo.Blog", new[] { "Category_Id" });
            DropColumn("dbo.Blog", "CategoryId");
            RenameColumn(table: "dbo.Blog", name: "Category_Id", newName: "CategoryId");
            DropPrimaryKey("dbo.Blog");
            AlterColumn("dbo.Blog", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Blog", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Blog", "CategoryId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Blog", "Id");
            CreateIndex("dbo.Blog", "CategoryId");
            AddForeignKey("dbo.Blog", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blog", "CategoryId", "dbo.Category");
            DropIndex("dbo.Blog", new[] { "CategoryId" });
            DropPrimaryKey("dbo.Blog");
            AlterColumn("dbo.Blog", "CategoryId", c => c.Int());
            AlterColumn("dbo.Blog", "CategoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.Blog", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Blog", "Id");
            RenameColumn(table: "dbo.Blog", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.Blog", "CategoryId", c => c.Long(nullable: false));
            CreateIndex("dbo.Blog", "Category_Id");
            AddForeignKey("dbo.Blog", "Category_Id", "dbo.Category", "Id");
        }
    }
}
