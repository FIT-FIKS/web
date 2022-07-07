using System.ComponentModel.DataAnnotations;

namespace Fiks.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        public User Autor { get; set; }
    }
}
