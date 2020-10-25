namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class probnaRating1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Ratings", new[] { "oglas_Id" });
            AddColumn("dbo.Ratings", "oglas", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "Oglas_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ratings", new[] { "Oglas_Id" });
            DropColumn("dbo.Ratings", "oglas");
            CreateIndex("dbo.Ratings", "oglas_Id");
        }
    }
}
