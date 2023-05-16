using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class InterviewsDbContext : DbContext
{
    public InterviewsDbContext(DbContextOptions<InterviewsDbContext> options) : base(options)
    {

    }
}
