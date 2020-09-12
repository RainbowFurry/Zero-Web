using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Web.Models
{
    public class Account
    {

        public string UserID { get; set; }
        public AccountType LoginType { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }

    }

    public enum AccountType
    {
        Twitter
    }

}