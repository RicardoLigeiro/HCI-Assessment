using Hci.Models.Visits;

namespace Hci.Services;

/// <summary>
///     Public contract for the visits
/// </summary>
public interface IVisitRepository
{
    /// <summary>
    ///     Executes a search on the database
    /// </summary>
    /// <param name="hospitalId">Hospital Id</param>
    /// <param name="personFirstName">Person's first name</param>
    /// <param name="personLastName">Person's last name</param>
    /// <param name="entryDate">Entry date</param>
    /// <param name="exitDate">Exit date</param>
    /// <returns></returns>
    Task<IEnumerable<VisitSearchListItem>> Search(int? hospitalId, string personFirstName, string personLastName,
        DateTime? entryDate, DateTime? exitDate);
}