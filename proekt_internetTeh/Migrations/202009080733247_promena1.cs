namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promena1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Oglas_Id", "dbo.Oglas");
            DropForeignKey("dbo.Oglas", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Oglas_Id" });
            DropIndex("dbo.Oglas", new[] { "Category_Id" });
            DropColumn("dbo.Categories", "Oglas_Id");
            DropColumn("dbo.Oglas", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oglas", "Category_Id", c => c.Int());
            AddColumn("dbo.Categories", "Oglas_Id", c => c.Int());
            CreateIndex("dbo.Oglas", "Category_Id");
            CreateIndex("dbo.Categories", "Oglas_Id");
            AddForeignKey("dbo.Oglas", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Categories", "Oglas_Id", "dbo.Oglas", "Id");
        }
    }
}
