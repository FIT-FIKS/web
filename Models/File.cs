using System.ComponentModel.DataAnnotations;

namespace Fiks.Models
{
    public class File
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public User Autor { get; set; }

        [Required]
        [StringLength(10)]
        public string Extension { get; set; }
    }
}
