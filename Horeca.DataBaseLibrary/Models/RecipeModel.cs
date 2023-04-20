using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public int Id_Product { get; set; }
        public int Id_Stock { get; set; }
        public int Amount { get; set; }
        public int Active { get; set; }
    }
}
