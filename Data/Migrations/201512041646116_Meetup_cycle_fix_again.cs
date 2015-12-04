namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Meetup_cycle_fix_again : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeetUps", "Guide_Id", "dbo.Users");
            DropIndex("dbo.MeetUps", new[] { "Guide_Id" });
            AlterColumn("dbo.MeetUps", "Guide_Id", c => c.Int());
            CreateIndex("dbo.MeetUps", "Guide_Id");
            AddForeignKey("dbo.MeetUps", "Guide_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetUps", "Guide_Id", "dbo.Users");
            DropIndex("dbo.MeetUps", new[] { "Guide_Id" });
            AlterColumn("dbo.MeetUps", "Guide_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MeetUps", "Guide_Id");
            AddForeignKey("dbo.MeetUps", "Guide_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
