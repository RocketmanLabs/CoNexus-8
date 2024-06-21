using Rml.CoNexus.Core.Constants;

namespace Rml.CoNexus.Core;

public class Inquiry
{
    public Inquiry() { }

    public InquiryState State { get; set; }
    public string Title { get; set; } = "";
    public Group People { get; set; } = new();
    public Axes Axes { get; set; } = new();
    public Criteria Criteria { get; set; } = new();
    public Profile? Profile { get; set; }
}

