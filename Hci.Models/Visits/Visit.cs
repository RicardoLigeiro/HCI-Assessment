using Hci.Models.Entities;
using Hci.Models.Security;
using Hci.Models.Sites;
using System.ComponentModel.DataAnnotations;

namespace Hci.Models.Visits;

/// <summary>
///     Fake and simplistic representation of an hospital visit
/// </summary>
public class Visit : ICreated
{
    /// <summary>
    ///     Visit id
    /// </summary>
    [Key]
    public int VisitId { get; set; }

    /// <summary>
    ///     Hospital id
    /// </summary>
    public int HospitalId { get; set; }

    /// <summary>
    ///     Person id
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    ///     Entrance time
    /// </summary>
    public DateTime EntryDate { get; set; }

    /// <summary>
    ///     Exit time
    /// </summary>
    public DateTime? ExitDate { get; set; }

    /// <summary>
    ///     The user that created the record
    /// </summary>
    public int CreatedById { get; set; }

    /// <summary>
    ///     Record date
    /// </summary>
    public DateTime RecordDate { get; set; }

    // Mappings 
    public User User { get; set; }
    public Person Person { get; set; }
    public Hospital Hospital { get; set; }
}