namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Komentars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        komentar = c.String(),
                        oglas_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Oglas", t => t.oglas_Id)
                .Index(t => t.oglas_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Komentars", "oglas_Id", "dbo.Oglas");
            DropIndex("dbo.Komentars", new[] { "oglas_Id" });
            DropTable("dbo.Komentars");
        }
    }
}
