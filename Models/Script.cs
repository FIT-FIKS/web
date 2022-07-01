using System.ComponentModel.DataAnnotations;

namespace Fiks.Models
{
    public class Script
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(80)]
        public string Path { get; set; }

        [Required]
        public ScriptType ScriptType { get; set; }
    }

    public enum ScriptType 
    { 
        // todo: add script tipes
    }
}
