using AccountProvider.Entities;
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
    public async Task GetAllUsersAsync_ShouldReturnListOfUsersAndStatusCode()
    {
        // Arrange
        var users = new List<UserEntity>
        {
            new UserEntity { Id = "1", Gender = "Male", Email = "william@domain.com" },
            new UserEntity { Id = "2", Gender = "Female", Email = "gustavia@domain.com" }
        };

        // Act
        var userEntity = new UserEntity
        {
            Id = "1",
            FirstName = "William",
            LastName = "Hägg"
        };
        _mockUserRepository.Setup(x => x.GetAllUserAsync()).ReturnsAsync(new List<UserEntity> { userEntity });

        var result = await _mockUserRepository.Object.GetAllUserAsync();

		var statusCode = "";
		if (result == null)
		{
			statusCode = "400";
		}
		else
		{
			statusCode = "200";
		}

		// Assert

		Assert.NotNull(result);
        Assert.IsType<List<UserEntity>>(result);
		Assert.Equal("200", statusCode);
	}    

    [Fact]
    public async Task GetAllUsersAsync_CouldNotGetListOfUsers()
    {
        _mockUserRepository.Setup(x => x.GetAllUserAsync()).ReturnsAsync(new List<UserEntity>());
		var result = await _mockUserRepository.Object.GetAllUserAsync();

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
