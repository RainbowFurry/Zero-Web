namespace Zero_Web.Content.csharp.Zero
{
    public class RoleManagement
    {

        //https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/

        /// <summary>
        /// Create all Roles the Zero System has
        /// </summary>
        //private void CreateRoles()
        //{

        //    String[] roles = { "Administrator", "Developer", "Supporter", "Moderator", "Premium", "User" };

        //    foreach (string role in roles)
        //    {
        //        CreateRole(role);
        //    }

        //}

        ///// <summary>
        ///// Create a User Role
        ///// </summary>
        ///// <param name="roleName"></param>
        //private void CreateRole(string roleName)
        //{

        //    //ApplicationDbContext context = new ApplicationDbContext();
        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

        //    if (!roleManager.RoleExists(roleName))
        //    {
        //        var role = new IdentityRole();
        //        role.Name = roleName;
        //        roleManager.Create(role);
        //    }

        //}

        ///// <summary>
        ///// Create a User
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <param name="email"></param>
        ///// <param name="hashPW"></param>
        //private void CreateUser(string userName, string email, string hashPW)
        //{

        //    //ApplicationDbContext context = new ApplicationDbContext();
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        //    var user = new ApplicationUser();
        //    user.UserName = userName;
        //    user.Email = email;

        //    string userPWD = hashPW;

        //    var chkUser = UserManager.Create(user, userPWD);

        //}

        ///// <summary>
        ///// Give the User a Role
        ///// </summary>
        ///// <param name="roleName"></param>
        //private void AddUserToRole(string roleName)
        //{

        //    var chkUser = UserManager.Create(user, userPWD);

        //    if (chkUser.Succeeded)
        //    {
        //        var result1 = UserManager.AddToRole(user.Id, roleName);

        //    }

        //}

    }
}