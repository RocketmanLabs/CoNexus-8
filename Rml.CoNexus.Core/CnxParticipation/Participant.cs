using Rml.CoNexus.Core.Cnx;

namespace Rml.CoNexus.Core.CnxParticipation;

public class Participant : _EntityBase
{
    public Participant() { }

    public Participant(string name, bool remainAnonymous) : base(name, null)
    {
        IsAnonymous = remainAnonymous;
    }


    public bool IsAnonymous { get; set; }

    public bool OmitFromResults { get; set; }

    public override string Text => IsAnonymous ? "Anonymous #" + Id.ToString() : base.Text;

    public override string ToString() => $"[{Id}]: {Text}{(IsAnonymous ? "(ANONYMOUS)" : "")}";
}

