﻿using DemoShop.Migrations;
using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DemoShop.DAL
{
    public class DemoShopInitializer : MigrateDatabaseToLatestVersion<DemoShopContext, Configuration>
    {
        //protected override void Seed(DemoShopContext context)
        //{
        //    InsertData(context);

        //    base.Seed(context);
        //}
        public static void InsertData(DemoShopContext context)
        {
            var category = new List<Category>
            {
                new Category() {CategoryID = 1,
                    Title = "Zabezpieczenia",
                    Description ="Asortyment związany z bezpieczeństem i ochroną dzieci",
                    Active = true,
                    FileNamePhoto = "icons8-protect-30.png" },
                new Category() {CategoryID = 2,
                    Title = "Zabawki",
                    Description = "Asortyment związany z zabawkami: misie, grzechotki oraz inne",
                    Active = true,
                    FileNamePhoto ="icons8-beach-ball-30.png" },
                new Category() {CategoryID = 3,
                    Title = "Ubrania",
                    Description = "Asortyment związany z ubraniami: koszulki, spodenki, skarpetki, kombinezony oraz inne",
                    Active = true,
                    FileNamePhoto = "icons8-clothes-30.png" },
                new Category() {CategoryID = 4,
                    Title = "Edukacja",
                    Description ="Asortyment związany z edukacją małych dzieci: książki, koski oraz inne",
                    Active = true,
                    FileNamePhoto = "icons8-school-30.png"},
                new Category() {CategoryID = 5,
                    Title = "Instumenty",
                    Description ="Asortyment związany z muzyka: instrument dla dzieci",
                    Active = true,
                    FileNamePhoto = "icons8-musical-notes-30.png" },
                new Category() {CategoryID = 6,
                    Title = "Monitoring",
                    Description = "Asortyment związany z monitorowaniem: kamery, czujniki oraz alarmy",
                    Active = true,
                    FileNamePhoto ="icons8-video-camera-30.png" },
                new Category() {CategoryID = 7,
                    Title = "Przybory",
                    Description = "Asortyment związany z przyborami: zeszyty, kredki, ołówki oraz inne",
                    Active = true,
                    FileNamePhoto = "icons8-design-30.png" },
                new Category() {CategoryID = 8,
                    Title = "Inne",
                    Description ="Asortyment nie związany z głównymi kategoria w sklepie",
                    Active = true,
                    FileNamePhoto = "icons8-select-all-30.png"},
                new Category() {CategoryID = 9,
                    Title = "Nieaktywna",
                    Description ="Nieaktywna kategoria",
                    Active = false,
                    FileNamePhoto = "icons8-select-all-30.png"}
            };
            category.ForEach(g => context.Categories.AddOrUpdate(g));
            context.SaveChanges();

            //remove because i used datetime.now.addminutes under
            context.Products.RemoveRange(context.Products);
            context.SaveChanges();

            var product = new List<Product>
            {
                new Product() { CategoryID = 1,
                    ProductTitle ="Kask rowerowy",
                    Price =  350.99m,
                    Description = "Kask rowerowy przeznaczony dla dzieci w wieku od 4 do 7 lat. Stworzony, by chronić Waszą pociechę. Zbudowany z mieszanki polistyrenu oraz styropianu. Skład: 90% styropianu, 10% polistyren.",
                    Manufacturer ="SecureBrain Technology Sap",
                    Promotion = true,
                    TheBestProduct = false,
                    Weight = 0.3m,
                    FileNamePhoto = "1.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-10),
                    Active = true },
                new Product() { CategoryID = 1,
                    ProductTitle ="Kask wspinaczkowy",
                    Price =  400.3m,
                    Description = "Kask wspinaczkowy przeznaczony dla dzieci chcących spędzać aktywnie czas z rodzicami. Stworzony, by chronić Waszą pociechę. Zbudwany w 100% z polistyrenu",
                    Manufacturer ="SecureBrain Technology Sap",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.17m,
                    FileNamePhoto = "2.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-11),
                    Active = true },
                new Product() { CategoryID = 1,
                    ProductTitle ="Zestaw medyczny",
                    Price =  36.99m,
                    Description = "Zestaw przeznaczony do udzielania pierwszej pomocy. Skład: ustnik, rękawiczki, bandaż, plaster oraz nożyczki. Data przydatności: 5 lat od momentu zamówienia",
                    Manufacturer ="SecureFirst Company SP.Zoo",
                    Promotion = false, TheBestProduct = false,
                    Weight = 0.71m,
                    FileNamePhoto = "3.jpeg" ,
                    AddDate = DateTime.Now.AddMinutes(-13),
                    Active = true },
                new Product() { CategoryID = 2,
                    ProductTitle ="Kostka rubika",
                    Price =  29.99m,
                    Description = "Prosta kostka Rubika przeznaczona do grania samemu jak i z rodziną. Dzięki niesamowitej jakości kostki, możliwe jest jej wykorzystywanie również na profesjonalnych turniejach kostkowych. Z tą kostką, zdobędziesz lepszy czas niż na innych.",
                    Manufacturer ="Toy Super Joy",
                    Promotion = true,
                    TheBestProduct = false,
                    Weight = 0.1m,
                    FileNamePhoto = "4.jpg",
                    AddDate = DateTime.Now.AddMinutes(-15),
                    Active = true },
                new Product() { CategoryID = 2,
                    ProductTitle ="Bączek",
                    Price =  24.23m,
                    Description = "Bączek dla dzieci: przeznaczony dla 2-11 latków. Sprawia radość nie tylko dzieciom ale i również ich  rodzicom. Zalecany jako pierwsza zabawka interaktywna.",
                    Manufacturer ="Toy Maniac Sonc",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.14m,
                    FileNamePhoto = "5.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-17),
                    Active = true },
                new Product() { CategoryID = 2,
                    ProductTitle ="Miś brązowy",
                    Price =  53.1m,
                    Description = "Brązowy Miś jest maskotką najwyżej jakości. Cechuje go świetne wykonanie oraz wytrzymałość na wszelkiego rodzaju szarpania, czy też ciągnięcia.",
                    Manufacturer ="Toy Super Joy",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.30m,
                    FileNamePhoto = "6.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-19),
                    Active = true },
                new Product() { CategoryID = 2,
                    ProductTitle ="Kaczka do kąpieli",
                    Price =  9.98m,
                    Description = "Kaczka przeznaczona do kąpieli dla maluchów w wieku 1-10 lat. Jest bezpieczna i spełnia wszystkie najwyższe normy pochodzące z Unii Europejskiej. Nie istnieje możliwość zachłyśnięcia się kaczką – nie jest możliwe zmieszczenie jej w buzi.",
                    Manufacturer ="Toy Maniac Sonc",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.07m,
                    FileNamePhoto = "7.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-12),
                    Active = true },
                new Product() { CategoryID = 2,
                    ProductTitle ="Samoloty nad łóżko",
                    Price =  32.9m,
                    Description = "Zestaw do powieszenia nad łóżkiem dziecięcym. Składa się z 8 różnokolorowych samolotów wykonanych z prawdziwego drewna (sosny praskiej) pomalowanych 100% bezpieczną farbą – nie szkodzącą w przypadku próby spożycia jej.",
                    Manufacturer ="Toy Maniac Sonc",
                    Promotion = false,
                    TheBestProduct = true,
                    Weight = 0.2m,
                    FileNamePhoto = "8.jpeg",
                    AddDate = DateTime.Now,
                    Active = true },
                new Product() {
                    CategoryID = 2,
                    ProductTitle ="Miś biały",
                    Price =  60.2m,
                    Description = "Biały Miś jest maskotką najwyżej jakości. Cechuje go świetne wykonanie oraz wytrzymałość na wszelkiego rodzaju szarpania, czy też ciągnięcia.",
                    Manufacturer ="For Kids Technology",
                    Promotion = false,
                    TheBestProduct = true,
                    Weight = 0.09m,
                    FileNamePhoto = "9.jpg",
                    AddDate = DateTime.Now.AddMinutes(-11),
                    Active = true },
                new Product() { CategoryID = 2,
                    ProductTitle ="Uśmiechnięta lama",
                    Price =  57.35m,
                    Description = "Uśmiechnięta lama jest maskotką najwyżej jakości. Cechuje go świetne wykonanie oraz wytrzymałość na wszelkiego rodzaju szarpania, czy też ciągnięcia.",
                    Manufacturer ="For Kids Technology",
                    Promotion = true,
                    TheBestProduct = false,
                    Weight = 0.89m,
                    FileNamePhoto = "10.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-11),
                    Active = true },
                new Product() { CategoryID = 2,
                    ProductTitle ="Miły słonik",
                    Price =  99.75m,
                    Description = "Miły słonik jest maskotką najwyżej jakości. Cechuje go świetne wykonanie oraz wytrzymałość na wszelkiego rodzaju szarpania, czy też ciągnięcia.",
                    Manufacturer ="Do While Technology",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.12m,
                    FileNamePhoto = "11.jpeg",
                    AddDate = DateTime.Now,
                    Active = true },
                new Product() { CategoryID = 3,
                    ProductTitle ="Kostium astronauty",
                    Price =  899.99m,
                    Description = "Kostium astronauty składa się z: kasku astronauty, butów astronauty oraz kombinezonu astronauty. Idealny kostium na wszelkiego rodzaje karnawały, czy też Halloween. Sprawdź sobie i dziecku radość najwyższych lotów!",
                    Manufacturer ="Do While Technology",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 1.500m,
                    FileNamePhoto = "12.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-17),
                    Active = true },
                new Product() { CategoryID = 3,
                    ProductTitle ="Buciki Letnie",
                    Price =  113.3m,
                    Description = "Buciki letnie przeznaczone są dla dzieci o rozmiarze stopy: 9-12. Świetnie leżą na nodze i pokazują jak bardzo ładnie wygląda Twoje dziecko. Wszyscy rodzice będą zazdrościć Twojemu – tych szykownych i wspaniałych jakościowo butów.",
                    Manufacturer ="Boots Perfekt Company",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.07m,
                    FileNamePhoto = "13.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-1),
                    Active = true },
                new Product() { CategoryID = 3,
                    ProductTitle ="Domowe skarpetki",
                    Price =  42.99m,
                    Description = "Domowe skarpetki dla dzieci o rozmiarze stopy 9-15. Świetnie chronią i ocieplają stopy Twojego dziecka. Spraw przyjemność i radość swojemu dziecku luksusowymi skarpetkami, które zostały wykonane w stu procentach ręcznymi metodami produkcyjnymi.",
                    Manufacturer ="The Best Socks",
                    Promotion = true,
                    TheBestProduct = false,
                    Weight = 0.043m,
                    FileNamePhoto = "14.jpeg"
                    ,AddDate = DateTime.Now.AddMinutes(-2),
                    Active = true },
                new Product() { CategoryID = 3,
                    ProductTitle ="Słodkie buty",
                    Price =  79.97m,
                    Description = "Słodkie buty przeznaczone są dla dzieci o rozmiarze stopy: 9-12. Świetnie leżą na nodze i pokazują jak bardzo ładnie wygląda Twoje dziecko. Wszyscy rodzice będą zazdrościć Twojemu – tych szykownych i wspaniałych jakościowo butów.",
                    Manufacturer ="For Kids Ew",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.09m,
                    FileNamePhoto = "15.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-11),
                    Active = true },
                new Product() { CategoryID = 3,
                    ProductTitle ="Jedwabne buty",
                    Price =  299m,
                    Description = "Jedwabne buty przeznaczone są dla dzieci o rozmiarze stopy: 9-12. Świetnie leżą na nodze i pokazują jak bardzo ładnie wygląda Twoje dziecko. Wszyscy rodzice będą zazdrościć Twojemu – tych szykownych i wspaniałych jakościowo butów.",
                    Manufacturer ="Jedwab dla Ciebie",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.1m,
                    FileNamePhoto = "16.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-21),
                    Active = true },
                new Product() { CategoryID = 3,
                    ProductTitle ="Balerinki",
                    Price =  150m,
                    Description = "Balerinki przeznaczone są dla dzieci o rozmiarze stopy: 9-12. Świetnie leżą na nodze i pokazują jak bardzo ładnie wygląda Twoje dziecko. Wszyscy rodzice będą zazdrościć Twojemu – tych szykownych i wspaniałych jakościowo butów. Niech Twoje dziecko poczuje siłę w nogach i zatańczy jak najlepsza balerina!",
                    Manufacturer ="Dance Boots Kids",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.07m,
                    FileNamePhoto = "17.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-31),
                    Active = true },
                new Product() { CategoryID = 3,
                    ProductTitle ="Jesienne butki",
                    Price =  189.9m,
                    Description = "Jesienne buty przeznaczone są dla dzieci o rozmiarze stopy: 9-12. Świetnie leżą na nodze i pokazują jak bardzo ładnie wygląda Twoje dziecko. Wszyscy rodzice będą zazdrościć Twojemu – tych szykownych i wspaniałych jakościowo butów.",
                    Manufacturer ="Season Boots Kids",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.14m,
                    FileNamePhoto = "18.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-41),
                    Active = true },
                new Product() { CategoryID = 4,
                    ProductTitle ="Nauka programowania",
                    Price =  59.89m,
                    Description = "Książka przeznaczona dla dzieci – wprowadza je do świata programowania od najmłodszych lat. Wyszkol swojego specjalistę już za młodu – może dokona dzięki temu nie jednego sukcesu w swoim życiu.",
                    Manufacturer ="Books for Kids",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.5m,
                    FileNamePhoto = "19.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-11),
                    Active = true },
                new Product() { CategoryID = 4,
                    ProductTitle ="Baśń dla dzieci",
                    Price =  96.8m,
                    Description = "Książka przeznaczona dla dzieci – wprowadza je do świata baśni 1001 nocy od najmłodszych lat. Bądź wzorowym rodzicem i czytaj dziecku zawsze przed spaniem, spraw mu radość i uśmiech na ustaw. Dobre uczynki i miłe chwile – powiększą Wasze rodzinne relacje.",
                    Manufacturer ="Books for Kids",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.21m,
                    FileNamePhoto = "20.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-31),
                    Active = true },
                new Product() { CategoryID = 4,
                    ProductTitle ="Kolorowe liczydło",
                    Price =  17.99m,
                    Description = "Liczydło przeznaczone do nauki liczenia dla dzieci. Bądź prawdziwym rodzicem dbającym o swoją pociechę i naucz go sam liczenia. Spraw dziecku radość i edukuj je. Być może dzięki temu stworzysz nowego geniusza we własnym domu!",
                    Manufacturer ="Calc Tech News",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.90m,
                    FileNamePhoto = "21.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-1),
                    Active = true },
                new Product() { CategoryID = 5,
                    ProductTitle ="Gitara klasyczna",
                    Price =  899.97m,
                    Description = "Classic Guitars Company",
                    Manufacturer ="Gitara klasyczna firmy Classic Guitars Company jest świetnym produktem dostępnym w naszym sklepie. Zbudowana jest z świetnej jakości sklejki paździerzowej zapewniającej fantastyczne wrażenia dźwiękowe i akustyczne. Łatwość grania i wybijania rytmów na gitarze plasuje ją wśród czołowych gitar na rynku. Tą gitarą nauczysz swoją pociechę grać na prawdziwym i najlepszym klasyku.",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 2.4m,
                    FileNamePhoto = "22.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-41),
                    Active = true },
                new Product() { CategoryID = 5, ProductTitle ="Gitara junior+",
                    Price =  2999.98m,
                    Description = "Gitara Junior+ jest świetnym produktem dostępnym w naszym sklepie. Zbudowana jest z świetnej jakości sklejki paździerzowej zapewniającej fantastyczne wrażenia dźwiękowe i akustyczne. Łatwość grania i wybijania rytmów na gitarze plasuje ją wśród czołowych gitar na rynku. Tą gitarą nauczysz swoją pociechę grać na prawdziwym i najlepszym elektryku.",
                    Manufacturer ="Junior Guitars",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 3.3m,
                    FileNamePhoto = "23.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-51),
                    Active = true },
                new Product() { CategoryID = 5,
                    ProductTitle ="Gitara dziecięca",
                    Price =  3999.97m,
                    Description = "Gitara dziecięca jest świetnym produktem dostępnym w naszym sklepie. Zbudowana jest z świetnej jakości sklejki paździerzowej zapewniającej fantastyczne wrażenia dźwiękowe i akustyczne. Łatwość grania i wybijania rytmów na gitarze plasuje ją wśród czołowych gitar na rynku. Tą gitarą nauczysz swoją pociechę grać na prawdziwym i najlepszym elektryku.",
                    Manufacturer ="Gitarszkon SPZ",
                    Promotion = false,
                    TheBestProduct = true,
                    Weight = 3.1m,
                    FileNamePhoto = "24.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-31),
                    Active = true },
                new Product() { CategoryID = 5,
                    ProductTitle ="Czarny fortepian",
                    Price =  60000m,
                    Description = "Czarny fortepian to produkt najwyższych lotów. Został wykonany ręcznie z naturalnego drewna. Muzyka, która z niego płynie jest najlepszą jaką można uzyskać z instrumentu. Grając na nim poczujesz, co to jest wyjątkowa jakość i piękno muzyki.",
                    Manufacturer ="Fore Piano",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 180.5m,
                    FileNamePhoto = "25.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-51),
                    Active = true },
                new Product() { CategoryID = 5,
                    ProductTitle ="Fortepian dębowy",
                    Price =  46000m,
                    Description = "Fortepian dębowy to produkt najwyższych lotów. Został wykonany ręcznie z naturalnego drewna. Muzyka, która z niego płynie jest najlepszą jaką można uzyskać z instrumentu. Grając na nim poczujesz, co to jest wyjątkowa jakość i piękno muzyki.",
                    Manufacturer ="Fore Piano",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 250m,
                    FileNamePhoto = "26.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-31),
                    Active = true },
                new Product() { CategoryID = 6,
                    ProductTitle ="Kamera osiedlowa",
                    Price =  900m,
                    Description = "Kamera osiedlowa zapewniająca wysokiej jakości obraz. Dzięki niej Twój dom jak i bliscy będą czuć się bezpiecznie. Boisz się bandytów, bądź złodziei? Dzięki niej sprawisz, że zmienisz na ten temat zdanie! Kamera zapewnia sprawność działania na poziomie 99,9%.",
                    Manufacturer ="Cam Company Flow",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 3m,
                    FileNamePhoto = "27.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-51),
                    Active = true },
                new Product() { CategoryID = 6,
                    ProductTitle ="Kamera IP live",
                    Price =  1003.2m,
                    Description = "Kamera IP live zapewniająca wysokiej jakości obraz. Dzięki niej Twój dom jak i bliscy będą czuć się bezpiecznie. Boisz się bandytów, bądź złodziei? Dzięki niej sprawisz, że zmienisz na ten temat zdanie! Kamera zapewnia sprawność działania na poziomie 99,9%.",
                    Manufacturer ="Cam Company Flow",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 3.5m,
                    FileNamePhoto = "28.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-33),
                    Active = true },
                new Product() { CategoryID = 6,
                    ProductTitle ="Kamera 4K",
                    Price =  5000m,
                    Description = "Kamera 4K zapewniająca wysokiej jakości obraz. Dzięki niej Twój dom jak i bliscy będą czuć się bezpiecznie. Boisz się bandytów, bądź złodziei? Dzięki niej sprawisz, że zmienisz na ten temat zdanie! Kamera zapewnia sprawność działania na poziomie 99,9%.",
                    Manufacturer ="Cam Company Flow",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 4.5m,
                    FileNamePhoto = "29.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-21),
                    Active = true },
                new Product() { CategoryID = 6,
                    ProductTitle ="Kamera HD Night",
                    Price =  3400m,
                    Description = "Kamera IP live zapewniająca wysokiej jakości obraz. Dzięki niej Twój dom jak i bliscy będą czuć się bezpiecznie. Boisz się bandytów, bądź złodziei? Dzięki niej sprawisz, że zmienisz na ten temat zdanie! Kamera zapewnia sprawność działania na poziomie 99,9%.",
                    Manufacturer ="Cam Company Flow",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 3.7m,
                    FileNamePhoto = "30.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-31),
                    Active = true },
                new Product() { CategoryID = 6,
                    ProductTitle ="Dron śledzący",
                    Price =  7000m,
                    Description = "Dron śledzący – jest to produkt służący do śledzenia Twojego dziecka. Po każdym opuszczeniu przez Twoje dziecko lokalizacji zamieszkania dron w niewidoczny sposób zaczyna je śledzić. Czas działania drona wynosi 5h po pełnym naładowaniu. W dronie znajduje się system GPS oraz kamera HD.",
                    Manufacturer ="Dron SP",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 5.5m,
                    FileNamePhoto = "31.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-41),
                    Active = true },
                new Product() { CategoryID = 6,
                    ProductTitle ="Dron śledzący+",
                    Price =  8400m,
                    Description = "Dron śledzący+ – jest to produkt służący do śledzenia Twojego dziecka. Po każdym opuszczeniu przez Twoje dziecko lokalizacji zamieszkania dron w niewidoczny sposób zaczyna je śledzić. Czas działania drona wynosi 7h po pełnym naładowaniu. W dronie znajduje się system GPS oraz kamera HD.",
                    Manufacturer ="Dron SP",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 6.5m,
                    FileNamePhoto = "32.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-41),
                    Active = true },
                new Product() { CategoryID = 7,
                    ProductTitle ="Kredki",
                    Price =  17.9m,
                    Description = "Zestaw 16 świetnej jakości kolorowych kredek. Z nimi Twoje dziecko z pewnością stworzy nie jeden piękny rysunek i zaimponuje wszystkim w Twojej rodzinie. Kredki są wytrzymałe i twarde przy jednoczesnym ukazywaniu ciepłych barw.",
                    Manufacturer ="Colors Full SP",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.05m,
                    FileNamePhoto = "33.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-1),
                    Active = true },
                new Product() { CategoryID = 7,
                    ProductTitle ="Ołówek",
                    Price =  7.3m,
                    Description = "Wysokiej jakości ołówek rysunkowo-techniczny. Można nim wykonywać: szkice, zaciemnienia oraz rysunki techniczne. Długość ołówka wynosi 15 centymetrów.",
                    Manufacturer ="Grafit SP.Z",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.01m,
                    FileNamePhoto = "34.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-21),
                    Active = true },
                new Product() { CategoryID = 7,
                    ProductTitle ="Nożyczki z gratisem",
                    Price =  17.9m,
                    Description = "Zestaw zawiera profesjonalne nożyki oraz 4 cienkopisy wysyłane losowo pod względem kolorów. Nożyczki przeznaczone są dla dzieci powyżej 10 roku życia.",
                    Manufacturer ="Samso Sp. F",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.15m,
                    FileNamePhoto = "35.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-11),
                    Active = true },
                new Product() { CategoryID = 7,
                    ProductTitle ="Kredki premium+",
                    Price =  50.9m,
                    Description = "Zestaw 16 świetnej jakości kolorowych kredek. Z nimi Twoje dziecko z pewnością stworzy nie jeden piękny rysunek i zaimponuje wszystkim w Twojej rodzinie. Kredki są wytrzymałe i twarde przy jednoczesnym ukazywaniu ciepłych barw.",
                    Manufacturer ="Colors Full SP",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.15m,
                    FileNamePhoto = "36.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-2),
                    Active = true },
                new Product() { CategoryID = 7,
                    ProductTitle ="Notatnik z piórem",
                    Price =  37.2m,
                    Description = "Zestaw zawiera: świetnej jakości notatnik wraz z kalendarzem, pióro z trzeba niebieskimi nabojami oraz zakładkę do oznaczania bieżącej strony.",
                    Manufacturer ="Paper Conf",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.4m,
                    FileNamePhoto = "37.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-3),
                    Active = true },
                new Product() { CategoryID = 7,
                    ProductTitle ="Zestaw technika",
                    Price =  97.5m,
                    Description = "Zestaw zawiera: 3 ołówki techniczne, 1 ołówek rysunkowy, 1 flamaster, 1 cienkopis, 3 pędzle, 3 spinacze, 1 temperówka, 1 kątomierz, 3 linijki, 1 zszywacz oraz zestaw 200 kartek A4.",
                    Manufacturer ="Technik Firms",
                    Promotion = false,
                    TheBestProduct = true,
                    Weight = 0.25m,
                    FileNamePhoto = "38.jpg",
                    AddDate = DateTime.Now,
                    Active = true },
                new Product() { CategoryID = 8,
                    ProductTitle ="Okulary dziecięce",
                    Price =  410.9m,
                    Description = "Okulary dziecięce przeznaczone dla dzieci od 2 roku życia. 100% bezpieczne i zapewniające odpowiednią ochronę przed promieniami UV.",
                    Manufacturer ="Summer Protection",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.03m,
                    FileNamePhoto = "39.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-5),
                    Active = true },
                new Product() { CategoryID = 8,
                    ProductTitle ="Telefon dziecięcy",
                    Price =  720m,
                    Description = "Telefon dziecięcy przeznaczony dla dzieci powyżej 6 roku życia. Posiada wbudowaną funkcję GPS lokalizującą Twoje dziecko na bieżąco – w każdym momencie masz możliwość podejrzenia lokalizacji poprzez stronę www.mdwojak.pl.",
                    Manufacturer ="Phone Corp",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.2m,
                    FileNamePhoto = "40.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-32),
                    Active = true },
                new Product() { CategoryID = 8,
                    ProductTitle ="Retro żarówka",
                    Price =  39.5m,
                    Description = "Retro żarówka - Pobów energii: 50W. Zapewnia fantastyczną dekorację dla Twojego domu. Idealnie wpasowuje się w każdy możliwy wystój. Gwarancja satysfakcji zapewniona w 100%.",
                    Manufacturer ="Light Now",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.05m,
                    FileNamePhoto = "41.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-31),
                    Active = true },
                new Product() { CategoryID = 8,
                    ProductTitle ="Zegar ścienny",
                    Price =  78.99m,
                    Description = "Zegar ścienny – idealny dla Twojej kuchni, bądź salonu. Ciesz się idealnie odmierzonym czasem z firmą Clock Now. Produkt ten cechuje się wyjątkową jakością oraz idealnym odmierzaniem czasu.",
                    Manufacturer ="Clock Now",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.27m,
                    FileNamePhoto = "42.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-21),
                    Active = true },
                new Product() { CategoryID = 8,
                    ProductTitle ="Retro budzik",
                    Price =  47.6m,
                    Description = "Retro budzik – Rozwiąże każdy Twój problem z wczesnym wstawaniem rano. Jest donośny i jednocześnie bardzo wytrzymały. Spraw, by Twój poranek zawsze zaczynał się od chwil z retro budzikiem firmy Clock Now.",
                    Manufacturer ="Clock Now",
                    Promotion = false, TheBestProduct = false,
                    Weight = 0.3m,
                    FileNamePhoto = "43.jpeg",
                    AddDate = DateTime.Now.AddMinutes(-31),
                    Active = true },
                new Product() { CategoryID = 8,
                    ProductTitle ="Klepsydra",
                    Price =  29.98m,
                    Description = "Zjawiskowa klepsydra do odmierzania czasu – zaskocz wszystkich znajomym jej świetnych designem. Pokaż wszystkim jak szybko płynie czas, pełen przesyp ziaren kwarcu trwa całe 90 sekund!",
                    Manufacturer ="Finish Camxis Espa",
                    Promotion = false,
                    TheBestProduct = false,
                    Weight = 0.1m,
                    FileNamePhoto = "44.jpeg",
                    AddDate = DateTime.Now,
                    Active = true },
            };
            product.ForEach(a => context.Products.Add(a));
            context.SaveChanges();
        }
    }
}