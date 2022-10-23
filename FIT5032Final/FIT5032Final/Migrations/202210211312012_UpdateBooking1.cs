namespace FIT5032Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBooking1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Doctor_DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Bookings", "Patient_PatientId", "dbo.Patients");
            DropIndex("dbo.Bookings", new[] { "Doctor_DoctorId" });
            DropIndex("dbo.Bookings", new[] { "Patient_PatientId" });
            DropColumn("dbo.Bookings", "PatId");
            DropColumn("dbo.Bookings", "DocId");
            DropColumn("dbo.Bookings", "Doctor_DoctorId");
            DropColumn("dbo.Bookings", "Patient_PatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Patient_PatientId", c => c.Int());
            AddColumn("dbo.Bookings", "Doctor_DoctorId", c => c.Int());
            AddColumn("dbo.Bookings", "DocId", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "PatId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "Patient_PatientId");
            CreateIndex("dbo.Bookings", "Doctor_DoctorId");
            AddForeignKey("dbo.Bookings", "Patient_PatientId", "dbo.Patients", "PatientId");
            AddForeignKey("dbo.Bookings", "Doctor_DoctorId", "dbo.Doctors", "DoctorId");
        }
    }
}
