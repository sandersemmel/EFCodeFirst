namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MovieReviews", new[] { "Person_PersonId" });
            DropColumn("dbo.MovieReviews", "MovieReviewId");
            RenameColumn(table: "dbo.MovieReviews", name: "Person_PersonId", newName: "MovieReviewId");
            DropPrimaryKey("dbo.MovieReviews");
            AddColumn("dbo.People", "MovieReviewId", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MovieReviews", "MovieReviewId");
            CreateIndex("dbo.MovieReviews", "MovieReviewId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MovieReviews", new[] { "MovieReviewId" });
            DropPrimaryKey("dbo.MovieReviews");
            AlterColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int());
            AlterColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.People", "MovieReviewId");
            AddPrimaryKey("dbo.MovieReviews", "MovieReviewId");
            RenameColumn(table: "dbo.MovieReviews", name: "MovieReviewId", newName: "Person_PersonId");
            AddColumn("dbo.MovieReviews", "MovieReviewId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.MovieReviews", "Person_PersonId");
        }
    }
}
