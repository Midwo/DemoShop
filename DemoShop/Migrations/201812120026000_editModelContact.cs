namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editModelContact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Phone", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Phone", c => c.String(nullable: false));
        }
    }
}
