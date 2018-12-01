namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeclareDatetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "DateShipped", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DateShipped", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
