using Hci.Models.Security;
using System.ComponentModel.DataAnnotations;
using Hci.Models.Visits;

namespace Hci.Models.Sites;

/// <summary>
///     Fake and simplistic representation of an hospital
/// </summary>
public class Hospital : ICreated
{
    /// <summary>
    ///     Hospital id
    /// </summary>
    [Key]
    public int HospitalId { get; set; }

    /// <summary>
    ///     Hospital name
    /// </summary>
    [Required]
    [StringLength(250)]
    [MaxLength(250)]
    public required string Name { get; set; }

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
    public ICollection<Visit> Visits { get; set; }
}