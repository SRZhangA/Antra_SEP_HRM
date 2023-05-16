namespace ApplicationCore.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid EmployeeIdeneityId { get; set; }
    public DateTime EndDate { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }

    // Navigation
    public int EmployeeStatusId { get; set; }
    public EmployeeStatusLookUp EmployeeStatus { get; set; } = new();
}
