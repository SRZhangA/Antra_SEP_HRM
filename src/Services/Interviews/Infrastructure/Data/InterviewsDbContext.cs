using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class InterviewsDbContext : DbContext
{
    public InterviewsDbContext(DbContextOptions<InterviewsDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Interview>(ConfigureInterview);
    }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Interviewer> Interviewers { get; set; }
    public DbSet<InterviewTypeLookUp> InterviewTypeLookUps { get; set; }
    private void ConfigureInterview(EntityTypeBuilder<Interview> builder)
    {
        builder.Property(x => x.InterviewTypeId).HasDefaultValue(1);
    }
}
