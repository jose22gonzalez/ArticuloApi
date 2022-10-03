using System.ComponentModel.DataAnnotations;

namespace ArticuloApi.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloId   { get; set; }
        public string? Descripcion   { get; set; }
        public string? Marca { get; set; }
        public int Existencia { get; set; }
    }
}
