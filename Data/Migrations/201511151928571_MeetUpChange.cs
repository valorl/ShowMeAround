namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetUpChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeetUps", "TravelerState", c => c.Int(nullable: false));
            AddColumn("dbo.MeetUps", "GuideState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MeetUps", "GuideState");
            DropColumn("dbo.MeetUps", "TravelerState");
        }
    }
}
