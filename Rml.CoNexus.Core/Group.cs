namespace Rml.CoNexus.Core;

public class Group : List<Participant>
{
    public Group() { }

    public Group(IEnumerable<Participant> participants) => this.AddRange(participants);

    public Participant? Fetch(int id) => this.Find(x => x.Id == id);
}

