namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(precision: 7, storeType: "datetime2"),
                        Title = c.String(nullable: false),
                        ImagePath = c.String(),
                        Description = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        BlogState = c.Int(nullable: false),
                        UserCreateId = c.Int(),
                        UserUpdateId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserCreateId)
                .ForeignKey("dbo.User", t => t.UserUpdateId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserCreateId)
                .Index(t => t.UserUpdateId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(nullable: false),
                        Slug = c.String(),
                        Description = c.String(nullable: false),
                        CategoryState = c.Int(nullable: false),
                        UserCreateId = c.Int(),
                        UserUpdateId = c.Int(),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserCreateId)
                .ForeignKey("dbo.User", t => t.UserUpdateId)
                .Index(t => t.UserCreateId)
                .Index(t => t.UserUpdateId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        UserCreateId = c.Int(nullable: false),
                        UserUpdateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        State = c.Int(nullable: false),
                        UserCreateId = c.Int(),
                        UserUpdateId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserCreateId)
                .ForeignKey("dbo.User", t => t.UserUpdateId)
                .Index(t => t.UserCreateId)
                .Index(t => t.UserUpdateId);
            
            CreateTable(
                "dbo.SubComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        ParentId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        State = c.Int(nullable: false),
                        UserCreateId = c.Int(),
                        UserUpdateId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.ParentId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserCreateId)
                .ForeignKey("dbo.User", t => t.UserUpdateId)
                .Index(t => t.ParentId)
                .Index(t => t.UserCreateId)
                .Index(t => t.UserUpdateId);
            
            CreateTable(
                "dbo.HomePage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearsExperience = c.Int(nullable: false),
                        Project = c.Int(nullable: false),
                        Award = c.Int(nullable: false),
                        Employees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Layout",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        OpenTime = c.String(),
                        CloseTime = c.String(),
                        ApplicationName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "UserUpdateId", "dbo.User");
            DropForeignKey("dbo.Comment", "UserCreateId", "dbo.User");
            DropForeignKey("dbo.SubComment", "UserUpdateId", "dbo.User");
            DropForeignKey("dbo.SubComment", "UserCreateId", "dbo.User");
            DropForeignKey("dbo.SubComment", "ParentId", "dbo.Comment");
            DropForeignKey("dbo.Blog", "UserUpdateId", "dbo.User");
            DropForeignKey("dbo.Blog", "UserCreateId", "dbo.User");
            DropForeignKey("dbo.Category", "UserUpdateId", "dbo.User");
            DropForeignKey("dbo.Category", "UserCreateId", "dbo.User");
            DropForeignKey("dbo.Blog", "CategoryId", "dbo.Category");
            DropIndex("dbo.SubComment", new[] { "UserUpdateId" });
            DropIndex("dbo.SubComment", new[] { "UserCreateId" });
            DropIndex("dbo.SubComment", new[] { "ParentId" });
            DropIndex("dbo.Comment", new[] { "UserUpdateId" });
            DropIndex("dbo.Comment", new[] { "UserCreateId" });
            DropIndex("dbo.Category", new[] { "UserUpdateId" });
            DropIndex("dbo.Category", new[] { "UserCreateId" });
            DropIndex("dbo.Blog", new[] { "UserUpdateId" });
            DropIndex("dbo.Blog", new[] { "UserCreateId" });
            DropIndex("dbo.Blog", new[] { "CategoryId" });
            DropTable("dbo.Layout");
            DropTable("dbo.HomePage");
            DropTable("dbo.SubComment");
            DropTable("dbo.Comment");
            DropTable("dbo.User");
            DropTable("dbo.Category");
            DropTable("dbo.Blog");
        }
    }
}
