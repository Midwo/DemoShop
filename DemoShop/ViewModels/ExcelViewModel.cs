using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.ViewModels
{
    public class ExcelViewModel
    {
        public List<Newsletter> Technologies
        {
            get
            {
                return EpPlusExcelStaticList.SavedUserNewsletters;
            }
        }
    }
}