using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Zero_Web.Models
{
    public class User
    {

        [BsonId]
        public string ID { get; set; }

        [Display(Name = "NickName")]
        [StringLength(100, ErrorMessage = "To many charts")]
        [Required(ErrorMessage = "Please provide NickName", AllowEmptyStrings = false)]
        public string NickName { get; set; }

        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "To many charts")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "To many charts")]
        public string LastName { get; set; }

        [Display(Name = "Street")]
        [StringLength(100, ErrorMessage = "To many charts")]
        public string Street { get; set; }

        [Display(Name = "House Number")]
        [StringLength(100, ErrorMessage = "To many charts")]
        public string HouseNumber { get; set; }

        [Display(Name = "Postcode")]
        [StringLength(100, ErrorMessage = "To many charts")]
        public string Postcode { get; set; }

        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "To many charts")]
        public string City { get; set; }

        [Display(Name = "Phonenumber")]
        [StringLength(100, ErrorMessage = "To many charts")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Language")]
        [StringLength(100, ErrorMessage = "To many charts")]
        [Required(ErrorMessage = "Please provide Language", AllowEmptyStrings = false)]
        public string Language { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "To many charts")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please provide Email", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Display(Name = "Birthday")]
        [StringLength(100, ErrorMessage = "To many charts")]
        [DataType(DataType.Date)]
        public string Age { get; set; }

        [Display(Name = "Gender")]
        [StringLength(100, ErrorMessage = "To many charts")]
        public string Gender { get; set; }
        public string FirstJoin { get; set; }
        public string ProfilePicture { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be 8 Char long.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [StringLength(100, ErrorMessage = "To many charts")]
        [Compare("Password", ErrorMessage = "Confirm password does not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        //public string Hobby { get; set; }
        //public string Status { get; set; }

        public Roles Role { get; set; }//Roles of the User
        public Account[] Accounts { get; set; }//General Accounts
        public Credential[] Credentials { get; set; }//Login Accounts
        public Payment[] Payments { get; set; }//User Payment Accounts
        public string[] Lizenses { get; set; }//Lizenses of User


        private static void test()
        {
            User user = new User
            {
                NickName = "",
                FirstName = "",
                Role = new Roles()
                {
                    UserRoles = new RoleType[] {
                        RoleType.Administrator,
                        RoleType.Developer
                    }
                }

            };
        }

    }
}