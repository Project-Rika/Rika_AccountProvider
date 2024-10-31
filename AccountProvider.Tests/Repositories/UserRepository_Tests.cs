using AccountProvider.Dtos;
using AccountProvider.Interfaces;
using Moq;

namespace AccountProvider.Tests.Repositories;

public class UserRepository_Tests
{
    private Mock<IUserRepository> _mockUserRepository;

    public UserRepository_Tests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
    }

    [Fact]
    public async Task GetUserAsync_ThenReturnUserById()
    {
        // Arrange
        var userId = "1";
        var userDto = new GetUserDto
        {
            Id = userId
        };
        _mockUserRepository.Setup(x => x.GetUserAsync(userId))
        .ReturnsAsync((GetUserDto?)userDto);

        // Act
        var result = await _mockUserRepository.Object.GetUserAsync(userId);
        var statusCode = result != null ? "200" : "400";

        // Assert
        Assert.NotNull(result);
        Assert.Equal("200", statusCode);
        Assert.Equal(userId, result.Id);

    }

    [Fact]
    public async Task GetUserAsync_WhileNotExistingReturnNotFound()
    {
        // Arrange
        var userId = "7679";
        var userDto = new GetUserDto
        {
            Id = userId
        };
        _mockUserRepository.Setup(x => x.GetUserAsync(userId))
            .ReturnsAsync((GetUserDto?)null);

        // Act
        var result = await _mockUserRepository.Object.GetUserAsync(userId);
		var statusCode = result != null ? "200" : "400";

        // Assert
        Assert.Null(result);
        Assert.Equal("400", statusCode);
	}
}
