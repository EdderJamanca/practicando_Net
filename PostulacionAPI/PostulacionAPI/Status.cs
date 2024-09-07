using System.ComponentModel.DataAnnotations;

namespace PostulacionAPI
{
    public class Status
    {
        public int Id { get; set; }

        [StringLength(100)] 
        public string StatusOption { get; set; } = string.Empty;
    }
}
