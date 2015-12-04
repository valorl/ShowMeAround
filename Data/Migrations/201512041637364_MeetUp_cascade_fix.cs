namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MeetUp_cascade_fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeetUps", "Guide_Id", "dbo.Users");
            DropIndex("dbo.MeetUps", new[] { "Guide_Id" });
            DropIndex("dbo.MeetUps", new[] { "Traveler_Id" });
            AlterColumn("dbo.MeetUps", "City", c => c.String(nullable: false));
            AlterColumn("dbo.MeetUps", "Guide_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MeetUps", "Traveler_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MeetUps", "Guide_Id");
            CreateIndex("dbo.MeetUps", "Traveler_Id");
            AddForeignKey("dbo.MeetUps", "Guide_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetUps", "Guide_Id", "dbo.Users");
            DropIndex("dbo.MeetUps", new[] { "Traveler_Id" });
            DropIndex("dbo.MeetUps", new[] { "Guide_Id" });
            AlterColumn("dbo.MeetUps", "Traveler_Id", c => c.Int());
            AlterColumn("dbo.MeetUps", "Guide_Id", c => c.Int());
            AlterColumn("dbo.MeetUps", "City", c => c.String());
            CreateIndex("dbo.MeetUps", "Traveler_Id");
            CreateIndex("dbo.MeetUps", "Guide_Id");
            AddForeignKey("dbo.MeetUps", "Guide_Id", "dbo.Users", "Id");
        }
    }
}
