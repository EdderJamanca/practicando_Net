using System.ComponentModel.DataAnnotations;

namespace PostulacionAPI
{
    public class Trabajo
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Cargo { get; set; } = string.Empty;

        [StringLength(4000)]
        public string Detalle { get; set; } = string.Empty;

        public decimal Salario { get; set; } = 0;

        [StringLength(50)]
        public string Empresa { get; set; } = string.Empty;
    }
}
