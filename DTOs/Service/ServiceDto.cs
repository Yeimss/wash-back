using System.ComponentModel.DataAnnotations;

namespace DTOs.Service
{
    public class ServiceDto
    {
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Description { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public int Price { get; set; }
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int idEnterprice { get; set; }
        [Required(ErrorMessage = "La empresa es obligatoria")]
        public int idCategory { get; set; }
    }
}
