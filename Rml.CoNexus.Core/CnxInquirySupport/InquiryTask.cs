using Rml.CoNexus.Core.Cnx;
using Rml.CoNexus.Core.Extensions;

namespace Rml.CoNexus.Core.CnxInquirySupport;

public class InquiryTask : _EntityBase
{
    public InquiryTask() { }
    public InquiryTask(int inqId,
                       string name,
                       string? descr,
                       InquiryTaskType itt,
                       int targetId,
                       int count) : base(name, descr)
    {
        InquiryId = inqId;
        Description = descr;
        TaskType = itt;
        TargetId = targetId;
        Count = count;
        Remaining = 0;
    }

    // int Id;
    // int Text; (name)

    public int InquiryId { get; set; }
    public string? Description { get; set; }
    public bool Wip => Count > 0 && Remaining > 0;
    public bool Completed => Count > 0 && Remaining == 0;

    public InquiryTaskType TaskType { get; set; } = InquiryTaskType.UNASSIGNED;
    public int TargetId { get; set; }
    public int Count { get; set; }
    public int Remaining { get; set; }
    public string PctComplete => Count.PctComplete(Remaining);

    public override string ToString() => $"[{Id}]: {Text} ({TaskType}) {PctComplete} {Wip.Show("WIP")}, {Completed.Show("Completed")}";
}
