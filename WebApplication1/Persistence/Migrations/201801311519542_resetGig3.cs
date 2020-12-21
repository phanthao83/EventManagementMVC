namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetGig3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigs", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropIndex("dbo.Gigs", new[] { "Genre_ID" });
            DropColumn("dbo.Gigs", "GenreID");
            DropColumn("dbo.Gigs", "ArtID");
            DropColumn("dbo.Gigs", "Artist_Id");
            DropColumn("dbo.Gigs", "Genre_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gigs", "Genre_ID", c => c.Byte());
            AddColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Gigs", "ArtID", c => c.Int(nullable: false));
            AddColumn("dbo.Gigs", "GenreID", c => c.Int(nullable: false));
            CreateIndex("dbo.Gigs", "Genre_ID");
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Genre_ID", "dbo.Genres", "ID");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
