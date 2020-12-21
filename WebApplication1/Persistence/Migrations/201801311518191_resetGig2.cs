namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetGig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "GenreID", c => c.Int(nullable: false));
            AddColumn("dbo.Gigs", "ArtID", c => c.Int(nullable: false));
            AddColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Gigs", "Genre_ID", c => c.Byte());
            CreateIndex("dbo.Gigs", "Artist_Id");
            CreateIndex("dbo.Gigs", "Genre_ID");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Gigs", "Genre_ID", "dbo.Genres", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Genre_ID", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Genre_ID" });
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropColumn("dbo.Gigs", "Genre_ID");
            DropColumn("dbo.Gigs", "Artist_Id");
            DropColumn("dbo.Gigs", "ArtID");
            DropColumn("dbo.Gigs", "GenreID");
        }
    }
}
