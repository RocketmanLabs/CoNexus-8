using static Rml.CoNexus.ReverseProfile.Program;

namespace Rml.CoNexus.ReverseProfile;

public static class EvaluationHelpers
{
    public static Vote? NextVote(this Votes votes) => votes.FirstOrDefault(x => !x.Voted);
    public static Vote? RegisterVote(this Votes votes, Vote vote, decimal raw)
    {
        vote.Raw = raw;
        vote.Voted = true;
        return votes.NextVote();
    }
    public static Vote? RegisterVote(this Votes votes, Vote vote, bool bottomSelected, decimal raw)
    {
        vote.Raw = raw;
        if (vote.SelectedTopicId is null || vote.ComparedTopicId is null) throw new InvalidOperationException(
            $"Vote has null Topic IDs, cannot continue.{Environment.NewLine} {vote}");

        if (bottomSelected)
        {
            string temp = vote.SelectedTopicId;
            vote.SelectedTopicId = vote.ComparedTopicId;
            vote.ComparedTopicId = temp;
        }
        vote.Voted = true;
        return votes.NextVote();
    }
}


