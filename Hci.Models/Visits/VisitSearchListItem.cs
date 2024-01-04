namespace Hci.Models.Visits;

/// <summary>
///     This represents a visit search result in the database
/// </summary>
public class VisitSearchListItem
{
    /// <summary>
    ///     Visit id
    /// </summary>
    public int VisitId { get; set; }

    /// <summary>
    ///     Hospital id
    /// </summary>
    public int HospitalId { get; set; }

    /// <summary>
    ///     Hospital name
    /// </summary>
    public string HospitalName { get; set; }

    /// <summary>
    ///     Person id
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    ///     Person's full name
    /// </summary>
    public string PersonFullName { get; set; }

    /// <summary>
    ///     Document Type
    /// </summary>
    public string DocumentType { get; set; }

    /// <summary>
    ///     Document Id
    /// </summary>
    public string? DocumentId { get; set; }

    /// <summary>
    ///     Entrance time
    /// </summary>
    public DateTime EntryDate { get; set; }

    /// <summary>
    ///     Exit time
    /// </summary>
    public DateTime? ExitDate { get; set; }

    /// <summary>
    ///     Elapsed time
    /// </summary>
    public string ElapsedTime => EntryDate.CalculateElapsedTime(ExitDate);
}