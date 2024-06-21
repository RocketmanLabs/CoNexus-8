namespace Rml.CoNexus.Core;

public class Criteria : List<Criterion>
{
    public Criteria() { }

    public Criteria(IEnumerable<Criterion> crits) => this.AddRange(crits);

    public Criterion? Fetch(int id) => this.Find(x => x.Id == id);
}

