using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Fiks.Models;

public class Season
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(64)]
    public string Title { get; set; } = String.Empty;
    
    [Required]
    [StringLength(64)]
    public string Description { get; set; } = String.Empty;
}