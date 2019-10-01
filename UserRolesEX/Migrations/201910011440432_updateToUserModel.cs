namespace UserRolesEX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateToUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MI", c => c.String());
            AddColumn("dbo.AspNetUsers", "Justification", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Justification");
            DropColumn("dbo.AspNetUsers", "MI");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "UserID");
        }
    }
}
