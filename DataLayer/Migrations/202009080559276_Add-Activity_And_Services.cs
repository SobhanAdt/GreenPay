namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivity_And_Services : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActiveID = c.Int(nullable: false, identity: true),
                        ActiveImage = c.String(),
                        ActiveTitle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ActiveID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServicesID = c.Int(nullable: false, identity: true),
                        ServicTitle = c.String(nullable: false),
                        ServicDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ServicesID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
            DropTable("dbo.Activities");
        }
    }
}
