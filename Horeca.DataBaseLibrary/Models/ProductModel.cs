using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int Id_Department { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Use letters only please")]
        public string Product { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please write a positive value")]
        public decimal Price { get; set; }
        public int Active { get; set; }
    }
}
