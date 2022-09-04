using System.ComponentModel.DataAnnotations;

namespace Fiks.Models
{
    public class Round
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descrption { get; set; }

        [Required]
        public DateTime OpenFrom { get; set; }
        
        [Required]
        public DateTime OpenTo { get; set; }

        [Required]
        /// Percentage points: how many percent are substracted
        /// from each user's attempt
        public int Penalization { get; set; }

        public DateTime PenalizationStart { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [Required]
        public Season Season { get; set; }
    }
}
