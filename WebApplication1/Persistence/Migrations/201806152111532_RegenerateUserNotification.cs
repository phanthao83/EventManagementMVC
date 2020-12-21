namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegenerateUserNotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserNotifications", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserNotifications", "Comment");
        }
    }
}
