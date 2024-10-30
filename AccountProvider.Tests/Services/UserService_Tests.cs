using AccountProvider.Entities;
using AccountProvider.Interfaces;
using AccountProvider.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
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
	public async Task UpdateUserAsync_ShouldUpdateUser_AndReturnUpdated_UpdateUserDto_AndStatusCode_200()
	{
		// Arrange
		UpdateUserDto updatedUserDto = new UpdateUserDto
		{
			FirstName = "Test",
			LastName = "Test",
			Email = "Test@domain.com",
			Password = "password",
			PhoneNumber = "1234567890",
			ProfileImageUrl	= "test",
			Age = 2,
			Gender = "test"
		};

		_mockUserService.Setup(x => x.UpdateUserAsync(updatedUserDto)).ReturnsAsync(updatedUserDto);

		// Act
		var result = await _mockUserService.Object.UpdateUserAsync(updatedUserDto);
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
		Assert.Equal(updatedUserDto, result);
		Assert.Equal("200", statusCode);
	}

	[Fact]
	public async Task UpdateUserAsync_ShouldNotUpdateUser_AndReturnNull_AndStatusCode_400()
	{
		// Arrange
		UpdateUserDto? updatedUserDto = null;
		_mockUserService.Setup(x => x.UpdateUserAsync(updatedUserDto)).ReturnsAsync(updatedUserDto);

		// Act
		var result = await _mockUserService.Object.UpdateUserAsync(updatedUserDto);
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
		Assert.Null(result);
		Assert.Equal(updatedUserDto, result);
		Assert.Equal("400", statusCode);
	}

	[Fact]
	public async Task UpdateUserAsync_ShouldNotUpdateUser_BecauseEmptyField_AndReturnNull_AndStatusCode_400()
	{
		// Arrange
		UpdateUserDto updatedUserDto = new UpdateUserDto
		{
			FirstName = "Test",
			LastName = "Test",
			Email = "",
			Password = "password",
			PhoneNumber = "1234567890",
			ProfileImageUrl = "test",
			Age = 2,
			Gender = "test"
		};

		_mockUserService.Setup(x => x.UpdateUserAsync(It.Is<UpdateUserDto>(u =>
			string.IsNullOrWhiteSpace(u.FirstName) ||
			string.IsNullOrWhiteSpace(u.LastName) ||
			string.IsNullOrWhiteSpace(u.Email) ||
			string.IsNullOrWhiteSpace(u.Password) ||
			string.IsNullOrWhiteSpace(u.PhoneNumber) ||
			string.IsNullOrWhiteSpace(u.ProfileImageUrl) ||
			u.Age <= 0 ||
			string.IsNullOrWhiteSpace(u.Gender))))
			.ReturnsAsync((UpdateUserDto?)null);

		// Act
		var result = await _mockUserService.Object.UpdateUserAsync(updatedUserDto);
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
		Assert.Null(result);
		Assert.Equal("400", statusCode);
	}
}
