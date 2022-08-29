using System.ComponentModel.DataAnnotations;

namespace Fiks.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [StringLength(120)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000)]
        public string Text { get; set; }

        public User Autor { get; set; }
    }
}
