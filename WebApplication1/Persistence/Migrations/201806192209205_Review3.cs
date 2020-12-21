namespace EventsManagementWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Review3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GigReviews",
                c => new
                    {
                        GigId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Comment = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => new { t.GigId, t.UserId })
                .ForeignKey("dbo.Gigs", t => t.GigId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GigId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GigReviews", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GigReviews", "GigId", "dbo.Gigs");
            DropIndex("dbo.GigReviews", new[] { "UserId" });
            DropIndex("dbo.GigReviews", new[] { "GigId" });
            DropTable("dbo.GigReviews");
        }
    }
}
