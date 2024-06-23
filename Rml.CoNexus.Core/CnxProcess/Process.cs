using Rml.CoNexus.Core.Cnx;

namespace Rml.CoNexus.Core.CnxProcess;

public class Process : _EntityBase
{
    public Process(string name, string? descr) : base(name, descr)
    {

    }

    public bool IsTemplate { get; set; }

}
public enum ProcessStepState : byte
{
    SETUP = 0,
    LOCKED,
    AVAILABLE,
    ACTIVE,
    COMPLETE,
    DISABLED
}
public class ProcessStep : _EntityBase
{
    public ProcessStep(string name, string? descr, bool isTemplate) :
        base(name, descr) { IsHidden = isTemplate; }
   
    public bool IsTemplate { get; set; }
    public ProcessStepState State { get; set; } = ProcessStepState.SETUP;

    public bool Configure(Args args) 
    {
        return false;
    }

    public bool Run(Args args)
    {
        return false;
    }

}
