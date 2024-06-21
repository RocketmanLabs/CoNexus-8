namespace Rml.CoNexus.Core.Extensions;

public static class VoteExtensions
{
    public static Vote? Next(this Votes votes)
    {
        Vote? vote = votes.FirstOrDefault(x => x.Voted == false);
        if (vote is null) votes.Completed = true;
        return vote;
    }

    public static void Reset(this Votes votes)
    {
        foreach (Vote vote in votes)
        {
            vote.Voted = false;
            vote.Raw = 0;
            vote.Scaled = 0;
            vote.Weighted = 0;
        }
    }
}

