namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditImageTeam : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AboutDescriptions", "Image", c => c.String());
            AlterColumn("dbo.TeamMembers", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeamMembers", "ImageName", c => c.String(nullable: false));
            AlterColumn("dbo.AboutDescriptions", "Image", c => c.String(nullable: false));
        }
    }
}
