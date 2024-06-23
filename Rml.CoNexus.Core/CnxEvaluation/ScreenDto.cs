using Rml.CoNexus.Core.CnxElicitation;

namespace Rml.CoNexus.Core.CnxEvaluation;

public class ScreenDto
{
    private Axis _axis;
    private TopicList _crits;

    public ScreenDto(Axis axis, Vote vote, TopicList crits)
    {
        _axis = axis;
        _crits = crits;
        Vote = vote;

        Method = _axis.Method;
        Question = _axis.Question ?? "error";

        Topic? topCrit = _crits.Fetch(Vote.SelectedTopicId);
        if (topCrit is null) throw new InvalidDataException("Cannot procede with vote without a Criterion.");
        Topic? bottomCrit = _crits.Fetch(Vote.ComparisonTopicId);

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

