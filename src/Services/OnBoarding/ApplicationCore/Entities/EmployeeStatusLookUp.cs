namespace ApplicationCore.Entities;

public class EmployeeStatusLookUp
{
    public int Id { get; set; }
    public string EmployeeStatusCode { get; set; } = string.Empty;
    public string EmployeeStatusDescription { get; set; } = string.Empty;
}
