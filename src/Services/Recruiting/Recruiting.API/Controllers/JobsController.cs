using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobsController : ControllerBase
{
    private readonly IJobService jobService;

    public JobsController(IJobService jobService)
    {
        this.jobService = jobService;
    }
    [HttpGet("AllJobs/{int:pageId}")]
    public async Task<IActionResult> GetJobsByPagination(int pageId)
    {
        var jobs = await jobService.GetAllJobsAsync();

        if(!jobs.Any())
        {
            return NotFound();
        }
        return Ok(jobs);
    }
    [HttpGet("{id:int}", Name = "GetJobDetails")]
    public async Task<IActionResult> GetJobDetails(int id)
    {
        var job = await jobService.GetJobByIdAsync(id);

        if (null == job )
        {
            return NotFound();
        }
        return Ok(job);
    }
    [HttpPost]
    public async Task<IActionResult> Create(JobRequestModel model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var job = await jobService.AddJobAsync(model);
        return CreatedAtAction("GetJobDetails", new {controller = "jobs", id = job}, "Job created");
    }
}
