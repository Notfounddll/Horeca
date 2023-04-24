using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models
{
    public class StockModel
    {
        public int Id { get; set; }
        public int Id_Location { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please write a positive value")]
        public decimal Amount { get; set; }
        public int Active { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please write a positive value")]
        public decimal UpdateValue { get; set; }
    }
}
