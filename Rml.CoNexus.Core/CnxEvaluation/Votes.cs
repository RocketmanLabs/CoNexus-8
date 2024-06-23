namespace Rml.CoNexus.Core.CnxEvaluation;

/// <summary>
/// Collection of vote records for one participant, one axis
/// </summary>
public class Votes : List<Vote>
{
    public Votes() { }

    public int ParticipantId { get; set; }
    public int AxisId { get; set; }

    public bool Completed => Count > 0 && UnvotedCount == 0;

    public int UnvotedCount => this.Count(x => x.Voted == false);
    public int VotedCount => this.Count(x => x.Voted == true);

    public Vote? Fetch(int participantId, int axisId) => Find(x => x.ParticipantId == participantId && x.AxisId == axisId);
}

