namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetGig6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Gigs", name: "Artist_Id", newName: "ArtistID");
            RenameColumn(table: "dbo.Gigs", name: "Genre_ID", newName: "GenreID");
            RenameIndex(table: "dbo.Gigs", name: "IX_Genre_ID", newName: "IX_GenreID");
            RenameIndex(table: "dbo.Gigs", name: "IX_Artist_Id", newName: "IX_ArtistID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Gigs", name: "IX_ArtistID", newName: "IX_Artist_Id");
            RenameIndex(table: "dbo.Gigs", name: "IX_GenreID", newName: "IX_Genre_ID");
            RenameColumn(table: "dbo.Gigs", name: "GenreID", newName: "Genre_ID");
            RenameColumn(table: "dbo.Gigs", name: "ArtistID", newName: "Artist_Id");
        }
    }
}
