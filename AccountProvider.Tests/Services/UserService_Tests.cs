using AccountProvider.Dtos;
using AccountProvider.Interfaces;
using Moq;

namespace AccountProvider.Tests.Services;

public class UserService_Tests
{
    private Mock<IUserService> _mockUserService;

    public UserService_Tests()
    {
        _mockUserService = new Mock<IUserService>();
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

        _mockUserService.Setup(x => x.GetUserAsync(userId))
            .ReturnsAsync((GetUserDto?)userDto);


		// Act
		var result = await _mockUserService.Object.GetUserAsync(userId);
        var statusCode = result != null ? "200" : "400";
        // Assert
        Assert.NotNull(result);
        Assert.Equal("200", statusCode);
        Assert.Equal(userId, result.Id);
    }

    
    [Fact]
    public async Task GetUserAsync_WhileNotExistingReturnNotFound ()
    {
        // Arrange
        var userId = "999";
        var userDto = new GetUserDto
        {
            Id = userId
        };

        _mockUserService.Setup(x => x.GetUserAsync(userId))
            .ReturnsAsync((GetUserDto?)null);

        // Act
        var result = await _mockUserService.Object.GetUserAsync(userId);
		var statusCode = result != null ? "200" : "400";

		// Assert
		Assert.Null(result);
		Assert.Equal("400", statusCode);
	}

}







