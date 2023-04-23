namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "UserNameCreated", c => c.String());
            AddColumn("dbo.Blog", "UserNameModified", c => c.String());
            AddColumn("dbo.Blog", "Category_Id", c => c.Int());
            AddColumn("dbo.Blog", "UserCreated_Id", c => c.Int());
            AddColumn("dbo.Blog", "UserModified_Id", c => c.Int());
            AddColumn("dbo.Category", "UserCreated_Id", c => c.Int());
            AddColumn("dbo.Category", "UserModified_Id", c => c.Int());
            AddColumn("dbo.Comment", "UserCreated_Id", c => c.Int());
            AddColumn("dbo.Comment", "UserModified_Id", c => c.Int());
            AddColumn("dbo.HomePage", "UserCreated_Id", c => c.Int());
            AddColumn("dbo.HomePage", "UserModified_Id", c => c.Int());
            AddColumn("dbo.Layout", "ApplicationName", c => c.String(nullable: false));
            AddColumn("dbo.User", "IsAdmin", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Blog", "Category_Id");
            CreateIndex("dbo.Blog", "UserCreated_Id");
            CreateIndex("dbo.Blog", "UserModified_Id");
            CreateIndex("dbo.Category", "UserCreated_Id");
            CreateIndex("dbo.Category", "UserModified_Id");
            CreateIndex("dbo.Comment", "UserCreated_Id");
            CreateIndex("dbo.Comment", "UserModified_Id");
            CreateIndex("dbo.HomePage", "UserCreated_Id");
            CreateIndex("dbo.HomePage", "UserModified_Id");
            AddForeignKey("dbo.Blog", "Category_Id", "dbo.Category", "Id");
            AddForeignKey("dbo.Category", "UserCreated_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Category", "UserModified_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Blog", "UserCreated_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Blog", "UserModified_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Comment", "UserCreated_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Comment", "UserModified_Id", "dbo.User", "Id");
            AddForeignKey("dbo.HomePage", "UserCreated_Id", "dbo.User", "Id");
            AddForeignKey("dbo.HomePage", "UserModified_Id", "dbo.User", "Id");
            DropColumn("dbo.Blog", "UserCreated");
            DropColumn("dbo.Blog", "UserModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blog", "UserModified", c => c.String());
            AddColumn("dbo.Blog", "UserCreated", c => c.String());
            DropForeignKey("dbo.HomePage", "UserModified_Id", "dbo.User");
            DropForeignKey("dbo.HomePage", "UserCreated_Id", "dbo.User");
            DropForeignKey("dbo.Comment", "UserModified_Id", "dbo.User");
            DropForeignKey("dbo.Comment", "UserCreated_Id", "dbo.User");
            DropForeignKey("dbo.Blog", "UserModified_Id", "dbo.User");
            DropForeignKey("dbo.Blog", "UserCreated_Id", "dbo.User");
            DropForeignKey("dbo.Category", "UserModified_Id", "dbo.User");
            DropForeignKey("dbo.Category", "UserCreated_Id", "dbo.User");
            DropForeignKey("dbo.Blog", "Category_Id", "dbo.Category");
            DropIndex("dbo.HomePage", new[] { "UserModified_Id" });
            DropIndex("dbo.HomePage", new[] { "UserCreated_Id" });
            DropIndex("dbo.Comment", new[] { "UserModified_Id" });
            DropIndex("dbo.Comment", new[] { "UserCreated_Id" });
            DropIndex("dbo.Category", new[] { "UserModified_Id" });
            DropIndex("dbo.Category", new[] { "UserCreated_Id" });
            DropIndex("dbo.Blog", new[] { "UserModified_Id" });
            DropIndex("dbo.Blog", new[] { "UserCreated_Id" });
            DropIndex("dbo.Blog", new[] { "Category_Id" });
            DropColumn("dbo.User", "IsAdmin");
            DropColumn("dbo.Layout", "ApplicationName");
            DropColumn("dbo.HomePage", "UserModified_Id");
            DropColumn("dbo.HomePage", "UserCreated_Id");
            DropColumn("dbo.Comment", "UserModified_Id");
            DropColumn("dbo.Comment", "UserCreated_Id");
            DropColumn("dbo.Category", "UserModified_Id");
            DropColumn("dbo.Category", "UserCreated_Id");
            DropColumn("dbo.Blog", "UserModified_Id");
            DropColumn("dbo.Blog", "UserCreated_Id");
            DropColumn("dbo.Blog", "Category_Id");
            DropColumn("dbo.Blog", "UserNameModified");
            DropColumn("dbo.Blog", "UserNameCreated");
        }
    }
}
