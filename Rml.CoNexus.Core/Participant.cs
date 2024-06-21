namespace Rml.CoNexus.Core;

public class Participant : _EntityBase
{
    public Participant() { }
    public Participant(string name, bool remainAnonymous) : base(name)
    {
        IsAnonymous = remainAnonymous;
    }

    public bool IsAnonymous { get; set; }

    public override string Text
    {
        get => IsAnonymous ? "Anonymous #" + this.Id.ToString() : base.Text;
    }
}

