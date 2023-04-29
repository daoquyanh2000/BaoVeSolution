namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "BlogId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comment", "DateCreated", c => c.DateTime(precision: 7, storeType: "datetime2"));
            CreateIndex("dbo.Comment", "BlogId");
            AddForeignKey("dbo.Comment", "BlogId", "dbo.Blog", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "BlogId", "dbo.Blog");
            DropIndex("dbo.Comment", new[] { "BlogId" });
            AlterColumn("dbo.Comment", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Comment", "BlogId");
        }
    }
}
