using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers;
[Route("api/companies/{companyId:guid}/employees")]
[ApiController]

public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _service;
    public EmployeesController(IServiceManager service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene todos los empleados de una compañía.
    /// </summary>
    /// <param name="companyId">Id de la compañía (GUID).</param>
    /// <response code="200">Lista de empleados.</response>
    /// <response code="404">La compañía no existe.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetEmployeesForCompany(Guid companyId)
    {
        var employees = _service.EmployeeService.GetEmployees(companyId, false);
        return Ok(employees);
    }

    /// <summary>
    /// Obtiene un empleado específico dentro de una compañía.
    /// </summary>
    /// <param name="companyId">Id de la compañía (GUID).</param>
    /// <param name="id">Id del empleado (GUID).</param>
    /// <response code="200">Empleado encontrado.</response>
    /// <response code="404">La compañía o el empleado no existen.</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
    {
        var employee = _service.EmployeeService.GetEmployee(companyId, id, trackChanges: false);
        return Ok(employee);
    }
}
