using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Infrustructure.Data;
using Infrustructure.Repositories;
using Infrustructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IJobRepository, JobRepository>();

builder.Services.AddScoped<IJobService, JobService>();

builder.Services.AddDbContext<RecruitingDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbConnection"), x => x.MigrationsAssembly("Recruiting.API"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

