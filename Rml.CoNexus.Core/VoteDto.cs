namespace Rml.CoNexus.Core;

public class VoteDto
{
    private Axis _axis;
    private Criteria _crits;

    public VoteDto(Axis axis, Vote vote, Criteria crits)
    {
        _axis = axis;
        _crits = crits;
        Vote = vote;

        Method = _axis.Method;
        Question = _axis.Question;

        Criterion? topCrit = _crits.Fetch(Vote.SelectedTopicId);
        if (topCrit is null) throw new InvalidDataException("Cannot procede with vote without a Criterion.");
        Criterion? bottomCrit = _crits.Fetch(Vote.ComparisonTopicId);

        TopTopic = topCrit.Text;
        BottomTopic = bottomCrit is null ? null : bottomCrit.Text;
    }

    public Vote Vote { get; set; } = Vote.Empty;
    public string Question { get; set; }
    public VoteMethod Method { get; set; }
    public string TopTopic { get; set; }
    public string? BottomTopic { get; set; }
    public int[] ChoiceIds => _axis.VotingScale.Select(x => x.Id).ToArray();
    public string[] ChoiceText => _axis.VotingScale.Select(x => x.Text).ToArray();

    public int SelectedChoiceId { get; set; } = -1;
}

