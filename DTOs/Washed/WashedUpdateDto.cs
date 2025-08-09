using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Washed
{
    public class WashedUpdateDto
    {
        [Required(ErrorMessage = "El id es obligatorio")]
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdEnterprice { get; set; }
        public int IdService { get; set; }
        public int? IdEncargado { get; set; }
        public bool? IsWashed { get; set; }
        public bool? IsPaid { get; set; }
    }
}
