using System.ComponentModel.DataAnnotations;

namespace DTOs.Client
{
    public class ClientUpdateDto
    {
        [Required(ErrorMessage = "El Id de usuario es obligatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La placa es obligatoria")]
        [MaxLength(6, ErrorMessage = "Máximo 6 caracteres")]
        public string Placa { get; set; }
        public int IdEnterprice { get; set; }
    }
}
