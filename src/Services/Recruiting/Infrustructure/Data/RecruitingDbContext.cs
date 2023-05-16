using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrustructure.Data;

public class RecruitingDbContext : DbContext
{
    public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(ConfigureCandidate);
    }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<JobStatusLookUp> JobStatusLookUps { get; set; }
    public DbSet<Submission> Submissions { get; set; }

    private void ConfigureCandidate(EntityTypeBuilder<Candidate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("getDate()");
    }
}
