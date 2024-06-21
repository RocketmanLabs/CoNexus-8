namespace Rml.CoNexus.Core;

public class Scale : List<ScaleEntry>
{
    public Scale() { }

    public Scale(IEnumerable<ScaleEntry> entries) => this.AddRange(entries);

    public ScaleEntry? Fetch(int id) => this.Find(x => x.Id == id);

    public ConsoleKey[] LegalKeys => this.Select(x => x.SelectionKey).ToArray();
}

