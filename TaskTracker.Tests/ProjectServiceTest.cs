using FizzWare.NBuilder;
using Moq;
using TaskTracker.DAL.Model;
using TaskTracker.Logic;
using TaskTracker.Logic.Implementations;
using TaskTracker.Logic.Interfaces;

namespace TaskTracker.Tests
{
    public class ProjectServiceTest
    {
        private readonly ProjectService _productService;
        private Mock<ProjectService> _mockProjectService= new Mock<ProjectService>();
        IEnumerable<Project> _productsDbSetMock;
        Project _productDbSetMock;

        public ProductServiceTest()
        {
            _mockProjectService = new ProjectService(_mockProjectService.Object);
            _productsDbSetMock = Builder<Project>.CreateListOfSize(5).Build().AsEnumerable();
            _productDbSetMock = Builder<Project>.CreateNew().Build();
        }

        [Fact]
        public void GetAllProjectsTest()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}