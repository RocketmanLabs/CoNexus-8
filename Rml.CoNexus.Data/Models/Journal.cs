using System.ComponentModel.DataAnnotations;

namespace Rml.CoNexus.Data.Models;
public class JournalSection : _ModelBase
{
    public JournalSection() { }

    [Key]
    [StringLength(50)]
    public string Id { get => base.BaseId; set => base.BaseId = value; }

    [Required]
    [StringLength(50)]
    public string? JournalId { get; set; }

    public int SectionNumber { get; set; } = 1;

    [Required]
    [StringLength(100)]
    public string? Title { get; set; }
    public string? Introduction { get; set; }
    public string? Body { get; set; }
    public string? Conclusion { get; set; }
}
public class Journal : _ModelBase
{
    public Journal() { }

    public Journal(Inquiry inq, IParticipant user)
    {
        Title = inq.Title;
        UserName = user.Name;
        UserEmail = user.Email;
    }

    [Key]
    public string JournalId { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [StringLength(50)]
    public string? InquiryId { get; set; }

    public bool ForGroup { get; set; } = true;

    [Required]
    [StringLength(100)]
    public string? Title { get; set; }

    [StringLength(100)]
    public string? UserName { get; set; } = "Group";

    [StringLength(100)]
    public string? UserEmail { get; set; } = string.Empty;

    [StringLength(100)]
    public DateTime OpenedUtc { get; set; } = DateTime.UtcNow;
    [StringLength(100)]
    public DateTime? ClosedUtc { get; set; }
    public bool IsClosed => ClosedUtc.HasValue;

    public string? Introduction { get; set; }

    // Sections will go here

    public string? Conclusion { get; set; }
}
public class Contact
{
    public Contact() { }

    [Key]
    public string ContactId { get; set; } = Guid.NewGuid().ToString();
    public string MemberId { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string? LastName { get; set;} = string.Empty;
    [StringLength(50)]
    public string? FirstName { get; set;} = string.Empty;
    [StringLength(50)]
    public string? { get; set;} = string.Empty;
}
