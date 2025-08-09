namespace core.Entities.Services
{
    public class Service
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string? Empresa { get; set; }
        public int? IdEmpresa { get; set; }
        public string? Categoria { get; set; }
        public int? IdCategoria { get; set; }
    }
}
