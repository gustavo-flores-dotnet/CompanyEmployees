using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IServiceManager _service;
    public CompaniesController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Gets all the companies.
    /// </summary>
    /// <remarks>
    /// trackChanges = false to optimize read-only queries.
    /// </remarks>
    /// <response code="200">List of companies.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetCompanies()
    {
        var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);
            return Ok(companies);
    }

    /// <summary>
    /// Get a company by its ID.
    /// </summary>
    /// <param name="id">Company ID (GUID).</param>
    /// <response code="200">Company found.</response>
    /// <response code="404">There is no company with that ID.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCompany(Guid id)
    {
        var company = _service.CompanyService.GetCompany(id, trackChanges: false);
        return Ok(company);
    }
}
