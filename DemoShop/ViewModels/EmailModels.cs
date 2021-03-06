﻿using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoShop.ViewModels
{
    public class OrderConfirmationEmail : Email
    {
        public string To { get; set; }
        public decimal Cost { get; set; }
        public string Address { get; set; }
    }

    public class OrderSendedEmail : Email
    {
        public string To { get; set; }
        public decimal Cost { get; set; }
        public string Address { get; set; }
    }

    public class OrderCanceledEmail : Email
    {
        public string To { get; set; }
    }

    public class NewsletterWelcomeEmail : Email
    {
        public string To { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
    }
    public class CompletedOrderEmail : Email
    {
        public string To { get; set; }
        public decimal Cost { get; set; }
        public string Address { get; set; }
    }
}