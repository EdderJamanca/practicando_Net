using System.ComponentModel.DataAnnotations;

namespace PostulacionAPI
{
    public class Postular
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Correo { get; set; } = string.Empty;

        [StringLength(10)]
        public string TipoDocumento { get; set; } = string.Empty;

        [StringLength(20)]
        public string NroDocumento { get; set; } = string.Empty;

        public string Archivo { get; set; }

        public int TrabajoId { get; set; }

        public Trabajo? Trabajo { get; set; }
    }
}
