namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "BlogState", c => c.Int(nullable: false));
            AddColumn("dbo.Blog", "UserCreateId", c => c.Int());
            AddColumn("dbo.Blog", "UserUpdateId", c => c.Int());
            AddColumn("dbo.Blog", "User_Id", c => c.Int());
            AddColumn("dbo.Category", "UserCreateId", c => c.Int());
            AddColumn("dbo.Category", "UserUpdateId", c => c.Int());
            AddColumn("dbo.Category", "User_Id", c => c.Int());
            AddColumn("dbo.Comment", "UserCreateId", c => c.Int());
            AddColumn("dbo.Comment", "UserUpdateId", c => c.Int());
            AddColumn("dbo.Comment", "User_Id", c => c.Int());
            AddColumn("dbo.SubComment", "UserCreateId", c => c.Int());
            AddColumn("dbo.SubComment", "UserUpdateId", c => c.Int());
            AddColumn("dbo.SubComment", "User_Id", c => c.Int());
            CreateIndex("dbo.Blog", "UserCreateId");
            CreateIndex("dbo.Blog", "UserUpdateId");
            CreateIndex("dbo.Blog", "User_Id");
            CreateIndex("dbo.Category", "UserCreateId");
            CreateIndex("dbo.Category", "UserUpdateId");
            CreateIndex("dbo.Category", "User_Id");
            CreateIndex("dbo.Comment", "UserCreateId");
            CreateIndex("dbo.Comment", "UserUpdateId");
            CreateIndex("dbo.Comment", "User_Id");
            CreateIndex("dbo.SubComment", "UserCreateId");
            CreateIndex("dbo.SubComment", "UserUpdateId");
            CreateIndex("dbo.SubComment", "User_Id");
            AddForeignKey("dbo.Blog", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Category", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.SubComment", "UserCreateId", "dbo.User", "Id");
            AddForeignKey("dbo.SubComment", "UserUpdateId", "dbo.User", "Id");
            AddForeignKey("dbo.Comment", "UserCreateId", "dbo.User", "Id");
            AddForeignKey("dbo.Comment", "UserUpdateId", "dbo.User", "Id");
            AddForeignKey("dbo.Comment", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.SubComment", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Category", "UserCreateId", "dbo.User", "Id");
            AddForeignKey("dbo.Category", "UserUpdateId", "dbo.User", "Id");
            AddForeignKey("dbo.Blog", "UserCreateId", "dbo.User", "Id");
            AddForeignKey("dbo.Blog", "UserUpdateId", "dbo.User", "Id");
            DropColumn("dbo.HomePage", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HomePage", "State", c => c.Int(nullable: false));
            DropForeignKey("dbo.Blog", "UserUpdateId", "dbo.User");
            DropForeignKey("dbo.Blog", "UserCreateId", "dbo.User");
            DropForeignKey("dbo.Category", "UserUpdateId", "dbo.User");
            DropForeignKey("dbo.Category", "UserCreateId", "dbo.User");
            DropForeignKey("dbo.SubComment", "User_Id", "dbo.User");
            DropForeignKey("dbo.Comment", "User_Id", "dbo.User");
            DropForeignKey("dbo.Comment", "UserUpdateId", "dbo.User");
            DropForeignKey("dbo.Comment", "UserCreateId", "dbo.User");
            DropForeignKey("dbo.SubComment", "UserUpdateId", "dbo.User");
            DropForeignKey("dbo.SubComment", "UserCreateId", "dbo.User");
            DropForeignKey("dbo.Category", "User_Id", "dbo.User");
            DropForeignKey("dbo.Blog", "User_Id", "dbo.User");
            DropIndex("dbo.SubComment", new[] { "User_Id" });
            DropIndex("dbo.SubComment", new[] { "UserUpdateId" });
            DropIndex("dbo.SubComment", new[] { "UserCreateId" });
            DropIndex("dbo.Comment", new[] { "User_Id" });
            DropIndex("dbo.Comment", new[] { "UserUpdateId" });
            DropIndex("dbo.Comment", new[] { "UserCreateId" });
            DropIndex("dbo.Category", new[] { "User_Id" });
            DropIndex("dbo.Category", new[] { "UserUpdateId" });
            DropIndex("dbo.Category", new[] { "UserCreateId" });
            DropIndex("dbo.Blog", new[] { "User_Id" });
            DropIndex("dbo.Blog", new[] { "UserUpdateId" });
            DropIndex("dbo.Blog", new[] { "UserCreateId" });
            DropColumn("dbo.SubComment", "User_Id");
            DropColumn("dbo.SubComment", "UserUpdateId");
            DropColumn("dbo.SubComment", "UserCreateId");
            DropColumn("dbo.Comment", "User_Id");
            DropColumn("dbo.Comment", "UserUpdateId");
            DropColumn("dbo.Comment", "UserCreateId");
            DropColumn("dbo.Category", "User_Id");
            DropColumn("dbo.Category", "UserUpdateId");
            DropColumn("dbo.Category", "UserCreateId");
            DropColumn("dbo.Blog", "User_Id");
            DropColumn("dbo.Blog", "UserUpdateId");
            DropColumn("dbo.Blog", "UserCreateId");
            DropColumn("dbo.Blog", "BlogState");
        }
    }
}
