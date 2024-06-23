using Rml.CoNexus.Core.Cnx;
using Rml.CoNexus.Core.CnxEvaluation;

namespace Rml.CoNexus.Core.CnxMatrixOperations;

[Flags]
public enum Names
{
    UNKNOWN = 0,

    Contributions,
    History,

    Weights,
    Effort,
    Balance,

    Worth,
    Cost,
    Value,

    Reference,

    ROW = 0x10,         // include ROW or COL
    COL = 0x20,
    SUMMARY = 0x40,     // include if this is a calculated ROW or COL
    GROUP = 0x80        // include if this is a group Matrix
}
public class Matrix : _EntityBase
{
    public Matrix(Inquiry inq, Evaluation individual) : base(inq.Title, null)
    {

    }

    // int Id;
    // string Text;  
    private CellBag? _weightRow;
    private CellBag? _effortRow;
    private CellBag? _balanceRow;
    private CellBag? _worthCol;
    private CellBag? _costCol;
    private CellBag? _valueCol;


}
public class CellBag : List<MatrixCell>
{
    public CellBag() { }

    public CellBag(string label, MatrixCollectionType mct, IEnumerable<MatrixCell> cells)
    {
        Label = label;
        Mct = mct;
        this.AddRange(cells);
    }

    public string Label { get; } = "";
    public MatrixCollectionType Mct { get; } = MatrixCollectionType.UNKNOWN;
}
