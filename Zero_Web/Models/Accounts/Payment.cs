using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Web.Models
{
    public class Payment
    {

        public string UserID { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public bool DefaultPayment { get; set; }

    }

    public enum PaymentTypes
    {
        PayPal,
        PSC,
        DirectPay
    }

}