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
        public int Penaliazation { get; set; }

        [Required]
        public DateTime PenalizationStart { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }
    }
}
