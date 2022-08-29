using System.ComponentModel.DataAnnotations;

namespace Fiks.Models
{
    public class Submission
    {
        [Key]
        public int Id { get; set; }
        
        public Models.File? DescriptionFile { get; set; }

        public Models.File? CodeFile { get; set; }

        [Required]
        public Models.Task Task { get; set; }
    }
}
