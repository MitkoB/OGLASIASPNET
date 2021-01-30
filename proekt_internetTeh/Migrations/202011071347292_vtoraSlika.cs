namespace proekt_internetTeh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vtoraSlika : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Oglas", "urlSlika2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Oglas", "urlSlika2");
        }
    }
}
