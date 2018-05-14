namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MovieReviews", new[] { "Person_PersonId" });
            DropColumn("dbo.MovieReviews", "MovieReviewId");
            RenameColumn(table: "dbo.MovieReviews", name: "Person_PersonId", newName: "MovieReviewId");
            DropPrimaryKey("dbo.MovieReviews");
            AddColumn("dbo.MovieReviews", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.MovieReviews", "PersonId", c => c.Int(nullable: false));
            AddColumn("dbo.People", "MovieReviewId", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MovieReviews", "MovieReviewId");
            CreateIndex("dbo.MovieReviews", "MovieReviewId");
            CreateIndex("dbo.MovieReviews", "PersonId");
            AddForeignKey("dbo.MovieReviews", "PersonId", "dbo.Movies", "MovieId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieReviews", "PersonId", "dbo.Movies");
            DropIndex("dbo.MovieReviews", new[] { "PersonId" });
            DropIndex("dbo.MovieReviews", new[] { "MovieReviewId" });
            DropPrimaryKey("dbo.MovieReviews");
            AlterColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int());
            AlterColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.People", "MovieReviewId");
            DropColumn("dbo.MovieReviews", "PersonId");
            DropColumn("dbo.MovieReviews", "MovieId");
            AddPrimaryKey("dbo.MovieReviews", "MovieReviewId");
            RenameColumn(table: "dbo.MovieReviews", name: "MovieReviewId", newName: "Person_PersonId");
            AddColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.MovieReviews", "Person_PersonId");
        }
    }
}
