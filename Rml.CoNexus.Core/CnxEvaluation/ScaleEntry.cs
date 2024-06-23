using Rml.CoNexus.Core.CnxElicitation;

namespace Rml.CoNexus.Core.CnxEvaluation;

public class ScaleEntry : Choice
{
    public ScaleEntry() { }

    public ScaleEntry(ConsoleKey selectionKey, bool scaleGroupBottom, decimal value, string text)
        : base(text, value, selectionKey)
    {
        ScaleGroupBottom = scaleGroupBottom;
    }

    public ScaleEntry(bool isPlaceholder) => IsPlaceholder = isPlaceholder;

    public bool ScaleGroupBottom { get; set; }
    public bool IsPlaceholder { get; set; }
}

