namespace Rml.CoNexus.Core.CnxEvaluation;

public class Axes : List<Axis>
{
    public Axes() { }

    public Axes(IEnumerable<Axis> axes) => AddRange(axes.OrderBy(x => x.Sequence));

    public Axis? Fetch(int id) => Find(x => x.Id == id);
}

