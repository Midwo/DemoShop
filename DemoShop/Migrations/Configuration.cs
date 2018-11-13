namespace DemoShop.Migrations
{
    using DemoShop.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<DemoShop.DAL.DemoShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DemoShop.DAL.DemoShopContext";
        }

        protected override void Seed(DemoShop.DAL.DemoShopContext context)
        {
            DemoShopInitializer.InsertData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
