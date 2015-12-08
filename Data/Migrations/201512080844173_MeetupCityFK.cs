namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetupCityFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeetUps", "City_Name", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.MeetUps", "City_Name");
            AddForeignKey("dbo.MeetUps", "City_Name", "dbo.Cities", "Name", cascadeDelete: true);
            DropColumn("dbo.MeetUps", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeetUps", "City", c => c.String(nullable: false));
            DropForeignKey("dbo.MeetUps", "City_Name", "dbo.Cities");
            DropIndex("dbo.MeetUps", new[] { "City_Name" });
            DropColumn("dbo.MeetUps", "City_Name");
        }
    }
}
