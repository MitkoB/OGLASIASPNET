namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promena3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Oglas", "Favorite_Id", c => c.Int());
            CreateIndex("dbo.Oglas", "Favorite_Id");
            AddForeignKey("dbo.Oglas", "Favorite_Id", "dbo.Favorites", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oglas", "Favorite_Id", "dbo.Favorites");
            DropIndex("dbo.Oglas", new[] { "Favorite_Id" });
            DropColumn("dbo.Oglas", "Favorite_Id");
            DropTable("dbo.Favorites");
        }
    }
}
