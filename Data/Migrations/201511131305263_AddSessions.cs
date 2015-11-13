namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSessions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Token = c.String(nullable: false, maxLength: 128),
                        UserID = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Token);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sessions");
        }
    }
}
