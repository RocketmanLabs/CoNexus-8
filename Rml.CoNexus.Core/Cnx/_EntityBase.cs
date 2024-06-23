using System.Linq;
using Rml.CoNexus.Core.Interfaces;

namespace Rml.CoNexus.Core.Cnx;

public abstract class _EntityBase : IEntity, IComparable<_EntityBase>
{
    static int _lastId = 0;

    public _EntityBase()
    {
        ++_lastId;
        Id = _lastId;
    }

    public _EntityBase(string name, string? comment)
    {
        ++_lastId;
        Id = _lastId;
        Text = name;
        Description = comment;
    }

    public int Id { get; set; }
    public virtual string Text { get; set; } = "";
    public virtual string? Description { get; set; } = "";

    public bool IsProtected { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsHidden { get; set; }

    public int CompareTo(_EntityBase? other) => other is not null 
        ? Id.CompareTo(_lastId) 
        : -1;

    protected static void SetLastId(int lastId) => _lastId = lastId;
}

