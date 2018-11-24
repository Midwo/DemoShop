namespace DemoShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNewFieldWithUserInformation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserInformation_Name", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserInformation_Surname", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserInformation_City", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserInformation_CityCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserInformation_Street", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserInformation_ApartmentNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserInformation_Phone", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserInformation_Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserInformation_Email", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "UserInformation_Phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.AspNetUsers", "UserInformation_ApartmentNumber", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.AspNetUsers", "UserInformation_Street", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.AspNetUsers", "UserInformation_CityCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.AspNetUsers", "UserInformation_City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "UserInformation_Surname", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.AspNetUsers", "UserInformation_Name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
