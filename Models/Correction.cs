using System.ComponentModel.DataAnnotations;

namespace Fiks.Models
{
    public class Correction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Feedback { get; set; }

        [Required]
        [Range(0, 100)]
        public int Score { get; set; }

        [Required]
        public User Autor { get; set; }

        [Required]
        public Submission Submission { get; set; }
    }
}
