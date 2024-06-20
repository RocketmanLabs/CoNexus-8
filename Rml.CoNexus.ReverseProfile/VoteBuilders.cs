using static Rml.CoNexus.ReverseProfile.Program;

namespace Rml.CoNexus.ReverseProfile;
#region Extension Methods
public static class VoteBuilders
{
    public static Votes PairVotesBuilder(this Axis axis, Participant part, Criteria crits)
    {
        Votes votes = new();

        if (axis.Method == VoteMethod.PAIRS)
        {
            for (int i = 0; i < crits.Count; i++)
            {
                for (int j = i; j < crits.Count; j++)
                {
                    if (i != j)
                    {
                        Vote vote = new(axis, part, crits[i], crits[j]);
                        votes.Add(vote);
                    }
                }
            }
        }
        return votes;
    }
    public static Votes ContributionVotesBuilder(this Axis axis, Participant part, Alternative alt, Criteria crits)
    {
        Votes votes = new();

        if (axis.Method == VoteMethod.PAIRS)
        {
            for (int i = 0; i < crits.Count; i++)
            {
                Vote vote = new(axis, part, alt, crits[i]);
                votes.Add(vote);
            }
        }
        return votes;
    }
}


