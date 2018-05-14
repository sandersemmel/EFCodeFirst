namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieReviews",
                c => new
                    {
                        MovieReviewId = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.MovieReviewId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieReviews", "Person_PersonId", "dbo.People");
            DropIndex("dbo.MovieReviews", new[] { "Person_PersonId" });
            DropTable("dbo.People");
            DropTable("dbo.MovieReviews");
            DropTable("dbo.Movies");
        }
    }
}
