using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class JobService : IJobService
{
    private readonly IJobRepository jobRepository;

    public JobService(IJobRepository jobRepository)
    {
        this.jobRepository = jobRepository;
    }

    public async Task<int> AddJobAsync(JobRequestModel model)
    {
        var jobEntity = new Job()
        {
            Description = model.Description,
            Title = model.Title,
            StartDate = model.StartDate,
            NumberOfPosition = model.NumbersOfPositions,
            CreatedOn = DateTime.UtcNow,
            JobStatusLookUpId = 1,
            JobCode = Guid.NewGuid(),
        };

        var job = await jobRepository.AddAsync(jobEntity);
        return job.Id;
    }

    public async Task<List<JobResponseModel>> GetAllJobsAsync()
    {
        var jobs = await jobRepository.GetAllAsync();

        List<JobResponseModel> response = new();

        foreach (var job in jobs)
        {
            response.Add(new JobResponseModel()
            {
                Id = job.Id,
                Description = job.Description,
                Title = job.Title,
                StartDate = job.StartDate,
                NumberOfPositions = job.NumberOfPosition
            });
        }

        return response;
    }

    public async Task<List<JobResponseModel>> GetAllJobsByPageAsync(int page)
    {
        var jobs = await jobRepository.GetAllByPageOrderedByDateAsync(page);

        List<JobResponseModel> response = new();

        foreach (var job in jobs)
        {
            response.Add(new JobResponseModel()
            {
                Id = job.Id,
                Description = job.Description,
                Title = job.Title,
                StartDate = job.StartDate,
                NumberOfPositions = job.NumberOfPosition
            });
        }
        return response;
    }

    public async Task<JobResponseModel> GetJobByIdAsync(int id)
    {
        var job = await jobRepository.GetByIdAsync(id);
        if (job == null)
        {
            return new();
        }

        return new JobResponseModel()
        {
            Id = job.Id,
            Description = job.Description,
            Title = job.Title,
            StartDate = job.StartDate,
            NumberOfPositions = job.NumberOfPosition
        };
    }
}
