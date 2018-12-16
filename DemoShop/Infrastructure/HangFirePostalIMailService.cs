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
        public void SendNewsletterWelcomeEmail(Newsletter newsletter)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendNewsletterEmail", "Manage", new { emailTo = newsletter.Email, code = newsletter.UnscribeCode }, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
        }

        public void SendOrderCanceledEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendOrderCanceledEmail", "Manage", new { orderID = order.OrderID, surname = order.Surname }, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
        }

        public void SendOrderConfirmationEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendOrderConfirmationEmail", "Manage", new { orderID = order.OrderID, surname = order.Surname }, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
        }

        public void SendOrderShippedEmail(Order order)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            string url = urlHelper.Action("SendOrderShippedEmail", "Manage", new { orderID = order.OrderID, surname = order.Surname }, HttpContext.Current.Request.Url.Scheme);

            BackgroundJob.Enqueue(() => Helpers.CallUrl(url));
        }
    }

}