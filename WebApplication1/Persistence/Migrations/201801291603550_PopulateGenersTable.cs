namespace EventsManagementWeb.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenersTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (ID, Name) Values (1, 'Jazz' ) ");
            Sql("Insert into Genres (ID, Name) Values (2, 'Blue' ) ");
            Sql("Insert into Genres (ID, Name) Values (3, 'Cai Luong' ) "); 

        }
        
        public override void Down()
        {
            Sql("Delete from  Genres  "); 
        }
    }
}
