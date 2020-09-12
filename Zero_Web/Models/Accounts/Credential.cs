using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Web.Models
{
    public class Credential
    {

        public string UserID { get; set; }
        public CredentialType LoginType { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }

    }

    public enum CredentialType
    {
        Zero,
        Microsoft,
        Google,
        Facebook
    }

}