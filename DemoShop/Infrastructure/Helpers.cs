using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DemoShop.Infrastructure
{
    public class Helpers
    {
        public static void CallUrl(string serviceUrl)
        {
            var req = HttpWebRequest.Create(serviceUrl);
            req.GetResponseAsync();
        }
    }
}