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
    /// Obtiene todas las compañías.
    /// </summary>
    /// <remarks>
    /// trackChanges = false para optimizar consultas de solo lectura.
    /// </remarks>
    /// <response code="200">Lista de compañías.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetCompanies()
    {
        var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);
            return Ok(companies);
    }

    /// <summary>
    /// Obtiene una compañía por su id.
    /// </summary>
    /// <param name="id">Id de la compañía (GUID).</param>
    /// <response code="200">Compañía encontrada.</response>
    /// <response code="404">No existe una compañía con ese id.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCompany(Guid id)
    {
        var company = _service.CompanyService.GetCompany(id, trackChanges: false);
        return Ok(company);
    }
}
