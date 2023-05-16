using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobRequestModel
{
    [Required(ErrorMessage ="Please enter title of the job")]
    [StringLength(256)]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please enter description of the job")]
    [StringLength(5000)]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please enter job start date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [Required(ErrorMessage = "Please enter numbers of positions")]
    public int NumbersOfPositions { get; set; }
}
