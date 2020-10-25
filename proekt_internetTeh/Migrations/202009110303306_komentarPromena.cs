namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class komentarPromena : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Komentars", "oglas_Id", "dbo.Oglas");
            DropIndex("dbo.Komentars", new[] { "oglas_Id" });
            AddColumn("dbo.Komentars", "oglasID", c => c.Int(nullable: false));
            DropColumn("dbo.Komentars", "oglas_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Komentars", "oglas_Id", c => c.Int());
            DropColumn("dbo.Komentars", "oglasID");
            CreateIndex("dbo.Komentars", "oglas_Id");
            AddForeignKey("dbo.Komentars", "oglas_Id", "dbo.Oglas", "Id");
        }
    }
}
