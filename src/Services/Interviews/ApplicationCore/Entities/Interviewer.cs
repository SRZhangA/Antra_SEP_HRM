namespace ApplicationCore.Entities;

public class Interviewer
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public Guid EmployeeIdentitityId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
