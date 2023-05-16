using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class OnBoardingDbContext : DbContext
{
    public OnBoardingDbContext(DbContextOptions<OnBoardingDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(ConfigureEmployee);
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeStatusLookUp> EmployeeStatusLookUps { get; set; }

    private void ConfigureEmployee(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.EmployeeStatusId).HasDefaultValue(1);
    }
}
