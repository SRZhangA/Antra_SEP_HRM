using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public Task<IEnumerable<Employee>> GetAllByPageAsync(int page);
}
