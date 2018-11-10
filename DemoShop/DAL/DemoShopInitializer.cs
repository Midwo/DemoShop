using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DemoShop.DAL
{
    public class DemoShopInitializer : DropCreateDatabaseAlways<DemoShopContext>
    {
        protected override void Seed(DemoShopContext context)
        {
            InsertData(context);

            base.Seed(context);
        }
        private void InsertData(DemoShopContext context)
        {
            var category = new List<Category>
            {
                new Category() {CategoryID = 1, Title = "Zabezpieczenia", Description ="Asortyment związany z bezpieczeństem i ochroną dzieci", Active = true, FileNamePhoto = "icons8-protect-30.png" },
                new Category() {CategoryID = 2, Title = "Zabawki", Description = "Asortyment związany z zabawkami: misie, grzechotki oraz inne", Active = true, FileNamePhoto ="icons8-beach-ball-30.png" },
                new Category() {CategoryID = 3, Title = "Ubrania", Description = "Asortyment związany z ubraniami: koszulki, spodenki, skarpetki, kombinezony oraz inne", Active = true, FileNamePhoto = "icons8-clothes-30.png" },
                new Category() {CategoryID = 4, Title = "Edukacja", Description ="Asortyment związany z edukacją małych dzieci: książki, koski oraz inne", Active = true, FileNamePhoto = "icons8-school-30.png"},
                new Category() {CategoryID = 5, Title = "Instumenty", Description ="Asortyment związany z muzyka: instrument dla dzieci", Active = true, FileNamePhoto = "icons8-musical-notes-30.png" },
                new Category() {CategoryID = 6, Title = "Monitoring", Description = "Asortyment związany z monitorowaniem: kamery, czujniki oraz alarmy", Active = true, FileNamePhoto ="icons8-video-camera-30.png" },
                new Category() {CategoryID = 7, Title = "Przybory", Description = "Asortyment związany z przyborami: zeszyty, kredki, ołówki oraz inne", Active = true, FileNamePhoto = "icons8-design-30.png" },
                new Category() {CategoryID = 8, Title = "Inne", Description ="Asortyment nie związany z głównymi kategoria w sklepie", Active = true, FileNamePhoto = "icons8-select-all-30.png"}
            };
            category.ForEach(g => context.Categories.AddOrUpdate(g));
            context.SaveChanges();

            var product = new List<Product>
            {
                new Product() { CategoryID = 1, ProductTitle ="Hełm rowerowy", Price =  350.99m, Description = "Hełm rowerowy przeznaczony dla dzieci w wieku od 4 do 7 lat. Stworzony, by chronić Waszą pociechę. Zbudowany z mieszanki polistyrenu oraz styropianu. Skład: 90% styropianu, 10% polistyren.", Manufacturer ="SecureBrain Technology Sap", Promotion = false, TheBestProduct = false, Weight = 300m, FileNamePhoto = "1.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="Hełm wspinaczkowy", Price =  400.30m, Description = "Hełm wspinaczkowy przeznaczony dla dzieci chcących spędzać aktywnie czas z rodzicami. Stworzony, by chronić Waszą pociechę. Zbudwany w 100% z polistyrenu", Manufacturer ="SecureBrain Technology Sap", Promotion = false, TheBestProduct = false, Weight = 170.5m, FileNamePhoto = "2.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="Zestaw medyczny", Price =  36.99m, Description = "Zestaw przeznaczony do udzielania pierwszej pomocy. Skład: ustnik, rękawiczki, bandaż, plaster oraz nożyczki. Data przydatności: 5 lat od momentu zamówienia", Manufacturer ="SecureFirst Company SP.Zoo", Promotion = false, TheBestProduct = false, Weight = 70.4m, FileNamePhoto = "3.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 2, ProductTitle ="Kostka rubika", Price =  29.99m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "4.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 2, ProductTitle ="Bączek", Price =  24.23m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "5.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 2, ProductTitle ="Miś brązowy", Price =  53.1m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "6.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 2, ProductTitle ="Kaczka do kąpieli", Price =  9.98m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "7.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 2, ProductTitle ="Samoloty nad łóżko", Price =  31.9m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "8.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 2, ProductTitle ="Miś biały", Price =  60.2m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "9.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 2, ProductTitle ="Uśmiechnięta lama", Price =  57.35m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "10.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 2, ProductTitle ="Miły słonik", Price =  99.75m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "11.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "12.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "13.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "14.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "15.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "16.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "17.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "18.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "19.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "20.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "21.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "22.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "23.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "24.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "25.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "26.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "27.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "28.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "29.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "30.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "31.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "32.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "33.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "34.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "35.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "36.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "37.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "38.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "39.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "40.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "41.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "42.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "43.jpg" ,AddDate = DateTime.Now, Active = true },
                new Product() { CategoryID = 1, ProductTitle ="title", Price =  4.3m, Description = "description", Manufacturer ="Manufacturer", Promotion = false, TheBestProduct = false, Weight = 30.5m, FileNamePhoto = "44.jpg" ,AddDate = DateTime.Now, Active = true },
            };
            product.ForEach(g => context.Products.AddOrUpdate(g));
            context.SaveChanges();
        }
    }
}