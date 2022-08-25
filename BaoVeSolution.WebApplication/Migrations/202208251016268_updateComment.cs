namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Comment", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Comment", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Comment", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Comment", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "Address", c => c.String());
            AlterColumn("dbo.Comment", "Email", c => c.String());
            AlterColumn("dbo.Comment", "Content", c => c.String());
            DropColumn("dbo.Comment", "DateCreated");
            DropColumn("dbo.Comment", "Name");
        }
    }
}
