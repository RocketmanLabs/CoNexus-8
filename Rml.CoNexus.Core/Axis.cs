namespace Rml.CoNexus.Core;

public class Axis : _EntityBase
{
    public Axis() { }

    public Axis(string name, string question, int sequence, AxisAssignment assigned, VoteMethod method, Scale scale) : base(name)
    {
        Sequence = sequence;
        Method = method;
        Assignment = assigned;
        VotingScale = scale;
    }

    public int Sequence { get; set; }
    public AxisAssignment Assignment { get; set; } = AxisAssignment.CONTRIBUTIONS;
    public string Label { get; set; } = "?";
    public string Question { get; set; } = "?";
    public VoteMethod Method { get; set; } = VoteMethod.UNKNOWN;
    public Scale VotingScale { get; set; } = new();
}

