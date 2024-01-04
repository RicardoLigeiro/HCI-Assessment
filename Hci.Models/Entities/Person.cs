using System.ComponentModel.DataAnnotations;
using Hci.Models.Security;
using Hci.Models.Visits;

namespace Hci.Models.Entities;

/// <summary>
///     Fake and simplistic representation of a person
/// </summary>
public class Person : ICreated
{
    /// <summary>
    ///     Person id
    /// </summary>
    [Key]
    public int PersonId { get; set; }

    /// <summary>
    ///     Person first name
    /// </summary>
    [Required]
    [StringLength(75)]
    [MaxLength(75)]
    public string? FirstName { get; set; }

    /// <summary>
    ///     Person last name
    /// </summary>
    [MaxLength(75)]
    public string? LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    ///     Document Type
    /// </summary>
    public DocumentType DocumentType { get; set; }

    /// <summary>
    ///     Document Id
    /// </summary>
    [MaxLength(50)]
    public string? DocumentId { get; set; }

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