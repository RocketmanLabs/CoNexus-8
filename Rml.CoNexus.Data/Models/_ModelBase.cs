using System.ComponentModel.DataAnnotations;

namespace Rml.CoNexus.Data.Models;

public abstract class _ModelBase
{
    protected _ModelBase() { }

    protected string BaseId = Guid.NewGuid().ToString();
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; }
    public bool Inactive { get; set; }
    public bool Hidden { get; set; }
}
public class Member : _ModelBase
{
    [Key]
    [StringLength(50)]
    public string? MemberId { get; set; }

    [StringLength(100)]
    public string? MemberName { get; set; }

    public int 
}
public class ContactInfo : _ModelBase
{
    public ContactInfo() { }

    [Key]
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    [Required]
    [StringLength(50)]
    public string? ContactId { get; set; }
}
public class ContactXContactInfo
{

}
