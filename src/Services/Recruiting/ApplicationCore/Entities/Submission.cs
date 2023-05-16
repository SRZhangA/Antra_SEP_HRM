namespace ApplicationCore.Entities;

public class Submission
{
    public int Id { get; set; }
    public DateTime? SubmissedOn { get; set; }
    public DateTime? SelectedForInterview { get; set; }
    public DateTime? RejectedOn { get; set; }
    public string RejectedReason { get; set; } = string.Empty;

    // Navigations and FKs
    public Job Job { get; set; } = new();
    public int JobId { get; set; }
    public Candidate Candidate { get; set; } = new();
    public int CandidateId { get; set; }
}
