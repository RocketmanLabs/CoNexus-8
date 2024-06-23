using Rml.CoNexus.Core.CnxElicitation;
using Rml.CoNexus.Core.CnxEvaluation;
using Rml.CoNexus.Core.CnxParticipation;
using Rml.CoNexus.Core.Constants;

namespace Rml.CoNexus.Core;

public class Inquiry
{
    public Inquiry() 
    {
        Alternatives.Add(new Topic("Current", "A", null) { IsProtected = true });
    }

    public InquiryState State { get; set; } = InquiryState.SETUP;

    public string Title { get; set; } = "";
    public Participant? Facilitator { get; set; }
    public Group People { get; set; } = new();
    public Axes Axes { get; set; } = new();
    public TopicList Alternatives { get; set; } = new();
    public TopicList TopicList { get; set; } = new();
    public Evaluations Evaluations { get; set; } = new();
}

