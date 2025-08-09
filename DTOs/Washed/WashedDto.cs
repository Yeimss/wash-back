using System.ComponentModel.DataAnnotations;

namespace DTOs.Washed
{
    public class WashedDto
    {
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int IdClient { get; set; }
        public int? IdEnterprice { get; set; }
        [Required(ErrorMessage = "El Servicio es obligatorio")]
        public int IdService { get; set; }
        public int? IdEncargado { get; set; }
    }
}
