using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Models.CustomModels
{
    public class AccesToAuthentificationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAcces { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
