using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zero_Web.Models
{
    public class Bewerbung
    {

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bitte gebe deine Email Adresse an.", AllowEmptyStrings = false)]
        public string Email { get; set; }

    }
}