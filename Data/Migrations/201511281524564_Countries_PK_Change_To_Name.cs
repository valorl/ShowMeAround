namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Countries_PK_Change_To_Name : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            RenameColumn(table: "dbo.Cities", name: "Country_Id", newName: "Country_Name");
            DropPrimaryKey("dbo.Countries");
            AddColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Cities", "Country_Name", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Countries", "Name");
            CreateIndex("dbo.Cities", "Country_Name");
            AddForeignKey("dbo.Cities", "Country_Name", "dbo.Countries", "Name");
            DropColumn("dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Countries", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Cities", "Country_Name", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "Country_Name" });
            DropPrimaryKey("dbo.Countries");
            AlterColumn("dbo.Cities", "Country_Name", c => c.Int());
            DropColumn("dbo.Countries", "Name");
            AddPrimaryKey("dbo.Countries", "Id");
            RenameColumn(table: "dbo.Cities", name: "Country_Name", newName: "Country_Id");
            CreateIndex("dbo.Cities", "Country_Id");
            AddForeignKey("dbo.Cities", "Country_Id", "dbo.Countries", "Id");
        }
    }
}
