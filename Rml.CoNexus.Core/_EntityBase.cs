using System.Linq;

namespace Rml.CoNexus.Core;

public abstract class _EntityBase
{
    static int _lastId = 0;

    public _EntityBase()
    {
        ++_lastId;
        Id = _lastId;
    }

    public _EntityBase(string name)
    {
        ++_lastId;
        Id = _lastId;
        Text = name;
    }

    public int Id { get; set; }
    public virtual string Text { get; set; } = "";

    protected static void SetLastId(int lastId) => _lastId = lastId;
}

