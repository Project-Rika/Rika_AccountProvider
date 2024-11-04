using AccountProvider.Dtos;
using AccountProvider.Interfaces;
﻿using AccountProvider.Entities;
using AccountProvider.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace AccountProvider.Tests.Services;

public class UserService_Tests
{
    private readonly Mock<IUserService> _mockUserService;

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

    [Fact]
    public async Task CreateUserAsync_ShouldCreateUser_AndReturnCreatedResult_WithStatusCode_201()
    {
        // Arrange
        var createUserDto = new CreateUserDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "SecurePassword123",
            PhoneNumber = "1234567890",
            ProfileImageUrl = "testurl",
            Age = 25,
            Gender = "test"
        };

        var createdResult = new CreatedResult(string.Empty, "User created successfully!");

        _mockUserService.Setup(service => service.CreateUserAsync(createUserDto))
                        .ReturnsAsync(createdResult);

        // Act
        var result = await _mockUserService.Object.CreateUserAsync(createUserDto);

        // Assert
        var createdResultActual = Assert.IsType<CreatedResult>(result);
        Assert.Equal(201, createdResultActual.StatusCode);
        Assert.Equal("User created successfully!", createdResultActual.Value);

    }

    [Fact]
    public async Task CreateUserAsync_ShouldReturnBadRequest_WhenInputIsInvalid()
    {
        // Arrange
        var createUserDto = new CreateUserDto
        {
            FirstName = "", 
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "SecurePassword123"
        };

        _mockUserService.Setup(service => service.CreateUserAsync(createUserDto))
                        .ReturnsAsync(new BadRequestObjectResult("Invalid input data. Please ensure all fields are filled in."));

        // Act
        var result = await _mockUserService.Object.CreateUserAsync(createUserDto);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal(400, badRequestResult.StatusCode);
        Assert.Equal("Invalid input data. Please ensure all fields are filled in.", badRequestResult.Value);
    }

    [Fact]
    public async Task CreateUserAsync_ShouldReturnConflict_WhenUserAlreadyExists()
    {
        // Arrange
        var createUserDto = new CreateUserDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "SecurePassword123"
        };

        var existingUser = new UserEntity
        {
            Id = "123",
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };

        _mockUserService.Setup(service => service.CreateUserAsync(createUserDto))
                        .ReturnsAsync(new ConflictObjectResult($"The email address is already registered. {existingUser}"));

        // Act
        var result = await _mockUserService.Object.CreateUserAsync(createUserDto);

        // Assert
        var conflictResult = Assert.IsType<ConflictObjectResult>(result);
        Assert.Equal(409, conflictResult.StatusCode);
        Assert.Equal($"The email address is already registered. {existingUser}", conflictResult.Value);
    }

    [Fact]
    public async Task CreateUserAsync_ShouldReturnInternalServerError_WhenExceptionOccurs()
    {
        // Arrange
        var createUserDto = new CreateUserDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "SecurePassword123"
        };
       
        _mockUserService.Setup(service => service.CreateUserAsync(createUserDto))
                        .ReturnsAsync(new StatusCodeResult(500));

        // Act
        var result = await _mockUserService.Object.CreateUserAsync(createUserDto);

        // Assert
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
}







