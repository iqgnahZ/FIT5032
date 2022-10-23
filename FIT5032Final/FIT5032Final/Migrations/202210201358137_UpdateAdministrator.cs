namespace FIT5032Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdministrator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Administrators", "AdministratorName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Administrators", "AdministratorName");
        }
    }
}
