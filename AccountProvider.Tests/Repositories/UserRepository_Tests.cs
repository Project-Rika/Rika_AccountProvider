using AccountProvider.Dtos;
using AccountProvider.Interfaces;
﻿using AccountProvider.Context;
using AccountProvider.Entities;
using AccountProvider.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AccountProvider.Tests.Repositories;

public class UserRepository_Tests
{
    private Mock<IUserRepository> _mockUserRepository;

    private readonly UserRepository _userRepository;
    private readonly DataContext _context;

    public UserRepository_Tests()
    {
        _mockUserRepository = new Mock<IUserRepository>();

        var options = new DbContextOptionsBuilder<DataContext>()
    .UseInMemoryDatabase(databaseName: "TestDatabase")
    .Options;

        _context = new DataContext(options);
        _userRepository = new UserRepository(_context);
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

    public async Task GetByEmailAsync_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var user = new UserEntity
        {
            Id = "1",
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "SecurePassword123",
            Role = "User"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Act
        var result = await _userRepository.GetByEmailAsync("john.doe@example.com");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("john.doe@example.com", result?.Email);
    }
    [Fact]
    public async Task GetByEmailAsync_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Act
        var result = await _userRepository.GetByEmailAsync("nonexistent@example.com");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateUserAsync_ShouldAddUserToDatabase()
    {
        // Arrange
        var user = new UserEntity
        {
            Id = "2",
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com",
            Password = "SecurePassword123",
            Role = "User" 
        };

        // Act
        await _userRepository.CreateUserAsync(user);
        var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == "jane.smith@example.com");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("jane.smith@example.com", result?.Email);
    }
}
