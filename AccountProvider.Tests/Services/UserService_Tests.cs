using AccountProvider.Interfaces;
using AccountProvider.Models;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace AccountProvider.Tests.Services;

public class UserService_Tests
{
    private Mock<IUserService> _mockUserService;

    public UserService_Tests()
    {
        _mockUserService = new Mock<IUserService>();
    }

    [Fact]
    public async Task GetAllUsersAsync_ShouldReturnList()
    {
        // Arrange
        var users = new List<GetAllUserDto>
        {
            new GetAllUserDto {Id = "1", Gender = "Male", Email = "William@domain.com"},


             new GetAllUserDto {Id = "2", Gender = "Female", Email = "gustavia@domain.com"}
        };
        // Act
        var getAllUserDto = new GetAllUserDto
        {
            Id = "1",
            FirstName = "William",
            LastName = "Hägg"
        };

        _mockUserService.Setup(x => x.GetAllUserAsync()).ReturnsAsync(new List<GetAllUserDto> { getAllUserDto });

        var result = await _mockUserService.Object.GetAllUserAsync();
		var statusCode = "";
		if (result != null)
		{
			statusCode = "200";
		}
		else
		{
			statusCode = "400";
		}

		// Assert
		Assert.NotNull(result);
        Assert.IsType<List<GetAllUserDto>>(result);
		Assert.Equal("200", statusCode);
	}

    [Fact]
    public async Task GetAllUsersAsync_CouldNotGetListOfUsers()
    {
        _mockUserService.Setup(x => x.GetAllUserAsync()).ReturnsAsync(new List<GetAllUserDto>());

        var result = await _mockUserService.Object.GetAllUserAsync();

        var statusCode = "";
        if (result == null)
        {
            statusCode = "200";
        }
        else
        {
            statusCode = "400";
        }

        Assert.NotNull(result);
        Assert.Empty(result);
        Assert.Equal("400", statusCode);
	}

}
