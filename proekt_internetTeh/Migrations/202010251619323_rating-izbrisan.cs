namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingizbrisan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "Oglas_Id", "dbo.Oglas");
            DropIndex("dbo.Ratings", new[] { "Oglas_Id" });
            DropTable("dbo.Ratings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        email = c.String(),
                        oglas = c.Int(nullable: false),
                        Oglas_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Ratings", "Oglas_Id");
            AddForeignKey("dbo.Ratings", "Oglas_Id", "dbo.Oglas", "Id");
        }
    }
}
