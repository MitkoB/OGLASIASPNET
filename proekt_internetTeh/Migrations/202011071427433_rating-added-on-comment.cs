namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingaddedoncomment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Komentars", "rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Komentars", "rating");
        }
    }
}
