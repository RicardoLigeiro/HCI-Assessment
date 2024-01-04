using Hci.Models.Entities;
using System.ComponentModel.DataAnnotations;
using Hci.Models.Sites;
using Hci.Models.Visits;

namespace Hci.Models.Security;

/// <summary>
///     Fake and simplistic representation of an employee
/// </summary>
public class User : ICreated
{
    /// <summary>
    ///     User id
    /// </summary>
    [Key]
    public int UserId { get; set; }

    /// <summary>
    ///     User first name
    /// </summary>
    [Required]
    [StringLength(75)]
    [MaxLength(75)]
    public required string FirstName { get; set; }

    /// <summary>
    ///     User Last name
    /// </summary>
    [Required]
    [StringLength(75)]
    [MaxLength(75)]
    public required string LastName { get; set; }

    /// <summary>
    ///     The user that created the record
    /// </summary>
    public int CreatedById { get; set; }

    /// <summary>
    ///     Record date
    /// </summary>
    public DateTime RecordDate { get; set; }

    // Mappings
    public ICollection<Hospital> Hospitals { get; set; }
    public ICollection<Person> Persons { get; set; }
    public ICollection<Visit> Visits { get; set; }
}