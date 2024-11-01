using AccountProvider.Entities;
using AccountProvider.Interfaces;
using AccountProvider.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

		_mockUserService.Setup(x => x.UpdateUserAsync(updatedUserDto)).ReturnsAsync(new OkObjectResult(updatedUserDto));

		// Act
		var result = await _mockUserService.Object.UpdateUserAsync(updatedUserDto);

		// Assert
		Assert.NotNull(result);

		var okResult = Assert.IsType<OkObjectResult>(result);
		Assert.Equal(200, okResult.StatusCode);

		var returnedDto = Assert.IsType<UpdateUserDto>(okResult.Value);
		Assert.Equal(updatedUserDto, returnedDto);
	}

	[Fact]
	public async Task UpdateUserAsync_ShouldNotUpdateUser_AndReturn_StatusCode_400()
	{
		// Arrange
		UpdateUserDto? updatedUserDto = null;
		_mockUserService.Setup(x => x.UpdateUserAsync(updatedUserDto)).ReturnsAsync(new BadRequestResult());

		// Act
		var result = await _mockUserService.Object.UpdateUserAsync(updatedUserDto);

		// Assert
		Assert.NotNull(result);

		var okResult = Assert.IsType<BadRequestResult>(result);
		Assert.Equal(400, okResult.StatusCode);
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
			.ReturnsAsync(new BadRequestResult());

		// Act
		var result = await _mockUserService.Object.UpdateUserAsync(updatedUserDto);


		// Assert
		Assert.NotNull(result);

		var okResult = Assert.IsType<BadRequestResult>(result);
		Assert.Equal(400, okResult.StatusCode);
	}
}
