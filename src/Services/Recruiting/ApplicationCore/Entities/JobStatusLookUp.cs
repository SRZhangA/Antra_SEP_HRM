namespace ApplicationCore.Entities;

public class JobStatusLookUp
{
    public int Id { get; set; }
    public string JobStatusCode { get; set; } = string.Empty;
    public string? JobStatusDescription { get; set; }
}
