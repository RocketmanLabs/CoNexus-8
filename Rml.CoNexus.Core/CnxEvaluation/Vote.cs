namespace Rml.CoNexus.Core.CnxEvaluation;

public class Vote
{
    public Vote() { }

    public Vote(int participantId, int axisId, int topicId)
    {
        ParticipantId = participantId;
        AxisId = axisId;
        SelectedTopicId = topicId;
    }

    public bool Voted { get; set; }             // until this is set it is a tracker
    public int AxisId { get; private set; }
    public int ParticipantId {  get; private set; }
    public int SelectedTopicId { get; set; }    // displayed on top for Pairs voting
    public int ComparisonTopicId { get; set; }

    public decimal Raw { get; set; }
    public decimal Scaled { get; set; }
    public decimal Weighted { get; set; }

    public static Vote Empty => new Vote() { Voted = true };
}

