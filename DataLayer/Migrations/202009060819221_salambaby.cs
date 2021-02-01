namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salambaby : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "Alt", c => c.String(nullable: false));
            AddColumn("dbo.Sliders", "Url", c => c.String());
            AlterColumn("dbo.Sliders", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Sliders", "SubImageSlider");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "SubImageSlider", c => c.String());
            AlterColumn("dbo.Sliders", "Title", c => c.String());
            DropColumn("dbo.Sliders", "Url");
            DropColumn("dbo.Sliders", "Alt");
        }
    }
}
