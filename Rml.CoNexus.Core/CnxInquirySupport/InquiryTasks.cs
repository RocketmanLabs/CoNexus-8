using Rml.CoNexus.Core.Extensions;

namespace Rml.CoNexus.Core.CnxInquirySupport;

public class InquiryTasks
{
    private List<InquiryTask> _tasks = [];

    public InquiryTask? Next() => _tasks.FirstOrDefault(x => x.Completed == false);

    public void MarkProgress(InquiryTask task) => task.Remaining = task.Count.Min(task.Remaining);

    public void MarkCompleted(InquiryTask task) => task.Remaining = 0;
}
