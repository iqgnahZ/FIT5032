namespace FIT5032Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatients : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(maxLength: 30));
        }
    }
}
