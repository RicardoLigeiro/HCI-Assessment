using Hci.Models;
using Hci.Models.Visits;
using Microsoft.EntityFrameworkCore;

namespace Hci.Services;

internal sealed class VisitRepository : BaseRepository, IVisitRepository
{
    public VisitRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    ///     Executes a search on the database
    /// </summary>
    /// <param name="hospitalId">Hospital Id (we just use demonstration purposes as we actually don't pass any values)</param>
    /// <param name="personFirstName">Person's first name</param>
    /// <param name="personLastName">Person's last name</param>
    /// <param name="entryDate">Entry date</param>
    /// <param name="exitDate">Exit date</param>
    /// <returns></returns>
    public async Task<IEnumerable<VisitSearchListItem>> Search(int? hospitalId, string personFirstName,
        string personLastName, DateTime? entryDate, DateTime? exitDate)
    {
        // for simplifying we are not implement counter's or pagination
        // we are also not returning the user that created the record, etc
        // this just to show the call, we actually return all records here, it's just to show a search
        // the variables are null

        return await (from visit in Context.Visits
                      join hospital in Context.Hospitals on visit.HospitalId equals hospital.HospitalId
                      join person in Context.Persons on visit.PersonId equals person.PersonId
                      where !hospitalId.HasValue || hospital.HospitalId == hospitalId
                      where string.IsNullOrEmpty(personFirstName) || person.FirstName.Contains(personFirstName)
                      where string.IsNullOrEmpty(personLastName) || person.FirstName.Contains(personLastName)
                      where !entryDate.HasValue || visit.EntryDate.Date >= entryDate.Value.Date
                      where !exitDate.HasValue || (visit.ExitDate.HasValue && visit.ExitDate.Value.Date <= exitDate.Value.Date)
                      select new VisitSearchListItem
                      {
                          VisitId = visit.VisitId,
                          HospitalId = hospital.HospitalId,
                          HospitalName = hospital.Name,
                          PersonId = person.PersonId,
                          PersonFullName = person.FullName,
                          DocumentType = person.DocumentType.Description(),
                          DocumentId = person.DocumentId,
                          EntryDate = visit.EntryDate,
                          ExitDate = visit.ExitDate
                      }).ToListAsync();
    }
}