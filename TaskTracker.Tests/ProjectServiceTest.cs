using Microsoft.EntityFrameworkCore;
using Moq;
using TaskTracker.DAL;
using TaskTracker.DAL.Model;
using TaskTracker.Logic;
using TaskTracker.Logic.Implementations;
using TaskTracker.Logic.Interfaces;

namespace TaskTracker.Tests
{
    public class ProjectServiceTest
    {
        private const string _connectionString = "Server=localhost;User ID=postgres;Password=admin;Port=5432;Database=TaskTrackerDB;";

        [Fact]
        public void GetProjectsTestById()
        {
            //Arrange
            DbContextOptionsBuilder<TrackerDBContext> dbContextOptions = new DbContextOptionsBuilder<TrackerDBContext>().UseNpgsql(_connectionString);
            TrackerDBContext context = new TrackerDBContext(dbContextOptions.Options);
            ProjectService projectService = new ProjectService(context);

            //Act
            Project project = projectService.GetProjectById(77);

            //Assert
            Assert.NotNull(project);
        }
    }
}