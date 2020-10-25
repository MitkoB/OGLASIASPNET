namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class probnaRating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        email = c.String(),
                        oglas_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oglas", t => t.oglas_Id)
                .Index(t => t.oglas_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "oglas_Id", "dbo.Oglas");
            DropIndex("dbo.Ratings", new[] { "oglas_Id" });
            DropTable("dbo.Ratings");
        }
    }
}
