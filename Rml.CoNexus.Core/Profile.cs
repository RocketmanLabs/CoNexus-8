using Rml.CoNexus.Core.Constants;

namespace Rml.CoNexus.Core;

public class Profile
{
    public Profile(Axes axes, Votes votes, Criteria crits, int? participantId)
    {
        foreach (Axis axis in axes)
        {

        }
    }


    public string Title { get; set; } = "Profile";
    public ProfileType ProfileType { get; set; } = ProfileType.UNKNOWN;
    public List<ProfilePoint> Points { get; set; } = [];
}

