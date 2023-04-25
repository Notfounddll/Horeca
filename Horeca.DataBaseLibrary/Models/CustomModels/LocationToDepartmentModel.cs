using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models.CustomModels
{
    public class LocationToDepartmentModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Use letters only please")]
        public string Department { get; set; }
    }
}
