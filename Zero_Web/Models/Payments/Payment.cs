using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Web.Models.Payments
{
    public class Payment
    {

        public string PaymentID { get; set; }
        public string PaymentType { get; set; }
        public string Date { get; set; }
        public string Price { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImage { get; set; }

    }
}