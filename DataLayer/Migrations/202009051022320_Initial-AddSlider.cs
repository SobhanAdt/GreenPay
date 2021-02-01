namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAddSlider : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderID = c.Int(nullable: false, identity: true),
                        ImageSlider = c.String(),
                        Title = c.String(),
                        Subtitle1 = c.String(),
                        SubTitle2 = c.String(),
                        SubImageSlider = c.String(),
                    })
                .PrimaryKey(t => t.SliderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sliders");
        }
    }
}
