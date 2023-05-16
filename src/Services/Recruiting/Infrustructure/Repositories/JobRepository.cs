using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrustructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure.Repositories;

public class JobRepository : BaseRepository<Job>, IJobRepository
{
    public JobRepository(RecruitingDbContext dbContext) :base(dbContext)
    {

    }

}
