using Rml.CoNexus.Core.Extensions;

namespace Rml.CoNexus.Core;

public class EvaluationProgress
{
    public EvaluationProgress(Axis axis, Participant person)
    {
        AxisId = axis.Id;
        AxisName = axis.Text;
        ParticipantId = person.Id;
        ParticipantName = person.Text;
    }

    public int AxisId { get; set; }
    public string AxisName { get; set; }
    public int ParticipantId { get; set; }
    public string ParticipantName { get; set; }
    public int ItemCount { get; set; }
    public int ItemsRemaining { get; set; }
    public string PctComplete => ItemCount.PctComplete(ItemsRemaining);
}

