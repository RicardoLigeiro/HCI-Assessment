using System.ComponentModel;

namespace Hci.Models.Entities;

/// <summary>
///     Weak representation of a document type
/// </summary>
public enum DocumentType : byte
{
    [Description("Citizen Card")] Unknown = 1,
    [Description("Citizen Card")] CitizenCard,
    [Description("Passport")] Passport
}