namespace Rml.CoNexus.Core.CnxElicitation;

public class Demographics : List<DemographicQuestion>
{
    public Demographics() { }
    public Demographics(IEnumerable<DemographicQuestion> dqs) => AddRange(dqs);

    public DemographicQuestion? Fetch(int id) => this.FirstOrDefault(x => x.Id == id);
}
