using System.ComponentModel.DataAnnotations;

namespace DTOs.Client
{
    public class ClientUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public string Email { get; set; }
        [MaxLength(6)]
        public string Placa { get; set; }
        public int IdEnterprice { get; set; }
    }
}
