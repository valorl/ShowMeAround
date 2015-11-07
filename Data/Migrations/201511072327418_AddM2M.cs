namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddM2M : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserLanguages", new[] { "UserId" });
            DropIndex("dbo.UserLanguages", new[] { "LanguageName" });
            DropIndex("dbo.UserInterests", new[] { "UserId" });
            DropIndex("dbo.UserInterests", new[] { "InterestName" });
            RenameColumn(table: "dbo.UserInterests", name: "UserId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.UserInterests", name: "InterestName", newName: "UserId");
            RenameColumn(table: "dbo.UserLanguages", name: "UserId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.UserLanguages", name: "LanguageName", newName: "UserId");
            RenameColumn(table: "dbo.UserInterests", name: "__mig_tmp__0", newName: "InterestName");
            RenameColumn(table: "dbo.UserLanguages", name: "__mig_tmp__1", newName: "LanguageName");
            DropPrimaryKey("dbo.UserInterests");
            DropPrimaryKey("dbo.UserLanguages");
            AlterColumn("dbo.UserInterests", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserInterests", "InterestName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserLanguages", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserLanguages", "LanguageName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserInterests", new[] { "UserId", "InterestName" });
            AddPrimaryKey("dbo.UserLanguages", new[] { "UserId", "LanguageName" });
            CreateIndex("dbo.UserInterests", "UserId");
            CreateIndex("dbo.UserInterests", "InterestName");
            CreateIndex("dbo.UserLanguages", "UserId");
            CreateIndex("dbo.UserLanguages", "LanguageName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserLanguages", new[] { "LanguageName" });
            DropIndex("dbo.UserLanguages", new[] { "UserId" });
            DropIndex("dbo.UserInterests", new[] { "InterestName" });
            DropIndex("dbo.UserInterests", new[] { "UserId" });
            DropPrimaryKey("dbo.UserLanguages");
            DropPrimaryKey("dbo.UserInterests");
            AlterColumn("dbo.UserLanguages", "LanguageName", c => c.Int(nullable: false));
            AlterColumn("dbo.UserLanguages", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserInterests", "InterestName", c => c.Int(nullable: false));
            AlterColumn("dbo.UserInterests", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserLanguages", new[] { "UserId", "LanguageName" });
            AddPrimaryKey("dbo.UserInterests", new[] { "UserId", "InterestName" });
            RenameColumn(table: "dbo.UserLanguages", name: "LanguageName", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.UserInterests", name: "InterestName", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.UserLanguages", name: "UserId", newName: "LanguageName");
            RenameColumn(table: "dbo.UserLanguages", name: "__mig_tmp__1", newName: "UserId");
            RenameColumn(table: "dbo.UserInterests", name: "UserId", newName: "InterestName");
            RenameColumn(table: "dbo.UserInterests", name: "__mig_tmp__0", newName: "UserId");
            CreateIndex("dbo.UserInterests", "InterestName");
            CreateIndex("dbo.UserInterests", "UserId");
            CreateIndex("dbo.UserLanguages", "LanguageName");
            CreateIndex("dbo.UserLanguages", "UserId");
        }
    }
}
