using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnBoarding.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }
    [HttpGet("AllEmployees/{pageId}")]
    public async Task<IActionResult> GetJobsByPagination(int pageId)
    {
        var jobs = await employeeService.GetAllEmployeesByPageAsync(pageId);

        if (!jobs.Any())
        {
            return NotFound();
        }
        return Ok(jobs);
    }
}
