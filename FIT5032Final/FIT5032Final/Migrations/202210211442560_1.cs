namespace FIT5032Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "PatId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "DocId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Doctor_DoctorId", c => c.Int());
            AddColumn("dbo.Bookings", "Patient_PatientId", c => c.Int());
            CreateIndex("dbo.Bookings", "Doctor_DoctorId");
            CreateIndex("dbo.Bookings", "Patient_PatientId");
            AddForeignKey("dbo.Bookings", "Doctor_DoctorId", "dbo.Doctors", "DoctorId");
            AddForeignKey("dbo.Bookings", "Patient_PatientId", "dbo.Patients", "PatientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Patient_PatientId", "dbo.Patients");
            DropForeignKey("dbo.Bookings", "Doctor_DoctorId", "dbo.Doctors");
            DropIndex("dbo.Bookings", new[] { "Patient_PatientId" });
            DropIndex("dbo.Bookings", new[] { "Doctor_DoctorId" });
            DropColumn("dbo.Bookings", "Patient_PatientId");
            DropColumn("dbo.Bookings", "Doctor_DoctorId");
            DropColumn("dbo.Bookings", "DocId");
            DropColumn("dbo.Bookings", "PatId");
        }
    }
}
