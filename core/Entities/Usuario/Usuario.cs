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
        public string name { get; set; }
        public string lastName { get; set; }
        public int idEnterprice { get; set; }
        public string enterprice { get; set; } 
        public int idRol { get; set; }
    }
}
