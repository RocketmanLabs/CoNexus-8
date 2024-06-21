namespace Rml.CoNexus.Core;

public class Votes : List<Vote>
{
    public Votes() { }

    public Votes(IEnumerable<Vote> votes) => this.AddRange(votes);

    public Vote? Fetch(int axisId, int participantId) => this.Find(x => x.AxisId == axisId && x.ParticipantId == participantId);

    public bool Completed { get; set; }

    public int UnvotedCount => this.Count(x => x.Voted == false);
    public int VotedCount => this.Count(x => x.Voted == true);
}

