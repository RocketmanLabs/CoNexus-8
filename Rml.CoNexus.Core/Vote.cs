namespace Rml.CoNexus.Core;

public class Vote
{
    public Vote() { }

    public Vote(Axis axis, Participant person, Criterion topTopic, Criterion bottomTopic)
    {
        AxisId = axis.Id;
        ParticipantId = person.Id;
        SelectedTopicId = topTopic.Id;
        ComparisonTopicId = bottomTopic.Id;
    }

    public bool Voted { get; set; }             // until this is set it is a tracker
    public int AxisId { get; set; }
    public int ParticipantId { get; set; }
    public int SelectedTopicId { get; set; }    // displayed on top for Pairs voting
    public int ComparisonTopicId { get; set; }

    public decimal Raw { get; set; }
    public decimal Scaled { get; set; }
    public decimal Weighted { get; set; }

    public static Vote Empty => new Vote() { Voted = true };
}

