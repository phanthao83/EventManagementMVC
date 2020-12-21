namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGigFK2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "ArtID", c => c.Int(nullable: false));
            AddColumn("dbo.Gigs", "GenreID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gigs", "GenreID");
            DropColumn("dbo.Gigs", "ArtID");
        }
    }
}
