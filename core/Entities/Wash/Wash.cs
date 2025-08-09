
using core.Entities.Cliente;
using core.Entities.Services;

namespace core.Entities.Wash
{
    public class Wash
    {
        public int Id { get; set; }
        public string Enterprice { get; set; }
        public int IdEnterprice { get; set; }
        public Cliente.Cliente Cliente { get; set; }
        public Service Servicio { get; set; }
        public int? IdEncargado { get; set; }
        public string? Encargado { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsWashed { get; set; }
        public DateTime? admissionDate { get; set; }
        public DateTime? depurateDate { get; set; }
    }
}
