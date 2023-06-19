using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq.Expressions;

namespace Recruiting.UnitTests
{
    [TestClass]
    public class RecruitingServiceUnitTests
    {
        private JobService? sut;
        private readonly Mock<IJobRepository> sutRepository = new();
        [TestInitialize]
        public void Setup()
        {
            sutRepository.Setup(m => m.GetAllAsync()).ReturnsAsync(Enumerable.Empty<Job>());
            sut = new JobService(sutRepository.Object);
        }
        [TestMethod]
        public async Task TestListJobsFromFakeData()
        {
            // AAA: Arrange, Act, and Assert

            // Arrange

            // JobService -> GetAllJobsAsync()
            // Act
            var jobs = await sut!.GetAllJobsAsync();

            // Assert
            Assert.IsNotNull(jobs);
        }
    }
}