using Rml.CoNexus.Core.CnxEvaluation;
using Rml.CoNexus.Core.CnxParticipation;

namespace Rml.CoNexus.Core.CnxResults;

public class Result
{
    public Result() { }

    public Result(Participant p, Axis axis, decimal value) { Value = value; }

    public int ParticipantId { get; set; }

    public decimal Value { get; set; }
    public decimal Scaled { set; get; }
    public decimal Normalized { set; get; }
}
