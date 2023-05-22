using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IEmployeeService
{
    Task<List<EmployeeResponseModel>> GetAllEmployeesAsync();
    Task<List<EmployeeResponseModel>> GetAllEmployeesByPageAsync(int page);
    Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id);
    Task<int> AddJobAsync(EmployeeRequestModel job);
}
