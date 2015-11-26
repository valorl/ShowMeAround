namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Countries_Cities_UserCity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "City_Name", c => c.String(nullable: true, maxLength: 128));
            CreateIndex("dbo.Users", "City_Name");
            AddForeignKey("dbo.Users", "City_Name", "dbo.Cities", "Name", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "City_Name", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Users", new[] { "City_Name" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropColumn("dbo.Users", "City_Name");
            DropColumn("dbo.Users", "Gender");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
