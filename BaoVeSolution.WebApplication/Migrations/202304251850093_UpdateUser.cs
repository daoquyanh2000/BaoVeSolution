﻿namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "UserCreated_Id", "dbo.User");
            DropForeignKey("dbo.Category", "UserModified_Id", "dbo.User");
            DropForeignKey("dbo.Blog", "UserCreated_Id", "dbo.User");
            DropForeignKey("dbo.Blog", "UserModified_Id", "dbo.User");
            DropForeignKey("dbo.Comment", "UserCreated_Id", "dbo.User");
            DropForeignKey("dbo.Comment", "UserModified_Id", "dbo.User");
            DropForeignKey("dbo.HomePage", "UserCreated_Id", "dbo.User");
            DropForeignKey("dbo.HomePage", "UserModified_Id", "dbo.User");
            DropIndex("dbo.Blog", new[] { "UserCreated_Id" });
            DropIndex("dbo.Blog", new[] { "UserModified_Id" });
            DropIndex("dbo.Category", new[] { "UserCreated_Id" });
            DropIndex("dbo.Category", new[] { "UserModified_Id" });
            DropIndex("dbo.Comment", new[] { "UserCreated_Id" });
            DropIndex("dbo.Comment", new[] { "UserModified_Id" });
            DropIndex("dbo.HomePage", new[] { "UserCreated_Id" });
            DropIndex("dbo.HomePage", new[] { "UserModified_Id" });
            AddColumn("dbo.Blog", "UserCreated", c => c.String());
            AddColumn("dbo.Blog", "UserModified", c => c.String());
            DropColumn("dbo.Blog", "UserNameCreated");
            DropColumn("dbo.Blog", "UserNameModified");
            DropColumn("dbo.Blog", "UserCreated_Id");
            DropColumn("dbo.Blog", "UserModified_Id");
            DropColumn("dbo.Category", "UserCreated_Id");
            DropColumn("dbo.Category", "UserModified_Id");
            DropColumn("dbo.Comment", "UserCreated_Id");
            DropColumn("dbo.Comment", "UserModified_Id");
            DropColumn("dbo.HomePage", "UserCreated_Id");
            DropColumn("dbo.HomePage", "UserModified_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HomePage", "UserModified_Id", c => c.Int());
            AddColumn("dbo.HomePage", "UserCreated_Id", c => c.Int());
            AddColumn("dbo.Comment", "UserModified_Id", c => c.Int());
            AddColumn("dbo.Comment", "UserCreated_Id", c => c.Int());
            AddColumn("dbo.Category", "UserModified_Id", c => c.Int());
            AddColumn("dbo.Category", "UserCreated_Id", c => c.Int());
            AddColumn("dbo.Blog", "UserModified_Id", c => c.Int());
            AddColumn("dbo.Blog", "UserCreated_Id", c => c.Int());
            AddColumn("dbo.Blog", "UserNameModified", c => c.String());
            AddColumn("dbo.Blog", "UserNameCreated", c => c.String());
            DropColumn("dbo.Blog", "UserModified");
            DropColumn("dbo.Blog", "UserCreated");
            CreateIndex("dbo.HomePage", "UserModified_Id");
            CreateIndex("dbo.HomePage", "UserCreated_Id");
            CreateIndex("dbo.Comment", "UserModified_Id");
            CreateIndex("dbo.Comment", "UserCreated_Id");
            CreateIndex("dbo.Category", "UserModified_Id");
            CreateIndex("dbo.Category", "UserCreated_Id");
            CreateIndex("dbo.Blog", "UserModified_Id");
            CreateIndex("dbo.Blog", "UserCreated_Id");
            AddForeignKey("dbo.HomePage", "UserModified_Id", "dbo.User", "Id");
            AddForeignKey("dbo.HomePage", "UserCreated_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Comment", "UserModified_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Comment", "UserCreated_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Blog", "UserModified_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Blog", "UserCreated_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Category", "UserModified_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Category", "UserCreated_Id", "dbo.User", "Id");
        }
    }
}