namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shippingcost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShippingCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ShippingCost");
        }
    }
}
