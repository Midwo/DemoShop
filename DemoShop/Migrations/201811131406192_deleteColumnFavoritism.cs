namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteColumnFavoritism : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Favoritism");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Favoritism", c => c.Boolean(nullable: false));
        }
    }
}
