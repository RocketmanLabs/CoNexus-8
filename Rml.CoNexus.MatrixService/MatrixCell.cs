namespace Rml.CoNexus.MatrixService;
public class MatrixCell
{
    public MatrixCell() { }
    public MatrixCell(decimal raw, decimal weight)
    {
        Raw = raw;
        Weight = weight;
        Weighted = raw * weight;
    }

    public decimal Raw { get; set; }
    public decimal Weighted { get; set; }
    public decimal Scaled { get; set; }

    private decimal Weight = 1.0m;

    public override string ToString()
    {
        return base.ToString();
    }
}
public class MatrixSummary()
{
    public MatrixSummary() { }
    public MatrixSummary() { }
}
