using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services;
using Moq;
using Xunit;

namespace GrandLineAuto.Services.Tests
{
    public class BaseServiceTests
    {
        [Fact]
        public async Task GetAllEntitiesAsync_Returns_All_From_Repository()
        {
            //Arrange

            var expected = new List<object> { new(), new() };

            var repo = new Mock<IBaseRepository<object>>();

            repo.Setup(r => r.GetAllAsync()).ReturnsAsync(expected);

            var service = new BaseService<object>(repo.Object);

            //Act
            var result = await service.GetAllEntitiesAsync();

            //Assert
            Xunit.Assert.Same(expected, result);
            repo.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetEntityById_Returns_Entity_From_Repository()
        {
            //Arrange
            var id = Guid.NewGuid();
            var expected = new object();

            var repo = new Mock<IBaseRepository<object>>();
            repo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(expected);

            var service = new BaseService<object>(repo.Object);

            //Act
            var result = await service.GetEntityById(id);

            //Assert
            Xunit.Assert.Same(expected, result);
            repo.Verify(r => r.GetByIdAsync(id), Times.Once);
        }
    }
}