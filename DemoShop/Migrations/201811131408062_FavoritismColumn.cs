namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoritismColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Favoritism", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Favoritism");
        }
    }
}
