namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oglas", "cena", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oglas", "cena");
        }
    }
}
