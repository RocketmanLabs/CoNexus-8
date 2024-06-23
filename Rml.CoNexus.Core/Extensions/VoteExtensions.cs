using Rml.CoNexus.Core.CnxElicitation;
using Rml.CoNexus.Core.CnxEvaluation;
using Rml.CoNexus.Core.CnxParticipation;

namespace Rml.CoNexus.Core.Extensions;

public static class VoteExtensions
{
    public static Vote? Next(this Votes votes)
    {
        Vote? vote = votes.FirstOrDefault(x => x.Voted == false);
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

    public static Votes CreateTracker(this Participant p, Axis axis, TopicList crits)
    {
        Votes votes = axis.Method switch
        {
            VoteMethod.PAIRS => createPairsTracker(crits.Count),
            VoteMethod.RATE => createRateTracker(crits.Count),
            VoteMethod.DIRECT => createRateTracker(crits.Count),
            _ => throw new ArgumentOutOfRangeException(nameof(axis.Method))
        };
        return votes;

        // %%%%%%%%%%
        Votes createPairsTracker(int critCount)
        {
            Votes votes = new();
            for(int i = 0; i < critCount; i++)
            {
                for(int j = i; j < crits.Count; j++)
                {
                    if (i != j)
                    {
                        votes.Add(
                            new Vote(p.Id, axis.Id, crits[i].Id) { 
                                ComparisonTopicId = crits[j].Id 
                            }
                        );
                    }
                }
            }
            return votes;
        }

        Votes createRateTracker(int critCount)
        {
            Votes votes = new();
            for (int i = 0; i < critCount; i++)
            {
                votes.Add(new Vote(p.Id, axis.Id, crits[i].Id));
            }
            return votes;
        }
    }
}

