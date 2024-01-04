namespace Hci.Models;

/// <summary>
///     Contract for the creation of records on the entities
///     (It should be other like IChanged, etc)
/// </summary>
public interface ICreated
{
    /// <summary>
    ///     The user that created the record
    /// </summary>
    public int CreatedById { get; set; }

    /// <summary>
    ///     Record date
    /// </summary>
    public DateTime RecordDate { get; set; }
}