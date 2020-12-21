namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGigCancellation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "IsCancelled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gigs", "IsCancelled");
        }
    }
}
