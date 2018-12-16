using DemoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.Infrastructure
{
    public interface IMailService
    {
        void SendOrderConfirmationEmail(Order order);

        void SendOrderShippedEmail(Order order);

        void SendOrderCanceledEmail(Order order);

        void SendNewsletterWelcomeEmail(Newsletter newsletter);

        //void SendContactEmail();
    }
}