using DemoShop.DAL;
using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.ViewModels
{
    public class EpPlusExcelStaticList
    {
        public static List<Newsletter> SavedUserNewsletters
        {
            get
            {
                DemoShopContext db = new DemoShopContext();
                var data = db.Newsletters.ToList();
                return data;
            }
        }
    }
}