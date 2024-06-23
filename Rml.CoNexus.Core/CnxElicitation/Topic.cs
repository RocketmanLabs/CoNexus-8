using Rml.CoNexus.Core.Cnx;

namespace Rml.CoNexus.Core.CnxElicitation;

public class Topic : _EntityBase
{
    public Topic() { }

    public Topic(string name, string symbol, string? comment) : base(name, comment)
    {
        Symbol = symbol;
    }

    public string Symbol { get; set; } = "?";
}

