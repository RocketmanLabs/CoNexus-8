using Rml.CoNexus.Core.CnxElicitation;
using Rml.CoNexus.Core.CnxEvaluation;

namespace Rml.CoNexus.Core.CnxResults;

public class ProfileAxis
{
    public ProfileAxis(Axis axis, Votes votes, TopicList crits)
    {
        if (votes.Count == 0 || votes.UnvotedCount > 0) throw new ArgumentException($"Profile construction halted; the votes collection is incomplete.");
        switch (axis.Method)
        {
            case VoteMethod.PAIRS:
                break;
            case VoteMethod.RATE:
            case VoteMethod.DIRECT:
                break;
            default:
                throw new InvalidOperationException($"{axis.Method} is unsupported, cannot continue with Profile construction.");
        }
    }
}

