using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoShop.Models;
using DemoShop.ViewModels;

namespace DemoShop.Infrastructure
{
    public class PostalIMailService : IMailService
    {
        public void SendOrderConfirmationEmail(Order order)
        {
            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.Cost = order.SummaryPrice;
            email.Address = string.Format("{0}  {1} {2}, {3}, {4}", order.Country, order.City, order.CityCode, order.Street, order.ApartmentNumber);
            email.Send();
        }
    }
}