using System;
using System.Linq;
using System.Security.Principal;
using Zero_Web.Models;

namespace Zero_Web.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private readonly User Account;

        public CustomPrincipal(User account)
        {
            Account = account;
            Identity = new GenericIdentity(account.NickName);
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => Account.Role.UserRoles.Contains((RoleType)Enum.Parse(typeof(RoleType), role)));
        }
    }
}