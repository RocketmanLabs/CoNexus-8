using Rml.CoNexus.Core.Cnx;
using Rml.CoNexus.Core.Interfaces;

namespace Rml.CoNexus.Core.CnxEvaluation;

public class Axis : _EntityBase, IAxis
{
    public Axis() { }

    public Axis(string name,
                string? descr,
                int seq,
                string label,
                string question,
                AxisType assn,
                VoteMethod method,
                Scale scale) : base(name, descr)
    {
        Question = question;
        Sequence = seq;
        Assignment = assn;
        Method = method;
        VotingScale = scale;
    }

    public int InquiryId { get; set; }

    public int Sequence { get; set; }
    public string? Question { get; set; } = "?";
    public AxisType Assignment { get; set; } = AxisType.CONTRIBUTIONS;
    public string? Label { get; set; } = "?";
    public VoteMethod Method { get; set; } = VoteMethod.UNKNOWN;
    public Scale VotingScale { get; set; } = [];

    /* IAxis:
        AxisType Assignment { get; set; }
        int InquiryId { get; set; }
        string? Label { get; set; }
        VoteMethod Method { get; set; }
        string? Question { get; set; }
        int Sequence { get; set; }
        Scale VotingScale { get; set; }
    */
}

