using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models
{
    public class AuthentificationModel
    {
        public int Id { get; set; }
        public int Id_Acces { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Active { get; set; }
    }
}
