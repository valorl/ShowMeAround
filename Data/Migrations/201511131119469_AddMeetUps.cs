namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeetUps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeetUps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        City = c.String(),
                        Guide_Id = c.Int(),
                        Traveler_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Guide_Id)
                .ForeignKey("dbo.Users", t => t.Traveler_Id)
                .Index(t => t.Guide_Id)
                .Index(t => t.Traveler_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetUps", "Traveler_Id", "dbo.Users");
            DropForeignKey("dbo.MeetUps", "Guide_Id", "dbo.Users");
            DropIndex("dbo.MeetUps", new[] { "Traveler_Id" });
            DropIndex("dbo.MeetUps", new[] { "Guide_Id" });
            DropTable("dbo.MeetUps");
        }
        //test
    }
}
