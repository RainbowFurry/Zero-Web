using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Web.Models
{
    public class Roles
    {

        public RoleType[] UserRoles { get; set; }

    }

    public enum RoleType
    {
        Administrator,
        Zero,
        User,
        Premium,
        Developer
    }

}