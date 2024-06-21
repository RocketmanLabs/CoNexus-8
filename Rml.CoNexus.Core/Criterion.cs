namespace Rml.CoNexus.Core;

public class Criterion : Topic
{
    public Criterion() { }
    public Criterion(string natextme, string symbol, string? comment) : base(natextme, comment)
    {
        Symbol = symbol;
    }

    public string Symbol { get; set; } = "";
}

