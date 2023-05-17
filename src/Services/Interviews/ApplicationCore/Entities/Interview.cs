namespace ApplicationCore.Entities;

public class Interview
{
    public int Id { get; set; }
    public DateTime BeginTime { get; set; }
    public string CandidateEmail { get; set; } = string.Empty;
    public string CandidateFirstName { get; set; } = string.Empty;
    public Guid CandidateIdentityId { get; set; }
    public string CandidateLastName { get; set; } = string.Empty;
    public DateTime EndTime { get; set; }
    public string Feedback { get; set; } = string.Empty;
    public bool Passed { get; set; }
    public int Rating { get; set; }
    public int SubmissionId { get; set; }

    // Navigation
    public Interviewer Interviewer { get; set; } = new();
    public int InterviewerId { get; set; }
    public InterviewTypeLookUp InterviewType { get; set; } = new();
    public int InterviewTypeId { get; set; }
}
