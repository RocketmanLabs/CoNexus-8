using Rml.CoNexus.Core.CnxElicitation;

namespace Rml.CoNexus.Core.CnxEvaluation;

/// <summary>
/// Contains all tracker/vote data, keyed to ParticipantId.
/// </summary>
public class Evaluations : Dictionary<Topic, Evaluation> 
{
    public Evaluations() { }
    public Evaluations(int inqId, TopicList alts, Group group, Axes axes, TopicList crits) 
    { 
        foreach(Topic alt in alts)
        {
            Evaluation eval = new(alt.Id, group, axes, crits);
        }

        InquiryId = inqId;
    }

    public int InquiryId { get; }
}