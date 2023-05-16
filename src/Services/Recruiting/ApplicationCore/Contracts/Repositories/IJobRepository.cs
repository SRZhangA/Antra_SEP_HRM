using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IJobRepository : IBaseRepository<Job>
{
    public Task<IEnumerable<Job>> GetAllByPageOrderedByDateAsync(int page);
}
