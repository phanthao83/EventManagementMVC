namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        OrginalVenue = c.String(),
                        OrginalDateTime = c.DateTime(nullable: false),
                        Gig_ID = c.Int(),
                        OrginalGener_ID = c.Byte(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gigs", t => t.Gig_ID)
                .ForeignKey("dbo.Genres", t => t.OrginalGener_ID)
                .Index(t => t.Gig_ID)
                .Index(t => t.OrginalGener_ID);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        NotificationID = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.NotificationID })
                .ForeignKey("dbo.Notifications", t => t.NotificationID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.NotificationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "NotificationID", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "OrginalGener_ID", "dbo.Genres");
            DropForeignKey("dbo.Notifications", "Gig_ID", "dbo.Gigs");
            DropIndex("dbo.UserNotifications", new[] { "NotificationID" });
            DropIndex("dbo.UserNotifications", new[] { "UserID" });
            DropIndex("dbo.Notifications", new[] { "OrginalGener_ID" });
            DropIndex("dbo.Notifications", new[] { "Gig_ID" });
            DropTable("dbo.UserNotifications");
            DropTable("dbo.Notifications");
        }
    }
}
