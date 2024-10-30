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
    public async Task UpdateUserAsync_ShouldUpdateUser_AndReturnUpdated_UserEntity()
    {
        // Arrange
        UserEntity userEntity = new UserEntity
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "Test",
            isEmailConfirmed = false,
            Password = "Test",
            Role = "Test",
            PhoneNumber = "Test",
            ProfileImageUrl = "Test",
            Age = 1,
            Gender = "Test",
            AddressId = "Test"
        };

        UserEntity updatedUserEntity = new UserEntity
        {
            FirstName = "updatedTest",
            LastName = "updatedTest",
            Email = "updatedTest",
            isEmailConfirmed = true,
            Password = "updatedTest",
            Role = "updatedTest",
            PhoneNumber = "updatedTest",
            ProfileImageUrl = "updatedTest",
            Age = 2,
            Gender = "updatedTest",
            AddressId = "updatedTest"
        };

        _mockUserRepository.Setup(x => x.UpdateUserAsync(updatedUserEntity)).ReturnsAsync(updatedUserEntity);

        // Act
        var result = await _mockUserRepository.Object.UpdateUserAsync(updatedUserEntity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updatedUserEntity, result);
    }

    [Fact]
    public async Task UpdateUserAsync_ShouldNotUpdateUser_AndReturnNull()
    {
        // Arrange
        UserEntity userEntity = new UserEntity
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "Test",
            isEmailConfirmed = false,
            Password = "Test",
            Role = "Test",
            PhoneNumber = "Test",
            ProfileImageUrl = "Test",
            Age = 1,
            Gender = "Test",
            AddressId = "Test"
        };

        UserEntity? updatedUserEntity = null;

        _mockUserRepository.Setup(x => x.UpdateUserAsync(updatedUserEntity)).ReturnsAsync(updatedUserEntity);

        // Act
        var result = await _mockUserRepository.Object.UpdateUserAsync(updatedUserEntity);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateUserAsync_ShouldNotUpdateUser_BecauseEmptyField_AndReturnNull()
    {
        // Arrange
        UserEntity userEntity = new UserEntity
        {
            FirstName = "Test",
            LastName = "Test",
            Email = "Test",
            isEmailConfirmed = false,
            Password = "Test",
            Role = "Test",
            PhoneNumber = "Test",
            ProfileImageUrl = "Test",
            Age = 1,
            Gender = "Test",
            AddressId = "Test"
        };

        UserEntity updatedUserEntity = new UserEntity
        {
            FirstName = "",
            LastName = "updatedTest",
            Email = "updatedTest",
            isEmailConfirmed = true,
            Password = "updatedTest",
            Role = "updatedTest",
            PhoneNumber = "updatedTest",
            ProfileImageUrl = "updatedTest",
            Age = 2,
            Gender = "updatedTest",
            AddressId = "updatedTest"
        };

        _mockUserRepository.Setup(x => x.UpdateUserAsync(It.Is<UserEntity>(u =>
            string.IsNullOrWhiteSpace(u.FirstName) ||
            string.IsNullOrWhiteSpace(u.LastName) ||
            string.IsNullOrWhiteSpace(u.Email) ||
            string.IsNullOrWhiteSpace(u.Password) ||
            string.IsNullOrWhiteSpace(u.Role) ||
            string.IsNullOrWhiteSpace(u.PhoneNumber) ||
            string.IsNullOrWhiteSpace(u.ProfileImageUrl) ||
            u.Age <= 0 ||
            string.IsNullOrWhiteSpace(u.Gender) ||
            string.IsNullOrWhiteSpace(u.AddressId))))
        .ReturnsAsync((UserEntity?)null);

        // Act
        var result = await _mockUserRepository.Object.UpdateUserAsync(updatedUserEntity);

        // Assert
        Assert.Null(result);
    }
}
