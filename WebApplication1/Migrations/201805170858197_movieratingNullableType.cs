namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieratingNullableType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MOVIEREVIEW", "MovieRating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MOVIEREVIEW", "MovieRating", c => c.Int(nullable: false));
        }
    }
}
