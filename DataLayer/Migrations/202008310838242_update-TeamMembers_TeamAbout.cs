namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTeamMembers_TeamAbout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutDescriptions",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.TeamMembers",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        ImageName = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamMembers");
            DropTable("dbo.AboutDescriptions");
        }
    }
}
