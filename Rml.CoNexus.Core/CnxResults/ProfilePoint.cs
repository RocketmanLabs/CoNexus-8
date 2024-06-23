namespace Rml.CoNexus.Core.CnxResults;

public class ProfilePoint
{
    public ProfilePoint() { }

    public ProfilePoint(int critId, string text, decimal x, decimal y)
    {
        CriteriaId = critId;
        Text = text;
        X = x;
        Y = y;
    }

    public int CriteriaId { get; set; }
    public string Text { get; set; } = "";
    public decimal X { get; set; }
    public decimal Y { get; set; }

    public override string ToString() => $"{Text}: {X},{Y}";
}

