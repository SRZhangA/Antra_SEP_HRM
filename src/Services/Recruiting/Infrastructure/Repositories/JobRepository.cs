using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class JobRepository : BaseRepository<Job>, IJobRepository
{
    public JobRepository(RecruitingDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<IEnumerable<Job>> GetAllByPageOrderedByDateAsync(int page)
    {
        int pageSize = 2;
        return await dbContext.Jobs.OrderByDescending(x => x.StartDate)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
    }

}
