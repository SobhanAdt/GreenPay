namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitaildatabaeAddTableHamkarans : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hamkarans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        WebSite = c.String(nullable: false, maxLength: 150),
                        ImageHamkaran = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hamkarans");
        }
    }
}
