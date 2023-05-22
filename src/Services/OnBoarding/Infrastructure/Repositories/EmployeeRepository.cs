using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(OnBoardingDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Employee>> GetAllByPageAsync(int page)
    {
        int pageSize = 2;
        return await dbContext.Employees.Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
    }
}
