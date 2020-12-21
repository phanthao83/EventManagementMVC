namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        GigID = c.Int(nullable: false),
                        AttendeeID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GigID, t.AttendeeID })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeID, cascadeDelete: true)
                .Index(t => t.AttendeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "AttendeeID", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeID" });
            DropTable("dbo.Attendances");
        }
    }
}
