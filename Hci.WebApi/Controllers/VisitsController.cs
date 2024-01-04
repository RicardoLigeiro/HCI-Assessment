using Hci.Models.Visits;
using Hci.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hci.WebApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    private readonly IVisitRepository _repository;

    public VisitsController(IVisitRepository repository)
    {
        _repository = repository;
    }

    [HttpGet(Name = "Search")]
    public async Task<IEnumerable<VisitSearchListItem>> SearchVisits(int? hospitalId, string? personFirstName, string? personLastName, DateTime? entryDate, DateTime? exitDate)
    {
        // this just to show the call, we actually return all records here
        return await _repository.Search(hospitalId, personFirstName!, personLastName!, entryDate, exitDate);
    }
}