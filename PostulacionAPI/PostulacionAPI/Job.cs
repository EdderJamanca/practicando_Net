using System.ComponentModel.DataAnnotations;

namespace PostulacionAPI
{
    public class Job
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = string.Empty;

        [StringLength(200)]
        public string Comments { get; set; } = string.Empty;

        public int JobTypeId { get; set; }

        public JobType? jobType { get; set; }
    }
}
