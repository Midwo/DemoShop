using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using DemoShop.Models;
using Hangfire;

namespace DemoShop.Infrastructure
{
    public class HangFirePostalIMailService : IMailService
    {
        public void SendOrderConfirmationEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendConfirmationEmail", "Manage", new { orderID = order.OrderID, surname = order.Surname }, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
        }
    }
}