using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IJobService
{
    Task<List<JobResponseModel>> GetAllJobsAsync();
    Task<List<JobResponseModel>> GetAllJobsByPageAsync(int page);
    Task<JobResponseModel> GetJobByIdAsync(int id);
    Task<int> AddJobAsync(JobRequestModel job);
}
