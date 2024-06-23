using Rml.CoNexus.Core.CnxElicitation;
using Rml.CoNexus.Core.CnxEvaluation;
using Rml.CoNexus.Core.Constants;

namespace Rml.CoNexus.Core.CnxResults;

public class Profile
{
    public Profile(Axes axes, Votes votes, TopicList crits, int? participantId)
    {
        foreach (Axis axis in axes)
        {
            // TBD
        }
    }


    public string Title { get; set; } = "Profile";
    public ResultType ProfileType { get; set; } = ResultType.UNKNOWN;
    public List<ProfilePoint> Points { get; set; } = [];
}

