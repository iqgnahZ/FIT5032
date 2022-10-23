namespace FIT5032Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePatients : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Patients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId);
            
        }
    }
}
