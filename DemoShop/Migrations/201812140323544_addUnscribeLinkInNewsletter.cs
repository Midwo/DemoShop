namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUnscribeLinkInNewsletter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Newsletters", "UnscribeLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Newsletters", "UnscribeLink");
        }
    }
}
