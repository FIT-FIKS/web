using System.ComponentModel.DataAnnotations;

namespace Fiks.Models
{
    public class Submission
    {
        [Key]
        public int Id { get; set; }
        
        public Models.File? Description { get; set; }

        public Models.File? File { get; set; }

        [Required]
        public Models.Task Task { get; set; }
    }
}
