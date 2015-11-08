namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PwdHash", c => c.String(unicode: false));
            AddColumn("dbo.Users", "PwDSalt", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PwDSalt");
            DropColumn("dbo.Users", "PwdHash");
        }
    }
}
