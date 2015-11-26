namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Countries_Cities_UserCity_fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "City_Name", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "City_Name" });
            AlterColumn("dbo.Users", "City_Name", c => c.String(maxLength: 128));
            CreateIndex("dbo.Users", "City_Name");
            AddForeignKey("dbo.Users", "City_Name", "dbo.Cities", "Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "City_Name", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "City_Name" });
            AlterColumn("dbo.Users", "City_Name", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Users", "City_Name");
            AddForeignKey("dbo.Users", "City_Name", "dbo.Cities", "Name", cascadeDelete: true);
        }
    }
}
