namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Meetup_cycle_fix_again_v2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MeetUps", new[] { "Traveler_Id" });
            AlterColumn("dbo.MeetUps", "Traveler_Id", c => c.Int());
            CreateIndex("dbo.MeetUps", "Traveler_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MeetUps", new[] { "Traveler_Id" });
            AlterColumn("dbo.MeetUps", "Traveler_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MeetUps", "Traveler_Id");
        }
    }
}
