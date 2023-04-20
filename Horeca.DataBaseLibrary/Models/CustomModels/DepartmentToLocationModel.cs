using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models.CustomModels
{
    public class DepartmentToLocationModel
    {
        public int Id_Department { get; set; }
        public int Id_Location { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
    }
}
