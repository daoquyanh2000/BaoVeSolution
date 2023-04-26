namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubCommentEntity : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.ParentId);
            
            DropColumn("dbo.Comment", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "ParentId", c => c.String());
            DropForeignKey("dbo.SubComment", "ParentId", "dbo.Comment");
            DropIndex("dbo.SubComment", new[] { "ParentId" });
            DropTable("dbo.SubComment");
        }
    }
}
