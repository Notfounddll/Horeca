using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public int Id_Location { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Use letters only please")]
        public string Department { get; set; }
        public int Active { get; set; }
    }
}
