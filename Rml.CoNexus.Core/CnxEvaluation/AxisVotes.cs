using Rml.CoNexus.Core.CnxElicitation;

namespace Rml.CoNexus.Core.CnxEvaluation;

public class AxisVotes : Dictionary<Axis, Votes>
{
    public AxisVotes() { }
    public AxisVotes(int participantId, Axes axes, TopicList crits) 
    {
        ParticipantId = participantId;
    }

    public int ParticipantId { get; }
}
