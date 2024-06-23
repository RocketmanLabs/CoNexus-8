using Rml.CoNexus.Core.CnxEvaluation;

namespace Rml.CoNexus.Core.CnxElicitation;

public class DemographicQuestion : Axis
{
    public DemographicQuestion() { }

    public DemographicQuestion(string name, int seq, string question, Scale scale)
        : base(name, null, seq, name, question, AxisType.DEMOGRAPHICS, VoteMethod.MULCH, scale)
    { }


    /* Axis:
        AxisType Assignment { get; set; }
        int InquiryId { get; set; }
        string? Label { get; set; }
        VoteMethod Method { get; set; }
        string? Question { get; set; }
        int Sequence { get; set; }
        Scale VotingScale { get; set; }
    */
}
