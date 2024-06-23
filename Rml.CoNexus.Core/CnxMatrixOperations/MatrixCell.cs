namespace Rml.CoNexus.Core.CnxMatrixOperations;

public class MatrixCell
{
    public MatrixCell() { }

    public MatrixCell(int rowId, int colId, string? text = null)
    {
        RowId = rowId;
        ColId = colId;
        Text = text;
    }

    public string? Text { get; }
    public int RowId { get; }
    public int ColId { get; }

    public decimal Raw { get; set; }
    public decimal Scaled { get; set; }
    public decimal Weighted { get; set; }
}
