namespace ApplicationCore.Models;

public class EmployeeResponseModel
{
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid EmployeeIdentityId { get; set; }
    public DateTime EndDate { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
}
