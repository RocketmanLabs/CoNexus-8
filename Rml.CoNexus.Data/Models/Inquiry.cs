using System.ComponentModel.DataAnnotations;

namespace Rml.CoNexus.Data.Models;

public class Inquiry
{
    [Key]
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    [Required]
    [StringLength(100)]
    public string? Title { get; set; }
    [StringLength(100)]
    public string? Goal { get; set; }
    [StringLength(1000)]
    public string? ClientNotes { get; set; }
    [StringLength(1000)]
    public string? SessionNotes { get; set; }
}
