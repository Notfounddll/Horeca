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
        public string Name { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public int Active { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only numbers allowed.")]
        public decimal UpdateValue { get; set; }
    }
}
