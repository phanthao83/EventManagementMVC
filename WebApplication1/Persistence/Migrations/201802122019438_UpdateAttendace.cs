namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAttendace : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Attendances", "GigID");
            AddForeignKey("dbo.Attendances", "GigID", "dbo.Gigs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "GigID", "dbo.Gigs");
            DropIndex("dbo.Attendances", new[] { "GigID" });
        }
    }
}
