namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentState", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentState");
        }
    }
}
