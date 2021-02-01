namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitaildatabaseEditModelHamkaran : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hamkarans", "ImageHamkaran", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hamkarans", "ImageHamkaran", c => c.String(nullable: false));
        }
    }
}
