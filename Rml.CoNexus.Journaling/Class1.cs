using Rml.CoNexus.Data.Models;

namespace Rml.CoNexus.Journaling;

public class JournalX
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
public static class JournalExtensions
{
    public static JournalX InitializeJournal(Inquiry inq)
    {
        Inquiry = inq.Id;
    }
}
