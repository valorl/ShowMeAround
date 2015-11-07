namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.UserLanguages",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LanguageName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.LanguageName })
                .ForeignKey("dbo.Languages", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.LanguageName, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LanguageName);
            
            CreateTable(
                "dbo.UserInterests",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        InterestName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.InterestName })
                .ForeignKey("dbo.Interests", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.InterestName, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.InterestName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInterests", "InterestName", "dbo.Users");
            DropForeignKey("dbo.UserInterests", "UserId", "dbo.Interests");
            DropForeignKey("dbo.UserLanguages", "LanguageName", "dbo.Users");
            DropForeignKey("dbo.UserLanguages", "UserId", "dbo.Languages");
            DropIndex("dbo.UserInterests", new[] { "InterestName" });
            DropIndex("dbo.UserInterests", new[] { "UserId" });
            DropIndex("dbo.UserLanguages", new[] { "LanguageName" });
            DropIndex("dbo.UserLanguages", new[] { "UserId" });
            DropTable("dbo.UserInterests");
            DropTable("dbo.UserLanguages");
            DropTable("dbo.Languages");
            DropTable("dbo.Users");
            DropTable("dbo.Interests");
        }
    }
}
