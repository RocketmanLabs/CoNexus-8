namespace Rml.CoNexus.Core.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        string Text { get; set; }
        string? Description { get; set; }

        bool IsDeleted { get; set; }
        bool IsHidden { get; set; }
        bool IsProtected { get; set; }
    }
}