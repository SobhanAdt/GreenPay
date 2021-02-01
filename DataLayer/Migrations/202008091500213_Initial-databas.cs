namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialdatabas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.LoginID);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false, maxLength: 150),
                        Text = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        ImageName = c.String(),
                        ShowInSlider = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Tags = c.String(),
                    })
                .PrimaryKey(t => t.PageID)
                .ForeignKey("dbo.PageGroups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "GroupID", "dbo.PageGroups");
            DropIndex("dbo.Pages", new[] { "GroupID" });
            DropTable("dbo.Pages");
            DropTable("dbo.PageGroups");
            DropTable("dbo.AdminLogins");
        }
    }
}
