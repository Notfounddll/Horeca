using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public int Id_Location { get; set; }
        public string Department { get; set; }
        public int Active { get; set; }
    }
}
