namespace FIT5032Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDoctor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Ratings", new[] { "UserId" });
            RenameColumn(table: "dbo.Ratings", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Ratings", "PatientId", c => c.String(nullable: false));
            AddColumn("dbo.Ratings", "DoctorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Ratings", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ratings", "DoctorId");
            CreateIndex("dbo.Ratings", "User_Id");
            AddForeignKey("dbo.Ratings", "DoctorId", "dbo.Doctors", "DoctorId", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Ratings", new[] { "User_Id" });
            DropIndex("dbo.Ratings", new[] { "DoctorId" });
            AlterColumn("dbo.Ratings", "User_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Ratings", "DoctorId");
            DropColumn("dbo.Ratings", "PatientId");
            RenameColumn(table: "dbo.Ratings", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.Ratings", "UserId");
            AddForeignKey("dbo.Ratings", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
