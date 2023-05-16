using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Candidate
{
    public int Id { get; set; }
    public Guid CandidateIdentityId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public string? ResumeURL { get; set; }
    public ICollection<Submission>? Submissions { get; set; }
}
