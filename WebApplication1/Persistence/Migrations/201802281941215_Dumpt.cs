namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dumpt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "Gig_ID", "dbo.Gigs");
            DropIndex("dbo.Notifications", new[] { "Gig_ID" });
            AlterColumn("dbo.Notifications", "Gig_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "Gig_ID");
            AddForeignKey("dbo.Notifications", "Gig_ID", "dbo.Gigs", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Gig_ID", "dbo.Gigs");
            DropIndex("dbo.Notifications", new[] { "Gig_ID" });
            AlterColumn("dbo.Notifications", "Gig_ID", c => c.Int());
            CreateIndex("dbo.Notifications", "Gig_ID");
            AddForeignKey("dbo.Notifications", "Gig_ID", "dbo.Gigs", "ID");
        }
    }
}
