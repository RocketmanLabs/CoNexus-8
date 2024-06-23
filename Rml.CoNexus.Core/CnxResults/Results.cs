namespace Rml.CoNexus.Core.CnxResults;

public class Results : List<Result>
{
    public Results() { }

    public Results(IEnumerable<Result> results) => AddRange(results);
}
