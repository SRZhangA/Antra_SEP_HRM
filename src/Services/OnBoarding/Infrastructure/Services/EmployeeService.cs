using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Collections.Generic;

namespace Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }
    public Task<int> AddJobAsync(EmployeeRequestModel job)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmployeeResponseModel>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<EmployeeResponseModel>> GetAllEmployeesByPageAsync(int page)
    {
        var list = await employeeRepository.GetAllByPageAsync(page);
        List<EmployeeResponseModel> response = new();
        foreach (var item in list)
        {
            response.Add(new()
            {
                Address = item.Address,
                EndDate = item.EndDate,
                HireDate = item.HireDate,
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName,
                EmployeeIdentityId = item.EmployeeIdentityId,
            });
        }
        return response;
    }

    public Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
