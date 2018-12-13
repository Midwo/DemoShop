namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsletterAndContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        SentAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Newsletters",
                c => new
                    {
                        NewsletterID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        UniscribeCode = c.String(),
                    })
                .PrimaryKey(t => t.NewsletterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Newsletters");
            DropTable("dbo.Contacts");
        }
    }
}
