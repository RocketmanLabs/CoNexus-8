using Rml.CoNexus.Core.CnxElicitation;
using Rml.CoNexus.Core.CnxParticipation;
using Rml.CoNexus.Core.Extensions;

namespace Rml.CoNexus.Core.CnxEvaluation;

/// <summary>
/// Constructs and holds all Axis Votes for a single person.
/// </summary>
public class Evaluation : Dictionary<Participant, AxisVotes>
{
    public Evaluation() { }

    public Evaluation(int altId, Group group, Axes axes, TopicList crits)
    {
        AlternativeId = altId;

        foreach (Participant p in group)
        {
            AxisVotes av = new(p.Id, axes, crits);
            this.Add(p, av);
        }
    }

    public int AlternativeId { get; private set; }
}
