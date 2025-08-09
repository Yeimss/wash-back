using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Service
{
    public class ServiceUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int idEnterprice { get; set; }
        public int idCategory { get; set; }
    }
}
