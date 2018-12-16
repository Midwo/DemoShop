namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editNewsletterClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Newsletters", "UnscribeCode", c => c.String());
            DropColumn("dbo.Newsletters", "UniscribeCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Newsletters", "UniscribeCode", c => c.String());
            DropColumn("dbo.Newsletters", "UnscribeCode");
        }
    }
}
