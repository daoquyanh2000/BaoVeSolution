namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateComment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubComment", "ParentId", "dbo.Comment");
            DropForeignKey("dbo.SubComment", "UserCreateId", "dbo.User");
            DropForeignKey("dbo.SubComment", "UserUpdateId", "dbo.User");
            DropIndex("dbo.SubComment", new[] { "ParentId" });
            DropIndex("dbo.SubComment", new[] { "UserCreateId" });
            DropIndex("dbo.SubComment", new[] { "UserUpdateId" });
            AddColumn("dbo.Comment", "ParentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "ParentId");
            AddForeignKey("dbo.Comment", "ParentId", "dbo.Comment", "Id");
            DropTable("dbo.SubComment");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Comment", "ParentId", "dbo.Comment");
            DropIndex("dbo.Comment", new[] { "ParentId" });
            DropColumn("dbo.Comment", "ParentId");
            CreateIndex("dbo.SubComment", "UserUpdateId");
            CreateIndex("dbo.SubComment", "UserCreateId");
            CreateIndex("dbo.SubComment", "ParentId");
            AddForeignKey("dbo.SubComment", "UserUpdateId", "dbo.User", "Id");
            AddForeignKey("dbo.SubComment", "UserCreateId", "dbo.User", "Id");
            AddForeignKey("dbo.SubComment", "ParentId", "dbo.Comment", "Id", cascadeDelete: true);
        }
    }
}
