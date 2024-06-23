namespace Rml.CoNexus.Core.CnxEvaluation;

public class Scale : List<ScaleEntry>
{
    public Scale() { }

    public Scale(IEnumerable<ScaleEntry> entries) => AddRange(entries);

    public ScaleEntry? Fetch(int id) => Find(x => x.Id == id);

    public ConsoleKey[] LegalKeys => this.Select(x => x.SelectionKey).ToArray();
}

