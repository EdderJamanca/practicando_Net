using System.ComponentModel.DataAnnotations;

namespace PostulacionAPI
{
    public class JobType
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string JobName { get; set; } = string.Empty;
    }
}
