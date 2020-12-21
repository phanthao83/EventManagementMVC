namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetGig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "GenreID", c => c.Byte(nullable: false));
            AddColumn("dbo.Gigs", "ArtistID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Gigs", "GenreID");
            CreateIndex("dbo.Gigs", "ArtistID");
            AddForeignKey("dbo.Gigs", "ArtistID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Gigs", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "ArtistID", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "ArtistID" });
            DropIndex("dbo.Gigs", new[] { "GenreID" });
            DropColumn("dbo.Gigs", "ArtistID");
            DropColumn("dbo.Gigs", "GenreID");
        }
    }
}
