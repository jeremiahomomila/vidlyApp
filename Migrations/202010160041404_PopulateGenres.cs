namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Thriller')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(4, 'Cartoon')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(5, 'Horror')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(6, 'Crime')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(7, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
