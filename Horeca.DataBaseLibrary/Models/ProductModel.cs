using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int Id_Department { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Active { get; set; }
    }
}
