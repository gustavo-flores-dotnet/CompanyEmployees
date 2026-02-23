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
    /// It obtains all the employees of a company.
    /// </summary>
    /// <param name="companyId">Company ID (GUID).</param>
    /// <response code="200">List of employees.</response>
    /// <response code="404">The company does not exist.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetEmployeesForCompany(Guid companyId)
    {
        var employees = _service.EmployeeService.GetEmployees(companyId, false);
        return Ok(employees);
    }

    /// <summary>
    /// Obtains a specific employee within a company.
    /// </summary>
    /// <param name="companyId">Company ID (GUID).</param>
    /// <param name="id">Employee ID (GUID).</param>
    /// <response code="200">Employee found.</response>
    /// <response code="404">The company or the employee does not exist.</response>
    [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
    {
        var employee = _service.EmployeeService.GetEmployee(companyId, id, trackChanges: false);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
    {
        if (employee is null)
            return BadRequest("EmployeeForCreation object is null");

        var employeeToReturn = _service.EmployeeService.
            CreateEmployeeForCompany(companyId, employee, trackChanges: false);
        return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
    }
}
