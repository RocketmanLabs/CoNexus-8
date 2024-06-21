namespace Rml.CoNexus.Core;

public class Axes : List<Axis>
{
    public Axes() { }

    public Axes(IEnumerable<Axis> axes) => this.AddRange(axes.OrderBy(x => x.Sequence));

    public Axis? Fetch(int id) => this.Find(x => x.Id == id);
}

