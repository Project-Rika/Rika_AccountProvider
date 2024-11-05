using AccountProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AccountProvider.Tests.Delete
{
    public class DeleteTest
    {
        private readonly Mock<IUserService> _mockUserService;

        public DeleteTest()
        {

            _mockUserService = new Mock<IUserService>();
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldDeleteUser_AndReturnOkResult_WithStatusCode_200()
        {
            // Arrange
            var userId = 1;
            var okResult = new OkResult();

            _mockUserService.Setup(service => service.DeleteUserAsync(userId))
                            .ReturnsAsync(okResult);

            // Act
            var result = await _mockUserService.Object.DeleteUserAsync(userId);

            // Assert
            var okResultActual = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResultActual.StatusCode);
        }
    }
}
