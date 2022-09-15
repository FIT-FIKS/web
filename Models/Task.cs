
using System.ComponentModel.DataAnnotations;

namespace Fiks.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(5000)]
        public string Content { get; set; }

        [Required]
        public int MaxScore { get; set; }

        public File ReferenceSolution { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [Required]
        public TaskType Type { get; set; }

        public IEnumerable<Submission> Submissions { get; set; }

        public Script GenerationScript { get; set; }
        public Script CorrectionScript { get; set; }

        [Required]
        public Round Round { get; set; }
    }

    public enum TaskType { 
        // todo: task types
    }
}
