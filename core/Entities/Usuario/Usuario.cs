using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Entities.Usuario
{
    public class Usuario
    {
        public int id { get; set; }
        public string document { get; set; }
        public string name { get; set; }
        public int? idEnterprice { get; set; }
        public string enterprice { get; set; } 
        public int? idRol { get; set; }
        public string rol {  get; set; }
        public string password {  get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
