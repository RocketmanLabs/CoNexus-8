namespace Rml.CoNexus.Core;

public class Topic : _EntityBase
{
    public Topic() { }

    public Topic(string name, string? comment) : base(name)
    {
        Comment = comment;
    }

    public string? Comment { get; set; }
}

